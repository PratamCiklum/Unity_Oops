using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float speed;
    public int health;
    // Start is called before the first frame update


    public virtual void MoveForward()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            Die();
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Enemy Bullet"))
        {
            gameObject.SetActive(false);
        }
        if (!other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public virtual void Update()
    {
        MoveForward();
    }



    public abstract void Attack();
}


