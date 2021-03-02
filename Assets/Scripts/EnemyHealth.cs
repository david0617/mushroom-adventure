using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int point;
    Animation animation;
    public GameObject[] drop;

    // Start is called before the first frame update
    void Start()
    {
        animation = gameObject.GetComponent<Animation>();
    }

    public void KillEnemy()
    {
        Destroy(gameObject);

        System.Random R1 = new System.Random();
        int x = R1.Next(0, 99);

        Vector3 position = gameObject.transform.position;
        position.y += 2;

        Debug.Log(x);

        if (x >= 35 && x <= 99)
        {
            Instantiate(drop[0], position, Quaternion.identity);
        }
        else if (x >= 0 && x <= 19)
        {
            Instantiate(drop[1], position, Quaternion.identity);
        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<PointDisplay>().Add(point);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();

        if (ph != null)
        {
            Animation animation = gameObject.GetComponent<Animation>();
            EnemyMove move = gameObject.GetComponent<EnemyMove>();

            animation.Play("Attack");
            ph.RespawnPlayer(false);
        }
    }
}
