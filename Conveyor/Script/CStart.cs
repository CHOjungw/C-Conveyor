using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class CStart : MonoBehaviour
{
    public Button start;
    public Conveyor1 conveyor1;
    public Conveyor2 conveyor2;
    public Conveyor3 conveyor3;
    public Conveyor4 conveyor4;
    public ConveyorS conveyorS;
    //public RPIO rpio;
  
    void Start()
    {
        
        conveyor1 = GameObject.Find("컨베이어1").GetComponent<Conveyor1>();
        conveyor2 = GameObject.Find("컨베이어2").GetComponent<Conveyor2>();        
        conveyor3 = GameObject.Find("컨베이어3").GetComponent<Conveyor3>();
        conveyor4 = GameObject.Find("컨베이어4").GetComponent<Conveyor4>();
        conveyorS = GameObject.Find("컨베이어S").GetComponent<ConveyorS>();
        
        start = GetComponent<Button>();              
        start.onClick.AddListener(ConvStart);
        //Simulation();
    }
    
    void Update()
    { 
        PioExchanger();
        DataExchanger();
        
    }
    public void ConvStart()
    {
        Debug.Log("Start되었음");
        conveyor1.start = true;
        conveyor2.start = true;
        conveyor3.start = true;
        conveyor4.start = true;
        conveyorS.start = true;
    }
    private void PioExchanger()
    {     
        
        conveyor1.TrReq = conveyorS.convPio1.TrReq;        
        conveyor1.Busy = conveyorS.convPio1.Busy;
        conveyor1.Compt = conveyorS.convPio1.Compt;
        conveyorS.convPio1.LReq = conveyor1.LReq;
        conveyorS.convPio1.UReq = conveyor1.UReq;
        conveyorS.convPio1.Ready = conveyor1.Ready;

        conveyor2.TrReq = conveyorS.convPio2.TrReq;
        conveyor2.Busy = conveyorS.convPio2.Busy;
        conveyor2.Compt = conveyorS.convPio2.Compt;
        conveyorS.convPio2.LReq = conveyor2.LReq;
        conveyorS.convPio2.UReq = conveyor2.UReq;
        conveyorS.convPio2.Ready = conveyor2.Ready;

        conveyor3.TrReq = conveyorS.convPio3.TrReq;
        conveyor3.Busy = conveyorS.convPio3.Busy;
        conveyor3.Compt = conveyorS.convPio3.Compt;
        conveyorS.convPio3.LReq = conveyor3.LReq;
        conveyorS.convPio3.UReq = conveyor3.UReq;
        conveyorS.convPio3.Ready = conveyor3.Ready;

        conveyor4.TrReq = conveyorS.convPio4.TrReq;
        conveyor4.Busy = conveyorS.convPio4.Busy;
        conveyor4.Compt = conveyorS.convPio4.Compt;
        conveyorS.convPio4.LReq = conveyor4.LReq;
        conveyorS.convPio4.UReq = conveyor4.UReq;
        conveyorS.convPio4.Ready = conveyor4.Ready;
    }
    private void DataExchanger()
    {        
        if (conveyor1.Ready&&conveyorS.CurrentPosition==ConveyorS.SERVO_POS.CONV1)
        {
            if (conveyor1.LReq)
            {
                if (conveyorS.carrier.id != 0)
                {
                    conveyor1.carrier.id = conveyorS.carrier.id;
                    conveyor1.carrier.source = conveyorS.carrier.source;
                    conveyor1.carrier.dest = conveyorS.carrier.dest;
                    conveyor1.carrier.use = conveyorS.carrier.use;
                    conveyorS.carrier.Clear();

                    Console.WriteLine("Carrier Data Move : S ->1");             //데이타 확인 로그
                }
            }
            if (conveyor1.UReq)
            {
                if (conveyor1.carrier.id != 0)
                {
                    conveyorS.carrier.id = conveyor1.carrier.id;
                    conveyorS.carrier.source = conveyor1.carrier.source;
                    conveyorS.carrier.dest = conveyor1.carrier.dest;
                    conveyorS.carrier.use = conveyor1.carrier.use;
                    conveyor1.carrier.Clear();

                    Debug.Log("Carrier Data Move : 1 ->S");             //데이타 확인 로그
                }
            }
        }
        if (conveyor2.Ready&& conveyorS.CurrentPosition == ConveyorS.SERVO_POS.CONV2)
        {
            if (conveyor2.LReq)
            {
                if (conveyorS.carrier.id != 0)
                {
                    conveyor2.carrier.id = conveyorS.carrier.id;
                    conveyor2.carrier.source = conveyorS.carrier.source;
                    conveyor2.carrier.dest = conveyorS.carrier.dest;
                    conveyor2.carrier.use = conveyorS.carrier.use;
                    conveyorS.carrier.Clear();

                    Debug.Log("Carrier Data Move : S ->2");             //데이타 확인 로그
                }
            }
            if (conveyor2.UReq)
            {
                if (conveyor2.carrier.id != 0)
                {
                    conveyorS.carrier.id = conveyor2.carrier.id;
                    conveyorS.carrier.source = conveyor2.carrier.source;
                    conveyorS.carrier.dest = conveyor2.carrier.dest;
                    conveyorS.carrier.use = conveyor2.carrier.use;
                    conveyor2.carrier.Clear();

                    Debug.Log("Carrier Data Move : 2 ->S");             //데이타 확인 로그
                }
            }
        }
        if (conveyor3.Ready && conveyorS.CurrentPosition == ConveyorS.SERVO_POS.CONV3)
        {
            if (conveyor3.LReq)
            {
                if (conveyorS.carrier.id != 0)
                {
                    conveyor3.carrier.id = conveyorS.carrier.id;
                    conveyor3.carrier.source = conveyorS.carrier.source;
                    conveyor3.carrier.dest = conveyorS.carrier.dest;
                    conveyor3.carrier.use = conveyorS.carrier.use;
                    conveyorS.carrier.Clear();

                    Debug.Log("Carrier Data Move : S ->3");             //데이타 확인 로그
                }
            }
            if (conveyor3.UReq)
            {
                if (conveyor3.carrier.id != 0)
                {
                    conveyorS.carrier.id = conveyor3.carrier.id;
                    conveyorS.carrier.source = conveyor3.carrier.source;
                    conveyorS.carrier.dest = conveyor3.carrier.dest;
                    conveyorS.carrier.use = conveyor3.carrier.use;
                    conveyor3.carrier.Clear();

                    Debug.Log("Carrier Data Move : 3 ->S");             //데이타 확인 로그
                }
            }
        }
        if (conveyor4.Ready && conveyorS.CurrentPosition == ConveyorS.SERVO_POS.CONV4)
        {
            if (conveyor4.LReq)
            {
                if (conveyorS.carrier.id != 0)
                {
                    conveyor4.carrier.id = conveyorS.carrier.id;
                    conveyor4.carrier.source = conveyorS.carrier.source;
                    conveyor4.carrier.dest = conveyorS.carrier.dest;
                    conveyor4.carrier.use = conveyorS.carrier.use;
                    conveyorS.carrier.Clear();

                    Debug.Log("Carrier Data Move : S ->4");             //데이타 확인 로그
                }
            }
            if (conveyor4.UReq)
            {
                if (conveyor4.carrier.id != 0)
                {
                    conveyorS.carrier.id = conveyor4.carrier.id;
                    conveyorS.carrier.source = conveyor4.carrier.source;
                    conveyorS.carrier.dest = conveyor4.carrier.dest;
                    conveyorS.carrier.use = conveyor4.carrier.use;
                    conveyor4.carrier.Clear();

                    Debug.Log("Carrier Data Move : 4 ->S");             //데이타 확인 로그
                }
            }
        }
    }   
}
