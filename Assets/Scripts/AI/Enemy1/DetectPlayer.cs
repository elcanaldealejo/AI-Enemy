using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="AI/Decisiones/Enemy1/DetectarPlayer")]
public class DetectPlayer : AIDecisiones
{
    [Header("State")] 
    [SerializeField] public LayerMask layerPlayer;
    
    public override bool Decide(StateController controller)
    {
        return PlayerDetectado(controller);
    }
   private bool PlayerDetectado(StateController controller){      
       if((controller._objectEnemy1.puntosPatrulla[0].position.x < controller._objectEnemy1._LugarObjetivo.position.x) && (controller._objectEnemy1.puntosPatrulla[1].position.x > controller._objectEnemy1._LugarObjetivo.position.x) && Physics2D.OverlapBox(controller._objectEnemy1.transform.position,new Vector2(controller._objectEnemy1.angulo*2,controller._objectEnemy1.angulo),controller._objectEnemy1.angulo/2,layerPlayer)!=null)
            return true;
        else
            return false;
   }

   
}
