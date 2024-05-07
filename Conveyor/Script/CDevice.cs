using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CDevice : MonoBehaviour
{
    protected bool blsSensorDetect1, blsSensorDetect2;
    protected bool blsStartConv;
    protected bool blsTrReq, blsBusy, blsCompt, blsUReq, blsLReq, blsReady;
    protected bool statusCwConv, statusCcwConv;
    protected bool blsTakeIn,blsTakeOut;
    
    protected int stepConv;
    protected int oldStepConv;
    protected int countConv;
    
    public bool GetSensorState1()
    {
        return blsSensorDetect1;
    }
    public bool GetSensorState2()
    {
        return blsSensorDetect2;
    }
    public bool statusCw
    {
        get { return statusCwConv; }
        set { statusCwConv = value; }
    }
    public bool statusCcw
    {
        get { return statusCcwConv; }
        set { statusCcwConv = value; }
    }
    public void SetSensorState1(bool newState)
    {
        blsSensorDetect1 = newState;
    }
    public void SetSensorState2(bool newState)
    {
        blsSensorDetect2 = newState;
    }
    public bool TrReq              //Trrequest
    {
        get { return blsTrReq; }
        set { blsTrReq = value; }
    }
    public bool Busy
    {
        get { return blsBusy; }
        set { blsBusy = value; }
    }
    public bool Compt              //Complate
    {
        get { return blsCompt; }
        set { blsCompt = value; }
    }
    public bool UReq               //UploadeRequest
    {
        get { return blsUReq; }
    }
    public bool LReq               //LoadRequest
    {
        get { return blsLReq; }
    }
    public bool Ready
    {
        get { return blsReady; }
    }
    public bool start
    {
        get { return blsStartConv; }
        set { blsStartConv = value; }
    }
    public bool takeIn
    {
        get { return blsTakeIn; }
        set { blsTakeIn = value; }
    }
    public bool takeOut
    {
        get { return blsTakeOut; }
        set { blsTakeOut = value; }
    }
    public int step
    {
        get { return stepConv; }
        set { stepConv = value; }
    }
    public int oldStep
    {
        get { return oldStepConv; }
        set { oldStepConv = value; }
    }
    public int count
    {
        get { return countConv; }
        set { countConv = value; }
    }
}
