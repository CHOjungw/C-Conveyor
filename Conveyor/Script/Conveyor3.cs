using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Conveyor3 : CDevice
{
    public GameObject Carrierprefab;
    public CCarrier carrier;
    public Transform endPointCw, endPointCcw;
    void Start()
    {
        GameObject CarrierObject = Instantiate(Carrierprefab,transform.position, Quaternion.identity);
        carrier = CarrierObject.GetComponent<CCarrier>();
    }    
    void Update()
    {
        if (blsStartConv)
        {
            switch (stepConv)
            {
                case 0:
                    blsUReq = false;
                    blsUReq = false;
                    blsReady = false;
                    statusCwConv = false;
                    statusCcwConv = false;

                    stepConv = 100;
                    break;
                case 100:
                    blsLReq = true;
                    if (blsTrReq)
                    {
                        statusCwConv = true;
                        blsReady = true;
                        stepConv = 110;
                    }

                    break;
                case 110:
                    if (blsBusy)
                    {

                        stepConv = 120;
                    }

                    break;
                case 120:
                    if (blsSensorDetect2)
                    {
                        statusCwConv = false;
                        stepConv = 130;
                    }
                    break;
                case 130:
                    if (!blsTrReq && !blsBusy && blsCompt)
                    {
                        blsLReq = false;
                        blsReady = false;
                        stepConv = 140;
                    }
                    break;
                case 140:
                    if (!blsCompt)
                    {
                        stepConv = 200;
                    }
                    break;
                case 200:
                    if (carrier.use == CCarrier.USE.USE_TAKEOUT)
                    {
                        blsUReq = true;
                        statusCcwConv = true;
                        if(blsSensorDetect1)
                            statusCcwConv = false;
                    }
                    if (!blsSensorDetect1 && !blsSensorDetect2 && !blsUReq)
                    {
                        stepConv = 100;
                    }
                    else if (blsTrReq)
                    {
                        statusCcwConv = true;
                        stepConv = 210;
                        blsReady = true;
                    }
                    break;
                case 210:
                    if (!blsTrReq)
                    {
                        blsUReq = false;
                        statusCcwConv = false;
                        stepConv = 220;
                    }
                    break;
                case 220:                    
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
        if (oldStep != stepConv)
        {
            Debug.Log("Conveyor 3 Step = "+ stepConv);
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
    }
}
