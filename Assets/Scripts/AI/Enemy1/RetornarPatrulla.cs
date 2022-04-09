using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="AI/Acciones/Enemy1/Retornar Patrulla" , fileName ="RetornarPatrulla")]
public class RetornarPatrulla : AIAccion
{
   public override void Act(StateController controller){
        if(controller._objectEnemy1 != null){
            
            if(!controller._objectEnemy1.retornar && (controller._objectEnemy1.puntosPatrulla[0].position.x > controller._objectEnemy1._LugarObjetivo.position.x) || (controller._objectEnemy1.puntosPatrulla[1].position.x < controller._objectEnemy1._LugarObjetivo.position.x) ){
                controller._objectEnemy1.RetornarP();
            }
            
        }

    }


}
