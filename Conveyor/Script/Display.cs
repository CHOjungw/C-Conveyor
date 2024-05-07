using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Display : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private int delayTime;
    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.root.tag == "Conveyor1")
        {
            Conveyor1 conveyor1 = transform.root.GetComponent<Conveyor1>();            
            if(conveyor1.statusCcw)
            {
                ToggleDisplayCCW();
            }
            else if (conveyor1.statusCw)
            {
                ToggleDisplayCW();
            }
            else
            {
                textMeshPro.text = "";
            }
        }    
        else if (transform.root.tag == "Conveyor2")
        {
            Conveyor2 conveyor2 = transform.root.GetComponent<Conveyor2>();
            if (conveyor2.statusCcw)
            {
                ToggleDisplayCCW();
            }
            else if (conveyor2.statusCw)
            {
                ToggleDisplayCW();
            }
            else
            {
                textMeshPro.text = "";
            }
        }
        else if (transform.root.tag == "Conveyor3")
        {
            Conveyor3 conveyor3 = transform.root.GetComponent<Conveyor3>();
            if (conveyor3.statusCcw)
            {
                ToggleDisplayCCW();
            }
            else if (conveyor3.statusCw)
            {
                ToggleDisplayCW();
            }
            else
            {
                textMeshPro.text = "";
            }
        }
        else if (transform.root.tag == "Conveyor4")
        {
            Conveyor4 conveyor4 = transform.root.GetComponent<Conveyor4>();
            if (conveyor4.statusCcw)
            {
                ToggleDisplayCCW();
            }
            else if (conveyor4.statusCw)
            {
                ToggleDisplayCW();
            }
            else
            {
                textMeshPro.text = "";
            }
        }
        else if (transform.root.tag == "ConveyorS")
        {
            ConveyorS conveyorS = transform.root.GetComponent<ConveyorS>();
            if (conveyorS.statusCcw)
            {
                ToggleDisplayCCW();             
            }
            else if (conveyorS.statusCw)
            {
                ToggleDisplayCW();
            }
            else
            {
                textMeshPro.text = "";
            }           
        }
    }
    private void ToggleDisplayCCW()
    {
        delayTime++;
        if (delayTime < 20)
            textMeshPro.text = "CCW\n< < < <";
        else if (20 <= delayTime && delayTime < 40)
            textMeshPro.text = "CCW\n < < < <";
        else delayTime = 0;
        
    }
    private void ToggleDisplayCW()
    {
        delayTime++;
        if (delayTime < 20)
            textMeshPro.text = "CW\n> > > >";
        else if (20 <= delayTime && delayTime < 40)
            textMeshPro.text = "CW\n > > > >";
        else delayTime = 0;
    }
}
