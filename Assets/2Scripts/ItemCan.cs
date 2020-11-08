using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCan : MonoBehaviour
{
    public float rotateSpeed;
   

    private void Awake()
    {
        
    }

    void Update()   
    {
        transform.Rotate(Vector3.up * rotateSpeed* Time.deltaTime, Space.World); //업데이트에서 움직이면 델타타임 사용해야함.
    }
  
}
