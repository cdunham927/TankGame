using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDirectionalMovement : MonoBehaviour {

    public string inp;
    public string inp2;
    Rigidbody2D bod;
    Vector2 input;
    public float spd;

	// Use this for initialization
	void Start () {
        bod = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        input = new Vector2(Input.GetAxisRaw(inp), Input.GetAxisRaw(inp2));
        float step = spd * Time.deltaTime;
        //Moving Right
        if (input.x > 0 && input.y == 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            bod.AddForce(-transform.up * spd * Time.deltaTime);
        }
        if (input.x > 0 && input.y > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 135));
            bod.AddForce(-transform.up * spd * Time.deltaTime);
        }
        if (input.x == 0 && input.y > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            bod.AddForce(-transform.up * spd * Time.deltaTime);
        }
        if (input.x < 0 && input.y > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 225));
            bod.AddForce(-transform.up * spd * Time.deltaTime);
        }
        if (input.x < 0 && input.y == 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
            bod.AddForce(-transform.up * spd * Time.deltaTime);
        }
        if (input.x < 0 && input.y < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 315));
            bod.AddForce(-transform.up * spd * Time.deltaTime);
        }
        if (input.x == 0 && input.y < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            bod.AddForce(-transform.up * spd * Time.deltaTime);
        }
        if (input.x > 0 && input.y < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));
            bod.AddForce(-transform.up * spd * Time.deltaTime);
        }

    }
}
