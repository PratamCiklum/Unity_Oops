using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 2;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }
}
