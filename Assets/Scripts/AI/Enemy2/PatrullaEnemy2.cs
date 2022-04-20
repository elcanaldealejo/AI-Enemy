using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="AI/Acciones/Enemy2/Patrullar" , fileName ="PatrullaEnemy2")]
public class PatrullaEnemy2 : AIAccion
{
   
    
    private int puntoActual;
     private int puntoSiguiente;
    private int puntoPasado;

   


    public override void Act(StateController controller){
        
        if(controller._objectEnemy2 != null){
           //Debug.Log( "Más Cercano es: "+PuntoCercano(controller));
           puntoActual = PuntoCercano(controller);
             
            Vector3 newPunto =new Vector3(controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla[puntoActual].x+controller._objectEnemy2.mayaRecorrido.position.x,controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla[puntoActual].y+controller._objectEnemy2.mayaRecorrido.position.y,0f);
            //Lejos de la via de patrullaje
           if(!controller._objectEnemy2.EnPatrulla && Vector2.Distance(controller._objectEnemy2.transform.position,newPunto) == 0f){
                //Debug.Log( "Ya estoy en : "+puntoActual);
                controller._objectEnemy2.puntoPatrullaActual = puntoActual;
                controller._objectEnemy2.EnPatrulla=true;
                if(puntoActual+1 < controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla.Count){
                    puntoSiguiente=puntoActual+1;
                }else
                     puntoSiguiente=0;
                //Debug.Log( "Ir ahora a : "+puntoSiguiente);     
           }
           else if(!controller._objectEnemy2.EnPatrulla){
               controller._objectEnemy2.transform.position = Vector3.MoveTowards(controller._objectEnemy2.transform.position,controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla[puntoActual]+controller._objectEnemy2.mayaRecorrido.position, Time.deltaTime * controller._objectEnemy2.Velocidad);
           }
          
        
        //Sobre la via de patrullaje
        if(controller._objectEnemy2.EnPatrulla){

            newPunto =new Vector3(controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla[puntoSiguiente].x+controller._objectEnemy2.mayaRecorrido.position.x,controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla[puntoSiguiente].y+controller._objectEnemy2.mayaRecorrido.position.y,0f);
            controller._objectEnemy2.transform.position = Vector3.MoveTowards(controller._objectEnemy2.transform.position,controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla[puntoSiguiente]+controller._objectEnemy2.mayaRecorrido.position, Time.deltaTime * controller._objectEnemy2.Velocidad);
            if(Vector2.Distance(controller._objectEnemy2.transform.position,newPunto)==0f){
                puntoPasado = puntoActual;
                puntoActual=puntoSiguiente;
                if(puntoActual+1 < controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla.Count){
                    puntoSiguiente=puntoActual+1;
                }else
                     puntoSiguiente=0;
                controller._objectEnemy2.puntoPatrullaActual = puntoActual;
                //Debug.Log( "Ya estoy en : "+puntoActual);
                //Debug.Log( "Ir ahora a : "+puntoSiguiente); 
            }
        }
    
        }
    }
    private int PuntoCercano(StateController controller){
        int masCercano=0;
        
        if(controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla.Count >1){

            Vector3[] points = new Vector3[controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla.Count];  
            for(int i=0; i < points.Length ; i++){
                 points[i]=controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla[i]+controller._objectEnemy2.mayaRecorrido.position;
            }

            float distanceMin= Vector2.Distance(points[0],controller._objectEnemy2.transform.position);
            
            for(int u=1; u < points.Length ; u++){
                if(distanceMin>Vector2.Distance(points[u],controller._objectEnemy2.transform.position)){
                    distanceMin=Vector2.Distance(points[u],controller._objectEnemy2.transform.position);
                    masCercano=u;
                }
            }
        }
        return masCercano;
    }


   
}
