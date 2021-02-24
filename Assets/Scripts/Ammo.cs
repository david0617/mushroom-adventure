using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int timer;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timer);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemy = other.gameObject.GetComponent<EnemyHealth>();
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();

        if (enemy != null)
        {
            enemy.KillEnemy();
            Destroy(gameObject);
        }
        else if (player == null && other != GameObject.FindGameObjectWithTag("backGround"))
        {
            Destroy(gameObject);
        }

    }
}
