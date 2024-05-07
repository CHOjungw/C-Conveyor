using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    Collider sensor;
    private bool ON = true;
    private bool OFF = false;
    private int delatTime = 0;
    
    void Start()
    {      

    }    
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (transform.root.tag == "Conveyor1")
        {
            Conveyor1 conveyor1 = transform.root.GetComponent<Conveyor1>();

            if (transform.parent.name == "LED:1" || transform.parent.name == "LED:3")
            {

                delatTime++;
                if (delatTime == 12)
                {
                    conveyor1.SetSensorState1(ON);
                    delatTime = 0;
                }
            }
            else if (transform.parent.name == "LED:2" || transform.parent.name == "LED:4")
            {
                delatTime++;
                if (delatTime == 12)
                {

                    conveyor1.SetSensorState2(ON);

                    delatTime = 0;
                }
            }
        }
        else if (transform.root.tag == "Conveyor2")
        {           
            Conveyor2 conveyor2 = transform.root.GetComponent<Conveyor2>();
            
            if (transform.parent.name == "LED:1" || transform.parent.name == "LED:3")
            {
                
                delatTime++;
                if (delatTime == 12)
                {                    
                    conveyor2.SetSensorState1(ON);
                    delatTime = 0;
                }                
            }
            else if(transform.parent.name == "LED:2" || transform.parent.name == "LED:4")
            {
                delatTime++;
                if (delatTime == 12)
                {
                    
                    conveyor2.SetSensorState2(ON);
                    
                    delatTime = 0;
                }                
            }
        }
        else if (transform.root.tag == "Conveyor3")
        {
            Conveyor3 conveyor3 = transform.root.GetComponent<Conveyor3>();
            if (transform.parent.name == "LED:1" || transform.parent.name == "LED:3")
            {
                delatTime++;
                if (delatTime == 12)
                {
                    conveyor3.SetSensorState1(ON);
                    delatTime = 0;
                }                
            }
            else if (transform.parent.name == "LED:2" || transform.parent.name == "LED:4")
            {
                delatTime++;
                if (delatTime == 12)
                {
                    conveyor3.SetSensorState2(ON);
                    delatTime = 0;
                }                
            }
        }
        else if (transform.root.tag == "Conveyor4")
        {
            Conveyor4 conveyor4 = transform.root.GetComponent<Conveyor4>();
            if (transform.parent.name == "LED:1" || transform.parent.name == "LED:3")
            {
                delatTime++;
                if (delatTime == 12)
                {
                    conveyor4.SetSensorState1(ON);
                    delatTime = 0;
                }                
            }
            else if (transform.parent.name == "LED:2" || transform.parent.name == "LED:4")
            {
                delatTime++;
                if (delatTime == 12)
                {
                    conveyor4.SetSensorState2(ON);
                    delatTime = 0;
                }                
            }
        }
        else if (transform.root.tag == "ConveyorS")
        {
            ConveyorS conveyorS = transform.root.GetComponent<ConveyorS>();
            if (transform.parent.name == "LED:1" || transform.parent.name == "LED:3")
            {
                delatTime++;
                if (delatTime == 12)
                {
                    conveyorS.SetSensorState1(ON);
                    delatTime = 0;
                }                
            }
            else if (transform.parent.name == "LED:2" || transform.parent.name == "LED:4")
            {
                delatTime++;
                if (delatTime == 12)
                {
                    conveyorS.SetSensorState2(ON);
                    delatTime = 0;
                }                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (transform.root.tag == "Conveyor1")
        {
            Conveyor1 conveyor1 = transform.root.GetComponent<Conveyor1>();
            if (transform.parent.name == "LED:1" || transform.parent.name == "LED:3")
            {
                conveyor1.SetSensorState1(OFF);
                Destroy(other.gameObject);
            }
            else if (transform.parent.name == "LED:2" || transform.parent.name == "LED:4")
            {
                conveyor1.SetSensorState2(OFF);
            }
        }
        else if (transform.root.tag == "Conveyor2")
        {
            Conveyor2 conveyor2 = transform.root.GetComponent<Conveyor2>();
            if (transform.parent.name == "LED:1" || transform.parent.name == "LED:3")
            {             
                conveyor2.SetSensorState1(OFF);                            
            }
            else if(transform.parent.name == "LED:2" || transform.parent.name == "LED:4")
            {                
                conveyor2.SetSensorState2(OFF);               
            }
        }
        else if (transform.root.tag == "Conveyor3")
        {
            Conveyor3 conveyor3 = transform.root.GetComponent<Conveyor3>();
            if (transform.parent.name == "LED:1" || transform.parent.name == "LED:3")
            {               
                conveyor3.SetSensorState1(OFF);                                
            }
            else if (transform.parent.name == "LED:2" || transform.parent.name == "LED:4")
            {                
                conveyor3.SetSensorState2(OFF);                                
            }
        }
        else if (transform.root.tag == "Conveyor4")
        {
            Conveyor4 conveyor4 = transform.root.GetComponent<Conveyor4>();
            if (transform.parent.name == "LED:1" || transform.parent.name == "LED:3")
            {                
                conveyor4.SetSensorState1(OFF);                                
            }
            else if (transform.parent.name == "LED:2" || transform.parent.name == "LED:4")
            {                
                conveyor4.SetSensorState2(OFF);                                
            }
        }
        else if (transform.root.tag == "ConveyorS")
        {
            ConveyorS conveyorS = transform.root.GetComponent<ConveyorS>();
            if (transform.parent.name == "LED:1" || transform.parent.name == "LED:3")
            {                
               conveyorS.SetSensorState1(OFF);                                 
            }
            else if (transform.parent.name == "LED:2" || transform.parent.name == "LED:4")
            {                
               conveyorS.SetSensorState2(OFF);                                 
            }
        }
    }
}
