using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour {
    Rigidbody2D bod;
    public float spd;
    public float rotSpd;
    public string xInp;
    public string yInp;
    Vector2 input;

    private void Awake()
    {
        bod = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input = new Vector2(Input.GetAxis(xInp), Input.GetAxis(yInp));

        if (input.y != 0)
        {
            bod.AddForce(-transform.up * spd * input.y * Time.deltaTime);
        }

        if (input.x != 0)
        {
            transform.Rotate(new Vector3(0, 0, transform.rotation.z - rotSpd * input.x * Time.deltaTime));
        }
    }
}
