using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    private Volume volume;
    private Rodar rodar;
    DepthOfField dof;
    private Light2D light2d;
    // Start is called before the first frame update
    void Start()
    {
        light2d = GameObject.Find("luzCuerpo").GetComponent<Light2D>();
        volume = GameObject.Find("VOLUME").GetComponent<Volume>();
        rodar = GameObject.Find("Player").GetComponent<Rodar>();
        volume.profile.TryGet<DepthOfField>(out dof);
        dof.focalLength.value = 300;
        light2d.pointLightOuterRadius = 1.8f;

    }

    // Update is called once per frame
    void Update()
    {
        if (rodar.ojitos)
        {
            dof.focalLength.value = 0;
            light2d.pointLightOuterRadius = 80;
        }
        else
        {
            dof.focalLength.value = 300;
            light2d.pointLightOuterRadius = 1.8f;
        }
       
      
    }
}
