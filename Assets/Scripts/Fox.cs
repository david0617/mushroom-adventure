using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fox : MonoBehaviour
{
    public int foodFeed = 0, foodNeed;
    public Text foodFeedDisplay;
    public float timer;
    public GameObject[] effect;
    public GameObject fox;
    private string foodFeedString, foodNeedString;
    private Animator animator;


    void Start()
    {
        animator = fox.GetComponent<Animator>();

        foodNeedString = foodNeed.ToString();
        foodFeedString = foodFeed.ToString();
        foodFeedDisplay.text = "Food Feed:" + foodFeedString + "/" + foodNeedString;
    }

    void OnTriggerEnter(Collider other)
    {
        StrawberriesAmmo sa = other.GetComponent<StrawberriesAmmo>();
        PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();

        if (sa != null)
        {
            foodFeed++;

            foodFeedString = foodFeed.ToString();
            foodFeedDisplay.text = "Food Feed:" + foodFeedString + "/" + foodNeedString;

            if (foodFeed == foodNeed)
            {
                StartCoroutine(time(timer));
            }
        }
        else if (ph != null)
        {
            Animation animation = gameObject.GetComponent<Animation>();
            EnemyMove move = gameObject.GetComponent<EnemyMove>();

            animator.SetTrigger("Attack");

            ph.RespawnPlayer(false);
        }
    }

    IEnumerator time(float time)
    {
        Instantiate(effect[0], effect[1].transform.position, effect[1].transform.rotation);

        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
