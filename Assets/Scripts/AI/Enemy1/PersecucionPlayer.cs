using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="AI/Acciones/Enemy1/PerseguirPlayer" , fileName ="PersecucionPlayer")]
public class PersecucionPlayer : AIAccion
{
   public override void Act(StateController controller){
        if(controller._objectEnemy1 != null ){
            controller._objectEnemy1.Acechar();
        }
        else{
            controller._objectEnemy1.acechar=false;
        }

    }
}
