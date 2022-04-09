using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="AI/Acciones/Enemy2/Perseguir Layer" , fileName ="PerseguirLayer")]
public class PerseguirLayer : AIAccion
{
   
    public override void Act(StateController controller){
        
        if(controller._objectEnemy2.Persiguiendo && (GameObject.FindWithTag("Player").transform.localScale.x<0f && controller._objectEnemy2.transform.localScale.x<0f || GameObject.FindWithTag("Player").transform.localScale.x>0f && controller._objectEnemy2.transform.localScale.x>0f)){
            controller._objectEnemy2.transform.position = Vector3.MoveTowards(controller._objectEnemy2.transform.position, GameObject.FindWithTag("Player").transform.position,  Time.deltaTime * 2f );
            controller._objectEnemy2.EnPatrulla=false;            
        }
    }
   
}
