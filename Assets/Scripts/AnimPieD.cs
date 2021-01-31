﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPieD : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal")!=0)
        {
            anim.Play("Pie_B_Mover");
        }
        else
        {
            anim.Play("Pie_B_Iddle");
        }
    }
}
