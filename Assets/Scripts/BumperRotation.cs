using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperRotation : MonoBehaviour
{
    public string inp;
    public string inp2;
    public float rotSpd;

    Quaternion rotation;
    void Awake()
    {
        rotation = transform.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
    }


    private void Update()
    {
        if (Input.GetButton(inp))
        {
            rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.z - rotSpd * Time.deltaTime));
            transform.Rotate(new Vector3(0, 0, transform.rotation.z - rotSpd * Time.deltaTime));
        }
        if (Input.GetButton(inp2))
        {
            transform.Rotate(new Vector3(0, 0, transform.rotation.z + rotSpd * Time.deltaTime));
        }
    }
}
