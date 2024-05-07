using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TAKEOUT : MonoBehaviour
{
    public Button takeOut;
    public Button Conveyor3TOut, Conveyor4TOut;    
    public Conveyor3 conveyor3;
    public Conveyor4 conveyor4;
    private bool boxCreated = false;
    public void conv3UseTakeOut()
    {
        DestroyBox();
        conveyor3.carrier.use = CCarrier.USE.USE_TAKEOUT;
    }
    public void conv4UseTakeOut()
    {
        DestroyBox();
        conveyor4.carrier.use = CCarrier.USE.USE_TAKEOUT;
    }   
    public void CreateBox()
    {
        if (!boxCreated)
        {
            Conveyor3TOut.gameObject.SetActive(true);
            Conveyor4TOut.gameObject.SetActive(true);
            boxCreated = true;
        }
        else
        {
            DestroyBox();            
        }
        
    }
    public void DestroyBox()
    {
        Conveyor3TOut.gameObject.SetActive(false);
        Conveyor4TOut.gameObject.SetActive(false);
        boxCreated = false;
    }
    void Start()
    {
        conveyor3 = GameObject.Find("컨베이어3").GetComponent<Conveyor3>();
        conveyor4 = GameObject.Find("컨베이어4").GetComponent<Conveyor4>();
        takeOut = GetComponent<Button>();
        takeOut.onClick.AddListener(CreateBox);
        Conveyor3TOut.onClick.AddListener(conv3UseTakeOut);
        Conveyor4TOut.onClick.AddListener(conv4UseTakeOut);
        Conveyor3TOut.gameObject.SetActive(false);
        Conveyor4TOut.gameObject.SetActive(false);
    }
    void Update()
    {
        
    }
}
