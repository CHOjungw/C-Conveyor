using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCarrier : MonoBehaviour
{
    public UInt64 id;
    public UInt16 source;               //������� ����
    public UInt16 dest;             //������ ����
    public USE use;                 //����,���� ���� Ȯ�� ����    
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
