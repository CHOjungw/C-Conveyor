using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControl : MonoBehaviour
{
    ConveyorS conveyorS;
    public Transform MovePoint1, MovePoint2;
    public bool compt;
    GameObject conveyorSOb;
    void Start()
    {
        conveyorS = GameObject.Find("컨베이어S").GetComponent<ConveyorS>();
        
    }

    
    void Update()
    {
        conveyorSOb = GameObject.Find("컨베이어S");
        conveyorS.CurrentPosition = conveyorS.TargetPosition;
        motionControl(conveyorSOb);
    }
    public void motionControl(GameObject conveyor)
    {
        compt = false;
        switch(conveyorS.TargetPosition)
        {
            case ConveyorS.SERVO_POS.CONV1:
                conveyor.transform.position = Vector3.MoveTowards(conveyor.transform.position, MovePoint1.position, 0.1f * Time.deltaTime);                
                if(conveyor.transform.position == MovePoint1.position)
                {
                    compt = true;
                }
                break;
            case ConveyorS.SERVO_POS.CONV2:
                conveyor.transform.position = Vector3.MoveTowards(conveyor.transform.position, MovePoint2.position, 0.1f * Time.deltaTime);                
                if (conveyor.transform.position == MovePoint2.position)
                {
                    compt = true;
                }
                break;
            case ConveyorS.SERVO_POS.CONV3:
                conveyor.transform.position = Vector3.MoveTowards(conveyor.transform.position, MovePoint1.position, 0.1f * Time.deltaTime);                
                if (conveyor.transform.position == MovePoint1.position)
                {
                    compt = true;
                }
                break;
            case ConveyorS.SERVO_POS.CONV4:
                conveyor.transform.position = Vector3.MoveTowards(conveyor.transform.position, MovePoint2.position, 0.1f * Time.deltaTime);                
                if (conveyor.transform.position == MovePoint2.position)
                {
                    compt = true;
                }
                break;
        }        
        conveyorS.CurrentPosition = conveyorS.TargetPosition;
        
    }
}
