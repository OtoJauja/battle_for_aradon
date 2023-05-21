using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimation : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Click 0", true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("Click 0", false);
        }
    }
}
