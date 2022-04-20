using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="AI/Decisiones/Enemy2/Validar Dirección")]
public class DireccionSprite : AIDecisiones
{
    
    public override bool Decide(StateController controller)
    {
        if(!controller._objectEnemy2.EnPatrulla && !controller._objectEnemy2.Persiguiendo){
            return ValidarCambioDireccionRetornando(controller);
            
        }
        if(controller._objectEnemy2.EnPatrulla){
           return ValidarCambioDireccionPatrullando(controller);
            
        }
        if(!controller._objectEnemy2.EnPatrulla && controller._objectEnemy2.Persiguiendo){
           return ValidarCambioDireccionPersiguiendo(controller);
           
        }
        return false;
    }
    private bool ValidarCambioDireccionRetornando(StateController controller){  
        int puntoActual = PuntoCercano(controller);
        
        if(!controller._objectEnemy2.GiraSprite && (controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla[puntoActual].x+controller._objectEnemy2.mayaRecorrido.transform.position.x < controller._objectEnemy2.transform.position.x) )
        {
            controller._objectEnemy2.GiraSprite=true;
            return true;
        }
        
        if(controller._objectEnemy2.GiraSprite && (controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla[puntoActual].x+controller._objectEnemy2.mayaRecorrido.transform.position.x > controller._objectEnemy2.transform.position.x) )
        {   controller._objectEnemy2.GiraSprite=false;
            return false;
        }  
          
        return false;
    }
    private bool ValidarCambioDireccionPersiguiendo(StateController controller){  

        if(!controller._objectEnemy2.GiraSprite && GameObject.FindWithTag("Player").transform.position.x < controller._objectEnemy2.transform.position.x )
         {
            controller._objectEnemy2.GiraSprite=true;
            return true;
        }
        
        if(controller._objectEnemy2.GiraSprite && GameObject.FindWithTag("Player").transform.position.x  > controller._objectEnemy2.transform.position.x )
        {   controller._objectEnemy2.GiraSprite=false;
            return true;
        }  
        return false;
    }
   private bool ValidarCambioDireccionPatrullando(StateController controller){  
        int puntoActivo = controller._objectEnemy2.puntoPatrullaActual;
        int puntoSiguiente = 0;
        if(puntoActivo+1 < controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla.Count){
                    puntoSiguiente=puntoActivo+1;
        }else
                    puntoSiguiente=0;
       
       
        if(!controller._objectEnemy2.GiraSprite && controller._objectEnemy2.EnPatrulla && controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla[puntoSiguiente].x+controller._objectEnemy2.mayaRecorrido.transform.position.x < controller._objectEnemy2.transform.position.x )
         {
            controller._objectEnemy2.GiraSprite=true;
            return true;
        }
        
        if(controller._objectEnemy2.GiraSprite && controller._objectEnemy2.EnPatrulla && (controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla[puntoSiguiente].x+controller._objectEnemy2.mayaRecorrido.transform.position.x > controller._objectEnemy2.transform.position.x) )
        {   controller._objectEnemy2.GiraSprite=false;
            return true;
        }  
        return false;

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
