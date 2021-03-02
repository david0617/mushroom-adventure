using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Animation enemyAnimtion;
    public float speed;
    private bool right;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimtion = gameObject.GetComponent<Animation>();
        right = true;
        gameObject.transform.Rotate(0, 180, 0, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        move();

        if (enemyAnimtion.isPlaying == false)
        {
            enemyAnimtion.Play("Run");
        }
    }

    private void move()
    {
        position = transform.position;

        if (right == false)
        {
            position.z -= 0.1f * speed;
        }
        else
        {
            position.z += 0.1f * speed;
        }

        gameObject.transform.position = position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (right == false)
        {
            right = true;
            gameObject.transform.Rotate(0, 180, 0, Space.Self);
        }
        else
        {
            right = false;
            gameObject.transform.Rotate(0, -180, 0, Space.Self);
        }
    }
}
