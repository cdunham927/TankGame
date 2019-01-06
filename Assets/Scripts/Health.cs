using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public float hp;
    public float maxHp;
    public Image health;

    // Update is called once per frame
    void Update ()
    {   //Health UI
        if (health != null) health.fillAmount = hp / maxHp;
    }

}
