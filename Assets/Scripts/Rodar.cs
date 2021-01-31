using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Rodar : MonoBehaviour
{
    public float velocidad;
    public Rigidbody2D rb;

    public GameObject pies1,pies2,mano1,mano2,ojos,piso;
    public bool pies,manos,ojitos;
    public float velocidad2;
    public float salto;
    public Vector3 offset;
    bool agarrado;
    bool puedeag;
    void Start()
    {
        
      
        rb = GetComponent<Rigidbody2D>();
        pies=false;
        manos=false;
        ojitos=false;
        pies1.SetActive(false);
        pies2.SetActive(false);
        mano1.SetActive(false);
        mano2.SetActive(false);
        ojos.SetActive(false);
        piso.SetActive(false);
        agarrado = false;
        puedeag = false;
    }

    // Update is called once per frame
    void Update()
    {
        float movY = Input.GetAxis("Vertical");
        Vector3 movimeinto = new Vector3(Input.GetAxis("Horizontal"),0f,0f);

        if (!agarrado)
        {
            if (pies == false)
            {
                transform.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal") * -80) * Time.deltaTime);
                transform.position += movimeinto * velocidad * Time.deltaTime;
            }
            if (pies == true)
            {
                piso.SetActive(true);
                transform.rotation = Quaternion.identity;

                pies1.SetActive(true);
                pies2.SetActive(true);
                transform.position += movimeinto * velocidad * Time.deltaTime * velocidad2;
                if (Input.GetAxis("Horizontal") != 0)
                {
                    if (Input.GetAxis("Horizontal") >= 0)
                    {
                        transform.localScale = new Vector3(0.35f, 0.35f, 1);
                    }
                    else
                    {
                        transform.localScale = new Vector3(-0.35f, 0.35f, 1);
                    }
                }
                if (Input.GetButtonDown("Jump"))
                {
                    saltar();
                }

            }
        }
        if (agarrado)
        {
            rb.velocity = new Vector2(0, Input.GetAxis("Vertical")) * velocidad;

            offset.y += movY / 10;
            if (Input.GetButtonDown("Jump"))
            {
                if (movY < 0)
                {
                    seSuelta();
                }

                else
                {
                    seSuelta();
                    saltar();
                }
            }
        }
        if (manos)
        {
            mano1.SetActive(true);
            mano2.SetActive(true);
            puedeag = true;
            //codigo de escalar
        }
        else if (!manos)
        {
            puedeag = false;
        }
        if(ojitos)
        {
            ojos.SetActive(true);
            
            //desactivar blur y luz
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Manos")
        {
            manos=true;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Ojos")
        {
            ojitos=true;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Pies")
        {
            print(".");
            pies=true;
            collision.gameObject.SetActive(false);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ropes")
        {
            if (puedeag)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    agarrado = true;

                    rb.isKinematic = true;
                }
            }
            
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ropes")
        {
            agarrado = false;
            rb.isKinematic = false;
        }
    }
    void seSuelta()
    {
        agarrado = false;
        offset = Vector2.zero;
        rb.isKinematic = false;
    }
    void saltar()
    {
        rb.AddForce(new Vector2(0, salto), ForceMode2D.Impulse);
    }



}
