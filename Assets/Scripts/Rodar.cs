using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rodar : MonoBehaviour
{
    public float velocidad;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movimeinto = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movimeinto *velocidad*Time.deltaTime;
        transform.Rotate (new Vector3 (0, 0, Input.GetAxis("Horizontal")*-80) * Time.deltaTime);
        
    }

}
