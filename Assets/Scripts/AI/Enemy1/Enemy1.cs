using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    
    public bool acechar;
    public bool move, retornar;
    protected Rigidbody2D _rigidbody;
    public Transform _LugarObjetivo,_posMINy;
    public float Velocidad=1.2f;
    public int nextPoint;
    private float posYEnemy;
    public Transform[] puntosPatrulla;
    private Vector3 Pos1, Pos2;
    public float angulo;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        posYEnemy = transform.position.y;
        Pos1 = puntosPatrulla[0].position;
        Pos2 = puntosPatrulla[1].position;
        nextPoint=0;
       
    }


    public void Acechar(){
        if(puntosPatrulla[0].position.x < _LugarObjetivo.transform.position.x && puntosPatrulla[1].position.x > _LugarObjetivo.transform.position.x){
            acechar=true;
            move=false;
            retornar=false;
            StartCoroutine("Persecucion");
        }
    }
    public void Patrulla(){
        if(!move){
            move=true;
            acechar=false;
            retornar=false;
            StartCoroutine("Patrullar");
        }
    }
    public void RetornarP(){
        if(!retornar){            
            move=false;
            acechar=false;
            retornar=true;
            float distance1 = Vector2.Distance( puntosPatrulla[0].transform.position , transform.position);
            float distance2 = Vector2.Distance( puntosPatrulla[1].transform.position , transform.position);

            if(distance1 < distance2)
                nextPoint=0;
            else
                nextPoint=1;

            StartCoroutine("RetornoPatrulla");
        }
         
    }
    private IEnumerator Persecucion()
	{
        
		// Co-rutina para mover el enemigo
		while(Vector2.Distance(new Vector2(transform.position.x,posYEnemy), new Vector2(_LugarObjetivo.position.x,posYEnemy ) ) > 0.05f) {
			// Se desplazará hasta el sitio objetivo
			Vector2 direction = _LugarObjetivo.position - transform.position;
			float xDirection = direction.x;
            float posYVector=0f;    
           if(transform.position.y>_posMINy.position.y)
                posYVector = -_posMINy.position.y;
            

			transform.Translate(new Vector2(xDirection,posYVector) * (Velocidad/2) * (Time.deltaTime));
			yield return null;
		}
		
	}

    private IEnumerator Patrullar()
	{
        
		// Co-rutina para mover el enemigo
		while(Vector2.Distance(puntosPatrulla[nextPoint].position, transform.position) > 1f){
			
            // Se desplazará hasta el sitio objetivo
			Vector2 direction = puntosPatrulla[nextPoint].position - transform.position;
            float vel = (Velocidad)*  Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position,puntosPatrulla[nextPoint].position, vel);
			yield return null;
		}
		
        if(nextPoint==0)
            nextPoint=1;
        else
            nextPoint=0;
        
        if(move)
		  StartCoroutine("Patrullar");
	}
private IEnumerator RetornoPatrulla()
	{
        
		// Co-rutina para mover el enemigo
		while(Vector2.Distance(puntosPatrulla[nextPoint].position, transform.position) > 0.01f) {
			
            // Se desplazará hasta el sitio objetivo
			Vector2 direction =  puntosPatrulla[nextPoint].position - transform.position ;
			float xDirection = direction.x;
			transform.Translate(new Vector2(xDirection,direction.y) * (Velocidad*2) * Time.deltaTime);
			yield return null;
		}
		if(nextPoint==0)
            nextPoint=1;
        else
            nextPoint=0;
             
        //if(retornar)
		  //StartCoroutine("RetornoPatrulla");
	}
   void OnDrawGizmosSelected(){
       Gizmos.color = Color.blue;
       Gizmos.DrawWireCube(transform.position,new Vector2(angulo*2,angulo));
   }
   
}
