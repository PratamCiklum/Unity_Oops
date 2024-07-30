using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Enemy
{
    private ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        InvokeRepeating("Attack", 1f, 1f);
    }


    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Player"))
        {
            CancelInvoke("Attack"); // Cancel attack invocation when Shooter is hit
        }
    }
    public override void Attack()
    {
            objectPooler.SpawnFromPool("Enemy Bullet", new Vector3(transform.position.x,transform.position.y-0.43f,transform.position.z), transform.rotation);
    }

    private void OnDisable()
    {
        CancelInvoke("Attack");
    }
}
