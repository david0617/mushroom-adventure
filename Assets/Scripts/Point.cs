using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public int point;

    private void Update()
    {
        gameObject.transform.Rotate(0, 0.3f, 0, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        PointDisplay pd = other.gameObject.GetComponent<PointDisplay>();

        if (pd != null)
        {
            Destroy(gameObject);
            pd.Add(point);
        }
    }
}
