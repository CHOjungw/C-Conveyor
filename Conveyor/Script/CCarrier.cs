using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCarrier : MonoBehaviour
{
    public UInt64 id;
    public UInt16 source;               //출발지점 변수
    public UInt16 dest;             //목적지 변수
    public USE use;                 //저장,반출 유무 확인 변수    
    public enum USE
    {
        USE_NONE,
        USE_TAKEOUT,
        USE_STACK
    }
    public void Clear()
    {
        id = 0;
        source = 0;
        dest = 0;
        use = USE.USE_NONE;
    }
    void Start()
    {        
    }
    void Update()
    {

    }
}
