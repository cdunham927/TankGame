using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public int spd;
    public int atk = 20;
    private Rigidbody2D bod;
    Animator anim;
    //Things to deactivate once the bullet is 'destroyed'
    public string thisTag;
    public string otherTag;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        bod = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        anim.Play("BulletSpawn");
        Invoke("Disable", 2f);
        bod.AddForce(transform.right * spd);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void Disable()
    {
        anim.Play("BulletDeath");
        float timeOfAnimation = GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length;
        bod.velocity = new Vector3(0, 0, 0);
        Invoke("Deactivate", timeOfAnimation);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == otherTag)
        {
            GameObject player = collision.gameObject;
            Damage(player, atk);
            Disable();
        }
        if (collision.tag == "Destructible")
        {
            GameObject obj = collision.gameObject;
            obj.GetComponent<DestructibleWallController>().TakeDamage();
            Disable();
        }
        if (collision.tag == "Untagged")
        {
            Disable();
        }
    }

    void Damage(GameObject obj, int damage)
    {
        obj.GetComponent<Health>().hp -= damage;
    }
}
