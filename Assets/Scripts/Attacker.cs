using UnityEngine;

public class Attacker : Enemy
{
    private Vector3 directionToPlayer;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        directionToPlayer = (player.transform.position - transform.forward).normalized;
        directionToPlayer.z = 0;
    }
    public override void Update()
    {
        Attack();
    }
    public override void Attack()
    {
       
        if (transform.position.y > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.05f);
            directionToPlayer = (player.transform.position- transform.position).normalized;
            directionToPlayer.z = 0;
        }
        else
        {
            transform.position += directionToPlayer * speed * Time.deltaTime;
        }
    }
}
