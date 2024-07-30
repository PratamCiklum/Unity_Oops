using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullets
{
    // Start is called before the first frame update
    protected override void FixedUpdate()
    {
        //base.FixedUpdate();
        MoveForward();
    }
    protected override void MoveForward()
    {
        //base.MoveForward();
        transform.Translate(Vector3.down * bulletSpeed * Time.deltaTime);

    }
}
