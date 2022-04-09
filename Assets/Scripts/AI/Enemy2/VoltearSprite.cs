using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="AI/Acciones/Enemy2/Girar Sprite" , fileName ="VoltearSprite")]
public class VoltearSprite : AIAccion
{
public override void Act(StateController controller){
    
float scaleX = controller._objectEnemy2.transform.localScale.x;
   if(controller._objectEnemy2.GiraSprite){
       if(scaleX>0f)
        controller._objectEnemy2.transform.localScale = new Vector3(scaleX*-1f,controller._objectEnemy2.transform.localScale.y,controller._objectEnemy2.transform.localScale.z);
        else
        controller._objectEnemy2.transform.localScale = new Vector3(scaleX,controller._objectEnemy2.transform.localScale.y,controller._objectEnemy2.transform.localScale.z);
        
   }
    else{
       if(scaleX>0f)
        controller._objectEnemy2.transform.localScale = new Vector3(scaleX,controller._objectEnemy2.transform.localScale.y,controller._objectEnemy2.transform.localScale.z);
        else
        controller._objectEnemy2.transform.localScale = new Vector3(scaleX*-1f,controller._objectEnemy2.transform.localScale.y,controller._objectEnemy2.transform.localScale.z);
        
    }
   
}

}