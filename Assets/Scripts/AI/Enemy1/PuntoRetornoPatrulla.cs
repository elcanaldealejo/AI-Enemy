using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="AI/Decisiones/Enemy1/PuntoPatrullaje")]
public class PuntoRetornoPatrulla : AIDecisiones
{
    
    public override bool Decide(StateController controller)
    {
        return AlertaLlegada(controller);
    }
   private bool AlertaLlegada(StateController controller){      
       if(controller._objectEnemy1.puntosPatrulla[0].position.y == controller._objectEnemy1.transform.position.y){
          
            return true;
       }
        else{
            //Debug.Log("Entre al punto de no retorno");
            controller._objectEnemy1.transform.position = new Vector2(controller._objectEnemy1._LugarObjetivo.position.x,controller._objectEnemy1._posMINy.position.y);
            
                return true;
            
            }
    
   }    
}
