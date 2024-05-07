using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ConveyorS : CDevice
{
    private int delayTime = 0;    
    DetectObject detectObject;    
    private Sensor sensor;    
    public CCarrier carrier;
    public RPIO convPio1, convPio2, convPio3, convPio4;    
    public Transform endPointCw, endPointCcw;
    public GameObject ConvPioprefab,Carrierprefab;
    public MotionControl motionControl;
    


    public enum SERVO_POS
    {
        CONV_NONE = 0,
        CONV1 = 1,
        CONV2 = 2,
        CONV3 = 3,
        CONV4 = 4
    }

    private SERVO_POS tarPos;           //�������� �����ϴ� ����
    private SERVO_POS curPos;           //���� ��ġ�� �������� ����
    public SERVO_POS TargetPosition
    {
        get { return tarPos; }
    }
    public SERVO_POS CurrentPosition
    {
        get { return curPos; }
        set { curPos = value; }
    }
    private void MovePosition(SERVO_POS target)
    {
        tarPos = target;
    }
    public SERVO_POS GetPosition()
    {
        return curPos;
    }
    void Start()
    {        
        InstantiatePrefabs();
        motionControl = GameObject.Find("�����̾��̵�����").GetComponent<MotionControl>();
        detectObject = GetComponentInChildren<DetectObject>();        
        sensor = GetComponentInChildren<Sensor>();             
    }
    void Update()
    {          
        if (blsStartConv == true)
        {
            switch (stepConv)
            {
                case 0:
                    stepConv = 100;
                    break;
                case 100:                                       //�����̾� UReq�� ���� ���� ����
                    statusCw = false;
                    if (convPio1.UReq) stepConv = 200;
                    else if (convPio2.UReq) stepConv = 300;
                    else if (convPio3.UReq) stepConv = 400;
                    else if (convPio4.UReq) stepConv = 500;
                    break;
                case 200:                                       //S�����̾� ��ġ����
                    if (convPio1.UReq)
                    {
                        MovePosition(SERVO_POS.CONV1);
                        if (GetPosition() == SERVO_POS.CONV1)
                        {
                            stepConv = 210;
                        }
                    }
                    break;
                case 210:                                       //�����̾ �����ϸ� ��ȯ PIO�۵�
                    convPio1.TrReq = true;
                    if (convPio1.UReq && convPio1.Ready)
                    {
                        stepConv = 220;
                    }
                    break;
                case 220:                                       //��Ʈ ���� �۵�
                    statusCcwConv = true;
                    convPio1.Busy = true;
                    if (convPio1.Ready && blsSensorDetect2)
                    {

                        statusCcwConv = false;
                        convPio1.TrReq = false;
                        convPio1.Busy = false;
                        stepConv = 230;
                    }
                    break;
                case 230:                                       //
                    convPio1.Compt = true;
                    if (!convPio1.Ready)
                    {
                        convPio1.Compt = false;
                        stepConv = 240;
                    }
                    break;
                case 240:
                    stepConv = 600;
                    break;
                case 300:                                       //PIO�����Ͽ� S�����̾� �̵�
                    if (convPio2.UReq)
                    {
                        MovePosition(SERVO_POS.CONV2);

                        if (GetPosition() == SERVO_POS.CONV2)
                        {
                            stepConv = 310;
                        }
                    }
                    break;
                case 310:                                       //transffer ��û                    
                    if (motionControl.compt)
                    {
                        convPio2.TrReq = true;
                    }
                    if (convPio2.UReq && convPio2.Ready)
                    {
                        stepConv = 320;
                    }
                    break;
                case 320:                                       //��Ʈ ���� ����                       
                        statusCwConv = true;
                        convPio2.Busy = true;                    
                    if (carrier.use == CCarrier.USE.USE_TAKEOUT)
                        if (blsSensorDetect1)
                        { 
                            statusCwConv = false;
                            convPio2.TrReq = false;
                            convPio2.blsBusy = false;
                            stepConv = 330;
                        }
                    if(blsSensorDetect1)
                    {
                        convPio2.TrReq = false;
                    }
                    if (convPio2.Ready && blsSensorDetect2)
                    {                        
                        statusCwConv = false;                        
                        convPio2.Busy = false;
                        stepConv = 330;                       
                    }
                    break;
                case 330:                                       //complete On
                    convPio2.Compt = true;                   
                    if (!convPio2.Ready)
                    {
                        convPio2.Compt = false;                        
                        stepConv = 340;
                    }
                    break;
                case 340:
                    stepConv = 600;
                    break;
                case 400:
                    if (convPio3.UReq)
                    {
                        MovePosition(SERVO_POS.CONV3);
                        if (GetPosition() == SERVO_POS.CONV3)
                        {
                            stepConv = 410;
                        }
                    }
                    break;
                case 410:
                    if (motionControl.compt)
                    {
                        convPio3.TrReq = true;
                    }
                    if (convPio3.UReq && convPio3.Ready)
                    {
                        stepConv = 420;
                    }
                    break;
                case 420:
                    statusCcwConv = true;
                    convPio3.Busy = true;
                    if (blsSensorDetect2)
                    {
                        convPio3.TrReq = false;
                    }
                    if (convPio3.Ready && blsSensorDetect1)
                    {
                        statusCwConv = false;                        
                        convPio3.Busy = false;
                        stepConv = 430;
                    }
                    break;
                case 430:
                    convPio3.Compt = true;
                    if (!convPio3.Ready)
                    {
                        convPio3.Compt = false;
                        stepConv = 440;
                    }
                    break;
                case 440:
                    stepConv = 600;
                    break;
                case 500:
                    if (convPio4.UReq)
                    {
                        MovePosition(SERVO_POS.CONV4);
                        if (GetPosition() == SERVO_POS.CONV4)
                        {
                            stepConv = 510;
                        }
                    }
                    break;
                case 510:
                    if (motionControl.compt)
                    { 
                        convPio4.TrReq = true; 
                    }
                    if (convPio4.UReq && convPio4.Ready)
                    {
                        stepConv = 520;
                    }
                    break;
                case 520:
                    statusCcwConv = true;
                    convPio4.Busy = true;
                    if(blsSensorDetect2)
                    {
                        convPio4.TrReq = false;
                    }
                    if (convPio4.Ready && blsSensorDetect1)
                    {
                        statusCcwConv = false;                        
                        convPio4.Busy = false;
                        stepConv = 530;
                    }
                    break;
                case 530:
                    convPio4.Compt = true;
                    if (!convPio4.Ready)
                    {
                        convPio4.Compt = false;
                        stepConv = 540;
                    }
                    break;
                case 540:
                    stepConv = 600;
                    break;
                case 600:                                       //��� �����̾�� ���� ���ϴ� step
                    if (carrier.id != 0)
                    {
                        if (carrier.use == CCarrier.USE.USE_TAKEOUT)    //���� ������ take out �̸� 1������ ����
                        {
                            if (convPio1.LReq)
                            {
                                stepConv = 700;
                                carrier.dest = 1;
                            }
                        }
                        else if (carrier.use == CCarrier.USE.USE_STACK)//���� ������ stack �̸� 3,4������ ����
                        {
                            if (carrier.dest ==3)
                            {
                                stepConv = 900;                                
                            }
                            if (carrier.dest==4)
                            {
                                stepConv = 1000;                                
                            }
                        }
                        else if (carrier.use == CCarrier.USE.USE_NONE)  //ĳ���� ������ none�̸� 1������ ����
                        {
                            if (convPio1.LReq)
                            {
                                stepConv = 700;
                                carrier.dest = 1;
                            }
                        }
                    }
                    break;
                case 700:
                    if (convPio1.LReq)
                    {
                        MovePosition(SERVO_POS.CONV1);
                        if (GetPosition() == SERVO_POS.CONV1)
                            stepConv = 710;
                    }
                    break;

                case 710:
                    if (motionControl.compt)
                    {
                        statusCcwConv = true;
                        convPio1.Busy = true;
                        convPio1.TrReq = true;
                    }                    
                    if (convPio1.LReq && convPio1.Ready)
                    {
                        stepConv = 720;
                    }
                    break;

                case 720:                                    
                    if (!blsSensorDetect1)
                    {
                        statusCcwConv = false;
                        convPio1.TrReq = false;
                        convPio1.Busy = false;
                        stepConv = 730;
                    }
                    break;

                case 730:
                    convPio1.Compt = true;
                    if (!convPio1.Ready)
                    {
                        convPio1.Compt = false;
                        stepConv = 100;
                    }
                    break;

                case 800:
                    if (convPio1.LReq)
                    {
                        MovePosition(SERVO_POS.CONV2);
                        if (GetPosition() == SERVO_POS.CONV2)
                            stepConv = 810;
                    }
                    break;

                case 810:
                    if (motionControl.compt)
                    {
                        statusCcwConv = true;
                        convPio2.Busy = true;
                        convPio2.TrReq = true;
                    }                   
                    if (convPio2.LReq && convPio2.Ready)
                    {
                        stepConv = 820;
                    }
                    break;

                case 820:
                    statusCwConv = true;
                    convPio2.Busy = true;
                    if (!blsSensorDetect1 && !blsSensorDetect2)
                    {
                        statusCwConv = false;
                        convPio2.TrReq = false;
                        convPio2.Busy = false;
                        stepConv = 830;
                    }
                    break;

                case 830:
                    convPio2.Compt = true;
                    if (!convPio2.Ready)
                    {
                        convPio2.Compt = false;
                        stepConv = 100;
                    }
                    break;

                case 900:
                    if (convPio3.LReq)
                    {
                        MovePosition(SERVO_POS.CONV3);
                        if (GetPosition() == SERVO_POS.CONV3)
                            stepConv = 910;
                    }
                    break;

                case 910:
                    if (motionControl.compt)
                    {
                        statusCwConv = true;
                        convPio3.Busy = true;
                        convPio3.TrReq = true;
                    }                   
                    if (convPio3.LReq && convPio3.Ready)
                    {
                        stepConv = 920;
                    }
                    break;

                case 920:                    
                    if (!blsSensorDetect1 && !blsSensorDetect2)
                    {
                        statusCwConv = false;
                        convPio3.TrReq = false;
                        convPio3.Busy = false;
                        stepConv = 930;
                    }
                    break;

                case 930:
                    convPio3.Compt = true;
                    if (!convPio3.Ready)
                    {
                        convPio3.Compt = false;
                        stepConv = 100;
                    }
                    break;

                case 1000:
                    if (convPio4.LReq)
                    {
                        MovePosition(SERVO_POS.CONV4);
                        if (GetPosition() == SERVO_POS.CONV4)
                            stepConv = 1010;
                    }
                    break;

                case 1010:
                    if (motionControl.compt)
                    {
                        statusCwConv = true;
                        convPio4.Busy = true;
                        convPio4.TrReq = true;
                    }                    
                    if (convPio4.LReq && convPio4.Ready)
                    {
                        stepConv = 1020;
                    }
                    break;

                case 1020:                                      //sensor2���� cw�����Ͽ� cov4�� ������Ʈ �̵�                    
                    if (!blsSensorDetect1 && !blsSensorDetect2)
                    {
                        statusCwConv = false;
                        convPio4.TrReq = false;
                        convPio4.Busy = false;
                        stepConv = 1030;
                    }
                    break;

                case 1030:                                      //tr�Ϸ�Ǿ� compt on (������ conv4�� ������ ��ǥ���� �����ҋ����� ��ٸ�)
                    convPio4.Compt = true;
                    if (!convPio4.Ready)                        //conv4���������̾ƴ϶��
                    {
                        convPio4.Compt = false;                 //compt off�ϰ� 100���� ó������ ���ư�
                        stepConv = 100;
                    }
                    break;
                default:
                    stepConv = 0;
                    break;
            }
        }
        else
        {
            stepConv = 0;
        }

        if (oldStep != stepConv)                                //step debug�� �ڵ�
        {
            Debug.Log("Suttle Conveyor step :" + stepConv);
            oldStepConv = stepConv;
        }        
        blsTakeIn = false;
    }


    private void OnTriggerStay(Collider other)
    {
        if (statusCwConv)
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, endPointCw.position, 0.1f * Time.deltaTime);
        }
        else if (statusCcwConv)
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, endPointCcw.position, 0.1f * Time.deltaTime);
            
        }
        if(motionControl.compt) other.transform.parent = transform;
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
    private void InstantiatePrefabs()
    {
        GameObject ConvPioPOb1 = Instantiate(ConvPioprefab, transform.position, Quaternion.identity);
        convPio1 = ConvPioPOb1.GetComponent<RPIO>();        
        GameObject ConvPioPOb2 = Instantiate(ConvPioprefab, transform.position, Quaternion.identity);
        convPio2 = ConvPioPOb2.GetComponent<RPIO>();
        GameObject ConvPioPOb3 = Instantiate(ConvPioprefab, transform.position, Quaternion.identity);
        convPio3 = ConvPioPOb3.GetComponent<RPIO>();
        GameObject ConvPioPOb4 = Instantiate(ConvPioprefab, transform.position, Quaternion.identity);
        convPio4 = ConvPioPOb4.GetComponent<RPIO>();
        GameObject CarrierObject = Instantiate(Carrierprefab, transform.position, Quaternion.identity);
        carrier = CarrierObject.GetComponent<CCarrier>();
    }   
}
