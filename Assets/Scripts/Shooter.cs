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
    // Start is called before the first frame update

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    public override void Attack()
    {
        objectPooler.SpawnFromPool("Sphere",transform.position,transform.rotation,Vector3.down);
    }
}
