using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWallController : MonoBehaviour {
    public int startHp;
    public int hp;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        hp = startHp;
        anim.SetInteger("hp", hp);
    }

    public void TakeDamage()
    {
        hp -= 1;
        anim.SetInteger("hp", hp);
        if (hp <= 0)
        {
            float timeOfAnimation = GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length;
            Invoke("Disable", timeOfAnimation);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}
