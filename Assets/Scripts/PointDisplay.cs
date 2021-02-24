using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointDisplay : MonoBehaviour
{
    public Text pointDisplay;
    private int point;
    private string pointString;

    // Start is called before the first frame update
    void Start()
    {
        point = 0;
        pointString = point.ToString();
        pointDisplay.text = "point: " + pointString;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(int addPoint)
    {
        point += addPoint;
        pointString = point.ToString();
        pointDisplay.text = "point: " + pointString;
    }
}
