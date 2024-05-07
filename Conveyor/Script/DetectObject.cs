using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObject : MonoBehaviour
{
   
    MeshRenderer renderer;

    [SerializeField] Material Green;
    [SerializeField] Material Blue;

    public bool blsdetectSensor1, blsdetectSensor2;
    void Start()
    {        
        renderer = GetComponent<MeshRenderer>();       
        if (transform.root == null)
            Debug.Log("부모의 오브젝트가 없습니다");       
    }
    void Update()
    {
        if (transform.root.tag == "Conveyor1")
        {
            Conveyor1 conveyor1 = transform.root.GetComponent<Conveyor1>();
            blsdetectSensor1 = conveyor1.GetSensorState1();
            blsdetectSensor2 = conveyor1.GetSensorState2();
        }
        else if (transform.root.tag == "Conveyor2")
        {
            Conveyor2 conveyor2 = transform.root.GetComponent<Conveyor2>();
            blsdetectSensor1 = conveyor2.GetSensorState1();            
            blsdetectSensor2 = conveyor2.GetSensorState2();
        }
        else if (transform.root.tag == "Conveyor3")
        {
            Conveyor3 Conveyor3 = transform.root.GetComponent<Conveyor3>();
            blsdetectSensor1 = Conveyor3.GetSensorState1();
            blsdetectSensor2 = Conveyor3.GetSensorState2();
        }
        else if (transform.root.tag == "Conveyor4")
        {
            Conveyor4 Conveyor4 = transform.root.GetComponent<Conveyor4>();
            blsdetectSensor1 = Conveyor4.GetSensorState1();
            blsdetectSensor2 = Conveyor4.GetSensorState2();
        }
        else if (transform.root.tag == "ConveyorS")
        {
            ConveyorS ConveyorS = transform.root.GetComponent<ConveyorS>();
            blsdetectSensor1 = ConveyorS.GetSensorState1();
            blsdetectSensor2 = ConveyorS.GetSensorState2();
        }
        if (transform.name == "LED:1" || transform.name == "LED:3")
        {
            if (blsdetectSensor1)
            {
                renderer.material = Blue;
            }
            else
            {
                renderer.material = Green;
            }
        }
        else if (transform.name == "LED:2"||transform.name == "LED:4")
        {
            if (blsdetectSensor2)
            {
                renderer.material = Blue;
            }
            else
            {
                renderer.material = Green;
            }
        }
        
    }
}
