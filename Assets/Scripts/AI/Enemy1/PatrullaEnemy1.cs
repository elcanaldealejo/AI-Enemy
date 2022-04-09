using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="AI/Acciones/Enemy1/Patrullar" , fileName ="PatrullaEnemy1")]
public class PatrullaEnemy1 : AIAccion
{
    
    public override void Act(StateController controller){
        if(controller._objectEnemy1 != null){
            
            if(!controller._objectEnemy1.move && (controller._objectEnemy1.puntosPatrulla[0].position.x > controller._objectEnemy1._LugarObjetivo.position.x) || (controller._objectEnemy1.puntosPatrulla[1].position.x < controller._objectEnemy1._LugarObjetivo.position.x) ){
                controller._objectEnemy1.Patrulla();
            }
                        
        }

    }
}
