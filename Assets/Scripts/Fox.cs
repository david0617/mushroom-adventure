using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fox : MonoBehaviour
{
    public int foodFeed = 0;
    public Text foodFeedDisplay;
    private string foodFeedString;

    void OnTriggerEnter(Collider other)
    {
        StrawberriesAmmo sa = other.GetComponent<StrawberriesAmmo>();
        PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();

        if (sa != null)
        {
            foodFeed++;

            foodFeedString = foodFeed.ToString();
            foodFeedDisplay.text = "Food Feed:" + foodFeedString + "/10";

            if (foodFeed == 10)
            {
                Destroy(gameObject);
            }
        }
        else if (ph != null)
        {
            Animation animation = gameObject.GetComponent<Animation>();
            EnemyMove move = gameObject.GetComponent<EnemyMove>();

            ph.RespawnPlayer(false);
        }
    }
}
