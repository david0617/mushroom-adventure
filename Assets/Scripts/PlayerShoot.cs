using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject right, left, ammo;
    private PlayerMovement player;
    public float fireingTimer;
    public float speed;

    private bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && canFire)
        {
            if (player.right == true)
            {
                Shoot(right);
            }
            else if (player.right == false)
            {
                Shoot(left);
            }

            StartCoroutine(FireTimer());
        }
    }

    void Shoot(GameObject side)
    {
        GameObject ammoObj = Instantiate(ammo, side.transform.position, gameObject.transform.rotation);
        ammoObj.GetComponent<Rigidbody>().AddForce(side.transform.forward * speed, ForceMode.Acceleration);
    }

    private IEnumerator FireTimer()
    {
        canFire = false;
        yield return new WaitForSeconds(fireingTimer);
        canFire = true;
    }
}
