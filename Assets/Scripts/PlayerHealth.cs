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
    public bool isRespawn;
    private string lifeString, lastSceneName;
    public int reSpawn = 0;
    public bool levelUp;

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
                lastSceneName = SceneManager.GetActiveScene().name;
                PlayerPrefs.SetString("lastScene", lastSceneName);
                SceneManager.LoadScene("GameOver");
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
