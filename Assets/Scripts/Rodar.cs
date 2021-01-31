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
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 movimeinto = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        
        
        if(pies==false)
        {
            transform.Rotate (new Vector3 (0, 0, Input.GetAxis("Horizontal")*-80) * Time.deltaTime);
            transform.position += movimeinto *velocidad*Time.deltaTime;
        }
        if(pies==true)
        {
            piso.SetActive(true);
            transform.rotation = Quaternion.identity;
            
            pies1.SetActive(true);
            pies2.SetActive(true);
            transform.position += movimeinto *velocidad*Time.deltaTime*velocidad2;
            if(Input.GetAxis("Horizontal")!=0)
            {
                if(Input.GetAxis("Horizontal")>=0)
                {
                    transform.localScale=new Vector3(0.35f,0.35f,1);
                }
                else
                {
                    transform.localScale=new Vector3(-0.35f,0.35f,1);
                }
            }
                

        }
        if(manos)
        {
            mano1.SetActive(true);
            mano2.SetActive(true);
            //codigo de escalar
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
            pies=true;
            collision.gameObject.SetActive(false);
        }
    }

    

}
