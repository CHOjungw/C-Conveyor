using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Conveyor1 : CDevice
{
    public CCarrier carrier;
    public GameObject Carrierprefab;  
    public Transform endPointCw, endPointCcw;
    void Start()
    {
        GameObject CarrierObject = Instantiate(Carrierprefab, transform.position,Quaternion.identity);
        carrier = CarrierObject.GetComponent<CCarrier>();
    }

    
    void Update()
    { 
        if (blsStartConv == true)
        {
            switch (stepConv)
            {
                case 0:
                    blsTrReq = false;
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
                        statusCcwConv = true;
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
                    if (blsSensorDetect1)
                    {                        
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
                    if (!blsSensorDetect1 && !blsSensorDetect2)
                    {
                        stepConv = 100;
                        statusCcwConv = false;
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
        if (oldStep != stepConv)
        {
            Debug.Log("Conveyor 1 Step = " + stepConv);
        }
        oldStepConv = stepConv;
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


