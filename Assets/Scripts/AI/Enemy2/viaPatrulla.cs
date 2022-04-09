using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viaPatrulla : MonoBehaviour
{
   public static viaPatrulla instance;
    
    public List<Vector3> puntosPatrulla = new List<Vector3>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        instance=this;
     
       
    }

   

     void OnDrawGizmosSelected(){
       
      
        if(puntosPatrulla != null ){
            for(int i =0; i<puntosPatrulla.Count; i++){
                if(i<puntosPatrulla.Count){
                    // Draw Pints
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireSphere(transform.position + puntosPatrulla[i],0.2f);

                    //Draw Lines
                    Gizmos.color = Color.yellow;
                    if(i < puntosPatrulla.Count - 1){
                        Gizmos.DrawLine(transform.position + puntosPatrulla[i],transform.position + puntosPatrulla[i+1]);
                    }

                    //Dibuje la linea desde el ultimo punto al primer punto
                    if(i == puntosPatrulla.Count - 1){
                        Gizmos.DrawLine(transform.position + puntosPatrulla[i],transform.position + puntosPatrulla[0]);
                    }
                }
            }
        }
   }
}
