using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPIO : MonoBehaviour
{
    public bool blsTrReq;
    public bool blsBusy;
    public bool blsCompt;
    public bool blsUReq;
    public bool blsLReq;
    public bool blsReady;
   

    

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
        set { blsUReq = value; }
    }
    public bool LReq               //LoadRequest
    {
        get { return blsLReq; }
        set { blsLReq = value; }
    }
    public bool Ready
    {
        get { return blsReady; }
        set { blsReady = value; }
    }  
    void Start()
    {
    
    }

    
    void Update()
    {
        
    }

}
