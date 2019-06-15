using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTrash : MonoBehaviour
{

    // public GameObject[] garbages;
    // public float spawnTime = 3f;
    // private Vector3 spawnPosition;
    // int randEnemy;
    // public bool stop;

    // // Use this for initialization
    // void Start()
    // {
    //     stop = false;
    //     while(!stop)
    //     {
    //         InvokeRepeating("Spawn", spawnTime, spawnTime);
    //     }


    // }

    // void Spawn()
    // {
    //     spawnPosition.x = Random.Range(-16, 16);
    //     spawnPosition.y = 8f;
    //     spawnPosition.z = 1;
    //     randEnemy = Random.Range(0, 5);

    //     Instantiate(garbages[randEnemy], spawnPosition, Quaternion.identity);
    // }



    //int spawnTime = 3;
    //GameObject spawn = GameObject.Find("Spawn");
    public GameObject[] garbages;
    public Vector3 spawnValue;
    public float spawnWait;
    public int startWait;
    public float spawnMostWait;
    public int spawnLeastWait;
    


    int randEnemy;



    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
       spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }
    IEnumerator waitSpawner()
    {
       yield return new WaitForSeconds(startWait);

       while(!Variables.stop)
       {
           randEnemy = Random.Range(0, 5);

           Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), 11f, 1);

           Instantiate(garbages[randEnemy], spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);

           yield return new WaitForSeconds(spawnWait);
       }
    }

}
