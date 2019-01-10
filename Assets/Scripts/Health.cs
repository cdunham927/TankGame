using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public float hp;
    public float maxHp;
    public Image health;
    public Image healthMain;
    public Transform[] spawnPoints;
    TankDirectionalMovement tankMove;
    public AnimationClip dieClip;
    public GameObject turret;
    Vector3 baseScale;
    GameController cont;
    float cools = 0f;
    Rigidbody2D bod;
    public GameObject explosion;
    SpriteRenderer rend;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        bod = GetComponent<Rigidbody2D>();
        cont = FindObjectOfType<GameController>();
        baseScale = transform.localScale;
        tankMove = GetComponent<TankDirectionalMovement>();
    }

    // Update is called once per frame
    void Update ()
    {
        healthMain.gameObject.SetActive((cont.started == true ? true : false));
        //Health UI
        if (health != null && !tankMove.dead) health.fillAmount = hp / maxHp;

        if (cools > 0) cools -= Time.deltaTime;

        if (hp <= 0)
        {
            if (cools <= 0) {
                if (this.tag == "p1")
                {
                    cont.scoreB++;
                }
                else
                {
                    cont.scoreA++;
                }
                cools = 2f;
                Instantiate(explosion, transform.position, transform.rotation);
                hp = maxHp;
            }
            Die();
        }
    }

    public void Die()
    {
        bod.velocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;
        rend.enabled = false;
        turret.SetActive(false);
        tankMove.dead = true;
        Invoke("Respawn", dieClip.length + 1.5f);
    }

    public void Respawn()
    {
        transform.localScale = baseScale;
        rend.enabled = true;
        turret.SetActive(true);
        GetComponent<Collider2D>().enabled = true;
        tankMove.dead = false;
        int spawn = Random.Range(0, spawnPoints.Length);
        transform.rotation = spawnPoints[spawn].rotation;
        transform.position = spawnPoints[spawn].position;
    }
}
