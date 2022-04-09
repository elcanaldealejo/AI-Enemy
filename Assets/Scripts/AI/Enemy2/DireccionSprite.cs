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

        
        if(!controller._objectEnemy2.GiraSprite && controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla[controller._objectEnemy2.puntoPatrullaActual].x+controller._objectEnemy2.mayaRecorrido.transform.position.x < controller._objectEnemy2.transform.position.x )
         {
            controller._objectEnemy2.GiraSprite=true;
            return true;
        }
        
        if(controller._objectEnemy2.GiraSprite && (controller._objectEnemy2.RecorridoPatrulla.puntosPatrulla[controller._objectEnemy2.puntoPatrullaActual].x+controller._objectEnemy2.mayaRecorrido.transform.position.x > controller._objectEnemy2.transform.position.x) )
        {   controller._objectEnemy2.GiraSprite=false;
            return true;
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

   
}
