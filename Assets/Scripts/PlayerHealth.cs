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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeString = life.ToString();
        lifeDisplay.text = "Life: " + lifeString; 
    }

    public void RespawnPlayer()
    {
        life--; 
        gameObject.transform.position = Respawn.transform.position;
        KillPlayer gameVoid = GameObject.Find("Void").GetComponent<KillPlayer>();
        gameVoid.respawn = true;
    }
}
