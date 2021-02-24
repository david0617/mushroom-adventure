using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeS, timeM;
    private string timeStringS, timeStringM;
    public Text timeDisplay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Times());
    }

    // Update is called once per frame
    void Update()
    {
        timeStringS = timeS.ToString();
        timeStringM = timeM.ToString();

        timeDisplay.text = timeStringM + ":" + timeStringS;
    }

    private IEnumerator Times()
    {
        yield return new WaitForSeconds(1);
        timeS--;
        if (timeS == -1)
        {
            timeM--;
            timeS = 59;
        }
        StartCoroutine(Times());
    }
}
