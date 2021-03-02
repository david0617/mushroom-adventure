using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int life;
    public GameObject Respawn, basePlayer, levelUpPlayer;
    public Text lifeDisplay;
    public string sceneName;
    public bool isRespawn;
    private string lifeString;
    public int reSpawn = 0;
    private bool levelUp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnPlayer(bool Void)
    {
        if (levelUp == false || Void == true)
        {
            if (reSpawn > 0)
            {
                return;
            }
            reSpawn = 20;
            Debug.Log("reSpawn!!!!!!!!!! -> " + reSpawn);
            life--;

            lifeString = life.ToString();
            lifeDisplay.text = "Life:" + lifeString;

            if (life == 0)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            StartCoroutine(LevelDown());
        }
    }

    void LateUpdate()
    {
        if (reSpawn > 0)
        {
            StartCoroutine(LevelDown());
            gameObject.transform.position = Respawn.transform.position;
        }
        reSpawn--;
    }

    public void LevelUp()
    {
        levelUp = true;
        basePlayer.SetActive(false);
        levelUpPlayer.SetActive(true);
    }

    private IEnumerator LevelDown()
    {
        levelUp = false;

        basePlayer.SetActive(true);
        levelUpPlayer.SetActive(false);
        yield return new WaitForSeconds(3);
    }
}
