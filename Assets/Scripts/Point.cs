using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public int point;
    public GameObject effect;

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
            Instantiate(effect, gameObject.transform.position, gameObject.transform.rotation);
            pd.Add(point);
        }
    }
}
