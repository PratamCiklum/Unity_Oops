using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //[SerializeField] List<GameObject> enemy;
    //private int count = 2;
    private ObjectPooler objectPooler;
    [SerializeField] float xRange;
    [SerializeField] float yPos;
    private string[] enemyTag = { "Attacker", "Shooter" };
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        string enemyT = enemyTag[Random.Range(0, enemyTag.Length)];
        Debug.Log(enemyT);
        StartCoroutine(SpawnEnemy());
        //InvokeRepeating("SpawnEnemy", 1f, 3f);
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            //int index = Random.Range(0, count);
            float xPos = Random.Range(-xRange, xRange);
            Vector3 enemyPos = new Vector3(xPos, yPos, 0);
            string enemyT = enemyTag[Random.Range(0, enemyTag.Length)];
            objectPooler.SpawnFromPool(enemyT, enemyPos, Quaternion.identity, Vector3.down);
            yield return new WaitForSeconds(2.5f);
        }
    }


    // Update is called once per frame

}
