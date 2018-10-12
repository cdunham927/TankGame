using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public int spd;
    private Rigidbody2D bod;

    private void Awake()
    {
        bod = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Invoke("Disable", 2f);
        bod.AddForce(transform.right * spd);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject player = collision.gameObject;
            Debug.Log("Hit a player");
            //Damage(player, dmg);
        }
        Disable();
    }

    void Damage(GameObject obj, int damage)
    {
        //obj.GetComponent<PlayerHealth>().hp -= damage;
    }
}
