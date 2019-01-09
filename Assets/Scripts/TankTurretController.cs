using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurretController : MonoBehaviour {
    public string input;
    public string input2;
    public GameObject bullet;
    public Transform bulSpawn;
    public float weaponCooldown;
    float cools = 0f;
    public int mines = 0;
    public string specialInp;
    public GameObject mine;
    GameController controller;
    TankDirectionalMovement tankMove;

    private void Awake()
    {
        controller = FindObjectOfType<GameController>();
        tankMove = GetComponentInParent<TankDirectionalMovement>();
    }

    void Update () {
        if (controller.started && !tankMove.dead)
        {
            if (input2 == "")
            {
                if (Input.GetButtonDown(input) && cools <= 0)
                {
                    cools = weaponCooldown;
                    Instantiate(bullet, bulSpawn.position, transform.rotation);
                }
            }
            else
            {
                if ((Input.GetAxis(input) != 0 || Input.GetAxis(input2) != 0) && cools <= 0)
                {
                    cools = weaponCooldown;
                    Instantiate(bullet, bulSpawn.position, transform.rotation);
                }
            }


            if (Input.GetButtonDown(specialInp) && mines > 0)
            {
                DropMine();
            }

            if (cools > 0) cools -= Time.deltaTime;
        }
	}

    public void DropMine()
    {
        Instantiate(mine, transform.position, Quaternion.identity);
    }
}
