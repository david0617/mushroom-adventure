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
        PointDisplay pd = other.gameObject.GetComponent<PointDisplay>();

        if (ph != null)
        {
            lastSceneName = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("lastScene", lastSceneName);
            PlayerPrefs.SetInt("point", pd.point);
            SceneManager.LoadScene(sceneName);
        }
    }
}
