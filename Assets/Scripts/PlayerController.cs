using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    private ObjectPooler objectPooler;
    private float xRange = 3.85f;
    private float yPos = -2;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovemnt();
        ShootBullets();
    }

    void ShootBullets()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            objectPooler.SpawnFromPool("Player Bullet", new Vector3(transform.position.x, transform.position.y + 0.43f, transform.position.z), transform.rotation);
        }
    }

    void UpdateMovemnt()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float HorizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.right * HorizontalInput * speed * Time.deltaTime);
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        }
        else if (transform.position.y < yPos)
        {
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

        }
    }
}
