using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy2 : MonoBehaviour
{
   // public float radio=0f;
    //public LayerMask layer;
    public float Velocidad;
    public float radio=0f;
    public LayerMask layer;
    public viaPatrulla RecorridoPatrulla=null;
    public Transform mayaRecorrido=null;
    public bool EnPatrulla,GiraSprite,Persiguiendo;
    public int puntoPatrullaActual;
    // Start is called before the first frame update
    void Start()
    {
      EnPatrulla=false;
    }


    void OnDrawGizmosSelected(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,radio);
     }
     
}
