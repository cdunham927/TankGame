using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperRotation : MonoBehaviour
{
    public string inp;
    public string inp2;
    public float rotSpd;

    private void Update()
    {
        if (Input.GetButton(inp))
        {
            transform.Rotate(new Vector3(0, 0, transform.rotation.z - rotSpd * Time.deltaTime));
        }
        if (Input.GetButton(inp2))
        {
            transform.Rotate(new Vector3(0, 0, transform.rotation.z + rotSpd * Time.deltaTime));
        }
    }
}
