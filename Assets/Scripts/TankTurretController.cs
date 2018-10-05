using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurretController : MonoBehaviour {
    public string input;
    public GameObject bullet;
    public Transform bulSpawn;
    public float weaponCooldown;
    float cools = 0f;

    void Update () {
        if (Input.GetButtonDown(input) && cools <= 0)
        {
                cools = weaponCooldown;
                Instantiate(bullet, bulSpawn.position, transform.rotation);
        }

        if (cools > 0) cools -= Time.deltaTime;
	}
}
