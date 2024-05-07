using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TAKEIN : MonoBehaviour
{
    public Button takeIn;
    public Button Box1Create, Box2Create,Box3Create;
    public GameObject objectBox1, objectBox2, objectBox3;
    public Conveyor2 conveyor2;
    private bool boxCreated = false;
    public void newObject1()
    {
        DestroyBox();
        GameObject addedObject = (GameObject)Instantiate(objectBox1, new Vector3(-0.08f, 0.01f, 0), Quaternion.identity);
        Destroy(addedObject, 100f);
        conveyor2.takeIn = true;
    }
    public void newObject2()
    {
        DestroyBox();
        GameObject addedObject = (GameObject)Instantiate(objectBox2, new Vector3(-0.08f, 0.01f, 0), Quaternion.identity);
        Destroy(addedObject, 100f);

        conveyor2.takeIn = true;     
    }
    public void newObject3()
    {
        DestroyBox();
        GameObject addedObject = (GameObject)Instantiate(objectBox3, new Vector3(-0.08f, 0.01f, 0), Quaternion.identity);
        Destroy(addedObject, 100f);

        conveyor2.takeIn = true;      
    }
    public void CreateBox()
    {
        if (!boxCreated)
        {
            Box1Create.gameObject.SetActive(true);
            Box2Create.gameObject.SetActive(true);
            Box3Create.gameObject.SetActive(true);
            boxCreated = true;
        }
        else 
        { 
            DestroyBox();            
        }
    }
    public void DestroyBox()
    {
        Box1Create.gameObject.SetActive(false);
        Box2Create.gameObject.SetActive(false);
        Box3Create.gameObject.SetActive(false);
        boxCreated = false;
    }
    void Start()
    {
        conveyor2 =GameObject.Find("컨베이어2").GetComponent<Conveyor2>();
        takeIn = GetComponent<Button>();
        takeIn.onClick.AddListener(CreateBox);  
        Box1Create.onClick.AddListener(newObject1);
        Box2Create.onClick.AddListener(newObject2);
        Box3Create.onClick.AddListener(newObject3);
        Box1Create.gameObject.SetActive(false);
        Box2Create.gameObject.SetActive(false);
        Box3Create.gameObject.SetActive(false);
    }
    
    void Update()
    {
        if (conveyor2.GetSensorState2()==true)
        {
            conveyor2.takeIn = false;
        }
    }
}
