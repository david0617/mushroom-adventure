using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int life;
    public GameObject Respawn;
    public Text lifeDisplay;
    private string lifeString;
    public int reSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeString = life.ToString();
        lifeDisplay.text = "Life: " + lifeString;

      //  gameObject.transform.position = Respawn.transform.position;
    }

    public void RespawnPlayer()
    {
        if (reSpawn > 0)
        {
            return;
        }
        reSpawn = 20;
        life--; 
    }

    void LateUpdate()
    {
        if (reSpawn > 0)
        {
            gameObject.transform.position = Respawn.transform.position;
        }
        reSpawn--;
    }
}
