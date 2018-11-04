using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostController : MonoBehaviour {
    public float spd;

    private void Update()
    {
        print(transform.up);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Rigidbody2D>().AddForce(transform.right * spd * Time.deltaTime);
        }
    }
}
