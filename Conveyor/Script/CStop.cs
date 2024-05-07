using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class CStop : MonoBehaviour
{
    public Button stop;
    public Conveyor1 conveyor1;
    public Conveyor2 conveyor2;
    public Conveyor3 conveyor3;
    public Conveyor4 conveyor4;
    public ConveyorS conveyorS;

    void Start()
    {
        conveyor1 = GameObject.Find("컨베이어1").GetComponent<Conveyor1>();
        conveyor2 = GameObject.Find("컨베이어2").GetComponent<Conveyor2>();
        conveyor3 = GameObject.Find("컨베이어3").GetComponent<Conveyor3>();
        conveyor4 = GameObject.Find("컨베이어4").GetComponent<Conveyor4>();
        conveyorS = GameObject.Find("컨베이어S").GetComponent<ConveyorS>();

        stop = GetComponent<Button>();
        stop.onClick.AddListener(ConvStop);

    }
    public void ConvStop()
    {
        Debug.Log("Stop되었음");
        conveyor1.start = false;
        conveyor2.start = false;
        conveyor3.start = false;
        conveyor4.start = false;
        conveyorS.start = false;
    }

    void Update()
    {
        
    }
}
