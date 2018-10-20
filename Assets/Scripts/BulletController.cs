using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public int spd;
    public int atk = 20;
    private Rigidbody2D bod;
    Animator anim;
    //Things to deactivate once the bullet is 'destroyed'
    SpriteRenderer rend;
    Collider2D col;
    bool canHit = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        bod = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        SwitchDependencies();
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
        SwitchDependencies();
        anim.Play("BulletDeath");
        float timeOfAnimation = GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length;
        bod.velocity = new Vector3(0, 0, 0);
        Invoke("Deactivate", timeOfAnimation);
    }

    void Deactivate()
    {
        canHit = false;
        gameObject.SetActive(false);
    }

    //Activate/Deactivate components
    void SwitchDependencies()
    {
        rend.enabled = !rend.enabled;
        col.enabled = !col.enabled;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canHit == true)
        {
            if (collision.tag == "Player")
            {
                GameObject player = collision.gameObject;
                Debug.Log("Hit a player");
                //Damage(player, dmg);
            }
            Disable();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canHit = true;
        }
    }

    void Damage(GameObject obj, int damage)
    {
        //obj.GetComponent<PlayerHealth>().hp -= damage;
    }
}
