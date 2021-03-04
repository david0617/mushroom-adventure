using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public GameObject spawn, ammo, strawberries;
    public float fireingTimer;
    public float speed;
    public Text foodDisplay;
    private string foodString;
    private int foodCount = 0;
    private PlayerMovement player;
    private bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerMovement>();

        foodString = foodCount.ToString();
        foodDisplay.text = "Strawberries:" + foodString + "/10";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && canFire)
        {
            GameObject ammoObj = Instantiate(ammo, spawn.transform.position, gameObject.transform.rotation);
            ammoObj.GetComponent<Rigidbody>().AddForce(spawn.transform.forward * speed, ForceMode.Acceleration);

            StartCoroutine(FireTimer(fireingTimer));
        }
        else if (Input.GetButton("Fire2") && canFire && foodCount > 0)
        {
            GameObject strawberriesObj = Instantiate(strawberries, spawn.transform.position, gameObject.transform.rotation);
            strawberriesObj.GetComponent<Rigidbody>().AddForce(spawn.transform.forward * speed, ForceMode.Acceleration);

            StartCoroutine(FireTimer(0.5f));

            foodCount--;

            foodString = foodCount.ToString();
            foodDisplay.text = "Strawberries:" + foodString + "/10";
        }

    }

    void Shoot(GameObject side)
    {
        GameObject ammoObj = Instantiate(ammo, side.transform.position, gameObject.transform.rotation);
        ammoObj.GetComponent<Rigidbody>().AddForce(side.transform.forward * speed, ForceMode.Acceleration);
    }

    private IEnumerator FireTimer(float time)
    {
        canFire = false;
        yield return new WaitForSeconds(time);
        canFire = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "food")
        {
            foodCount++;

            Debug.Log(foodCount);

            if (foodCount > 10)
            {
                foodCount = 10;
            }

            foodString = foodCount.ToString();
            foodDisplay.text = "Strawberries:" + foodString + "/10";
        }
    }
}
