using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Bullets : MonoBehaviour
{
    protected float bulletSpeed = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        MoveForward();
    }



    protected virtual void MoveForward() 
    { 
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }
}
