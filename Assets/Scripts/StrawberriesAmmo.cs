using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawberriesAmmo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();

        if (ph == null && other != GameObject.FindGameObjectWithTag("backGround"))
        {
            Destroy(gameObject);
        }
    }
}
