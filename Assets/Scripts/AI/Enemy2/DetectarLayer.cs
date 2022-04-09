using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="AI/Decisiones/Detectar Layer")]
public class DetectarLayer : AIDecisiones
{
    
    
    public string nameEnemy;
    public override bool Decide(StateController controller)
    {  
        return Detectar(controller);        
    } 

   private bool Detectar(StateController controller){
     
       if(Physics2D.OverlapCircle(GameObject.Find(nameEnemy).GetComponent<Transform>().position,controller._objectEnemy2.radio,controller._objectEnemy2.layer)){
            Debug.Log("SI sDetecto el layer");
            controller._objectEnemy2.Persiguiendo=true;
            return true;
       }else{
           controller._objectEnemy2.Persiguiendo=false;
        Debug.Log("NO se detecta Layer");
       }
           
        return false;
      
   }

    

}
