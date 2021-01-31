using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text text;
    public int vida;
    public GameObject Panel;
    private Volume volume;
    private Rodar rodar;
    DepthOfField dof;
    private Light2D light2d;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        light2d = GameObject.Find("luzCuerpo").GetComponent<Light2D>();
        volume = GameObject.Find("VOLUME").GetComponent<Volume>();
        rodar = GameObject.Find("Player").GetComponent<Rodar>();
        volume.profile.TryGet<DepthOfField>(out dof);
        dof.focalLength.value = 300;
        light2d.pointLightOuterRadius = 1.8f;
        vida = 5;
        Panel.gameObject.SetActive(false);

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
        text.text = "Vida: " + vida;
        if (vida == 0)
        {
            Panel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        
    }
}
