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
        bod.AddForce(-transform.up * spd);
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
        Disable();
    }
}
