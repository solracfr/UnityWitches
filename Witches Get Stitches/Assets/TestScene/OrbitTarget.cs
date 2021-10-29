using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrbitTarget : MonoBehaviour
{
    int[] array = {3,2,3};
    public Transform target;
    public float speed;

    void Start()
    {
        
        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(transform.right * Time.deltaTime * speed, target); 
    }

    private void PrintArray()
    {
        var newArray = array.OrderBy(x => x).ToArray();
        foreach(int num in newArray)
        {
            Debug.Log(num);
        }
    }
}
