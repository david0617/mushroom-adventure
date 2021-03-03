using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string sceneName;
    private string lastSceneName;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();

        if (ph != null)
        {
            lastSceneName = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("lastScene", lastSceneName);
            SceneManager.LoadScene(sceneName);
        }
    }
}
