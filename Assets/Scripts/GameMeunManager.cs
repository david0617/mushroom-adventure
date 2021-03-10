using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMeunManager : MonoBehaviour
{
    public string sceneName;
    private string lastScene;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void StartingScene()
    {
        PlayerPrefs.SetInt("point", 0);
        SceneManager.LoadScene(sceneName);
        Debug.Log("start");
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void ReplayLevel()
    {
        lastScene = PlayerPrefs.GetString("lastScene");

        SceneManager.LoadScene(lastScene);

        Debug.Log("replay");
    }
}
