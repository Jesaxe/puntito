using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMagna : MonoBehaviour
{
    public GameObject creditos;
    // Start is called before the first frame update
    void Start()
    {
        creditos.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Inicio()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Creditos()
    {
        creditos.gameObject.SetActive(true);
    }
    public void Atras()
    {
        creditos.gameObject.SetActive(false);
    }
}
