using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour {
    public float speed = 120f;
    public string inp;
    public string inp2;
    Vector2 inpAxis;

    public GameObject hull;
    public Vector3 offset;

    void Update()
    {
    }

    private void LateUpdate()
    {
        //transform.position = new Vector3(hull.transform.position.x + offset.x, hull.transform.position.y + offset.y);
        //if (inpAxis.x == 0 && inpAxis.y == 0) transform.rotation = Quaternion.identity;
        inpAxis = new Vector2(Input.GetAxis(inp), Input.GetAxis(inp2));
        Vector3 ang = new Vector3(0, 0, Mathf.Atan2(inpAxis.y, inpAxis.x) * 180 / Mathf.PI);
        if (inpAxis.x != 0 || inpAxis.y != 0) transform.eulerAngles = ang;
    }
}
