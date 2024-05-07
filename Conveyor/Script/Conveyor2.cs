using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Conveyor2 :CDevice
{
    DetectObject detectObject;    
    Sensor sensor;
    public CCarrier carrier;    
    public Transform endPointCw, endPointCcw;
    public GameObject Carrierprefab;
  
    void Start()
    {
        GameObject CarrierObject = Instantiate(Carrierprefab, transform.position, Quaternion.identity);
        carrier = CarrierObject.GetComponent<CCarrier>();
        detectObject = GetComponentInChildren<DetectObject>();        
        sensor = GetComponentInChildren<Sensor>();        
    }


    void Update()
    {        
        if (blsStartConv)
        {
            switch(stepConv)
            {
                case 0:
                    
                    blsUReq = false;
                    blsLReq = false;
                    blsReady = false;
                    statusCwConv = false;
                    statusCcwConv = false;

                    stepConv = 100;
                    
                    break;
                case 100:                                   //센서를 감지하여 벨트가동
                    
                    if (blsSensorDetect2)
                    {
                        stepConv = 200;
                    }
                    else
                    {                        
                        if (blsTakeIn)
                        {
                            statusCwConv = true;
                            stepConv = 110;
                            //countConv = 0;
                        }
                    }
                    
                    break;
                case 110:                                   //물건이 컨베이어 존재
                    if (blsSensorDetect2)
                    {
                        statusCwConv = false;
                        blsUReq = true;
                        stepConv = 200;
                    }
                    
                    break;
                case 200:                                   //센서 바탕으로 스탭 결정
                    if (!blsSensorDetect2)
                    {
                        stepConv = 100;
                    }                    
                    else if (blsTrReq)
                    {
                        statusCwConv = true;
                        blsReady = true;
                        stepConv = 210;                        
                    }                    
                    break;
                case 210:
                    
                    if (!blsTrReq)
                    {
                        blsUReq = false;
                        stepConv = 220;
                        statusCwConv = false;
                    }                    
                    break;
                    
                case 220:                                   //S컨베이어 완료대기                                       
                    if (!blsTrReq && !blsBusy && blsCompt)
                    {
                        blsReady = false;                                                
                        stepConv = 230;
                    }                    
                    break;

                case 230:
                    if (!blsCompt)
                        stepConv = 100;                    
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
        if(oldStep != stepConv) 
        {
           Debug.Log("Conveyor 2 Step ="+stepConv);
            oldStep = stepConv;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (statusCwConv)
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, endPointCw.position, 0.1f * Time.deltaTime);
        }
        else if(statusCwConv)
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, endPointCcw.position, 0.1f * Time.deltaTime);
        }
    }
}
