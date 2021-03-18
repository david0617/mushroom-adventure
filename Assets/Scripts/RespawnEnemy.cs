using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{
    public GameObject enemyType;
    PlayerHealth ph;

    // Start is called before the first frame update
    void Start()
    {
        ph = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        if (ph.reSpawn == 0 )
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
            GameObject[] enemyRespawnPoint = GameObject.FindGameObjectsWithTag("enemyRespawn");

            foreach (GameObject enemy in enemys)
            {
                Destroy(enemy);
            }

            foreach (GameObject enemyRespawn in enemyRespawnPoint)
            {
                GameObject enemyObj = Instantiate(enemyType, enemyRespawn.transform.position, enemyRespawn.transform.rotation);
            }
        }
    }
}
