using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public GameObject strawberries;
    public GameObject[] spawn, ammo;
    public float fireingTimer, speed;
    public int foodBagSize;
    public Text foodDisplay;
    private string foodString, foodBagSizeString;
    private int foodCount = 0;
    private PlayerMovement pm;
    private PlayerHealth ph;
    private bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        pm = playerObj.GetComponent<PlayerMovement>();

        ph = playerObj.GetComponent<PlayerHealth>();

        foodString = foodCount.ToString();
        foodBagSizeString = foodBagSize.ToString();
        foodDisplay.text = "Strawberries:" + foodString + "/" + foodBagSizeString;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && canFire)
        {
            if (ph.levelUp == false)
            {
                ShootAmmo(spawn[0], ammo[0]);
            }
            else if (ph.levelUp == true)
            {
                ShootAmmo(spawn[1], ammo[1]);
            }

            StartCoroutine(FireTimer(fireingTimer));
        }
        else if (Input.GetButton("Fire2") && canFire && foodCount > 0)
        {
            if (ph.levelUp == false)
            {
                ShootAmmostrawberries(spawn[0]);
            }
            else if (ph.levelUp == true)
            {
                ShootAmmostrawberries(spawn[1]);
            }

            StartCoroutine(FireTimer(0.5f));

            foodCount--;

            foodString = foodCount.ToString();

            foodDisplay.text = "Strawberries:" + foodString + "/" + foodBagSizeString;
        }

    }

    void ShootAmmo(GameObject side, GameObject ammo)
    {
        GameObject ammoObj = Instantiate(ammo, side.transform.position, gameObject.transform.rotation);
        ammoObj.GetComponent<Rigidbody>().AddForce(side.transform.forward * speed, ForceMode.Acceleration);
    }

    void ShootAmmostrawberries(GameObject side)
    {
        GameObject strawberriesObj = Instantiate(strawberries, side.transform.position, gameObject.transform.rotation);
        strawberriesObj.GetComponent<Rigidbody>().AddForce(side.transform.forward * speed, ForceMode.Acceleration);
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

            if (foodCount > foodBagSize)
            {
                foodCount = foodBagSize;
            }

            foodString = foodCount.ToString();
            foodDisplay.text = "Strawberries:" + foodString + "/" + foodBagSizeString;
        }
    }
}
