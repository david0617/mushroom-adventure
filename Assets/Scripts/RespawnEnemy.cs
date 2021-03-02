using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{
    public GameObject[] enemyRespawnPoint;
    public GameObject enemy;
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
        if (ph.reSpawn == 0)
        {
            foreach (GameObject respawnPoint in enemyRespawnPoint)
            {
                GameObject enemyObj = Instantiate(enemy, respawnPoint.transform.position, respawnPoint.transform.rotation);
            }
        }
    }
}
