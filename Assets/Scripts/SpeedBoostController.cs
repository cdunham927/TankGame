using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostController : MonoBehaviour {
    public float spd;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "p1" || collision.tag == "p2")
        {
                collision.GetComponent<Rigidbody2D>().AddForce(transform.right * spd * Time.deltaTime);
        }
    }
}
