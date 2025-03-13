using System;
using UnityEngine;
//using NUnit
using System.Collections.Generic;

public class GravityG : MonoBehaviour
{
    Rigidbody RB;
    const float G = 0.006674f;
    public static List<GravityG> otherObjectList;

    public bool planets = false;
    public int orbetSpeed = 1000;
    
    
    void Awake()
    {
        RB = GetComponent<Rigidbody>();
        if (otherObjectList == null)
        {
            otherObjectList = new List<GravityG>();
        }    
        
        otherObjectList.Add(this);


        if (!planets)
        {
            RB.AddForce(Vector3.left * orbetSpeed);
        }
        
    }

    private void FixedUpdate()
    {
        foreach (var obj in otherObjectList)
        {
            if (obj != this)
            {
                Attract(obj);    
            }
            
        }
    }

    void Attract(GravityG other)
    {
        Rigidbody otherRb = other.RB;
        Vector3 direction = RB.position - otherRb.position;
        float distance = direction.magnitude;
        
        float forceMagnitude = G * (RB.mass * otherRb.mass) / Mathf.Pow(distance, 2);
        
        Vector3 finalForce = forceMagnitude * direction.normalized;
        
        otherRb.AddForce(finalForce);
        


    }
}
