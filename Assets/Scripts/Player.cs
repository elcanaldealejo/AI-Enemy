using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int golpe=0;


    void Update(){

        if((Input.GetAxisRaw("Horizontal")>0f && transform.localScale.x<0f)||(Input.GetAxisRaw("Horizontal")<0f && transform.localScale.x>0f)){
            transform.localScale = new Vector3(transform.localScale.x*-1f,transform.localScale.y,transform.localScale.z);

        }else{
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
	{
        if(collision.gameObject.layer==10){
            Debug.Log("Martillazos Recibidos : "+golpe++);

        }


    }
}
