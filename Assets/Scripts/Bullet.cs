using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
	[Header("Parametros Editables")]
	[SerializeField] private LayerMask Mascara_Layer=0;
    [SerializeField] private float LongLine=0.0f;
    [SerializeField] private Transform objeto=null;
	public float speed = 5f;
	public Vector2 direction;
	public float livingTime = 3f;
	private float _startingTime;

	private Rigidbody2D _rigidbody;
	//private CapsuleCollider2D _collider;
	 
	void Awake()
	{
		
		_rigidbody = GetComponent<Rigidbody2D>();		
		
	}

	// Start is called before the first frame update
	void Start()
    {
		_startingTime = Time.time;
		
    }

    
    void Update()
    {
		if(CreateRaycast(1f,LongLine,objeto,objeto.position,Mascara_Layer))
			Destroy(gameObject);

		float Vel = speed;
		if(direction.x<0.0f){
				transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y*-1,transform.localScale.z);
				Vel*=-1f; 
		}	
		
		Vector2 movement = direction.normalized * speed * Time.deltaTime;
		
		transform.Translate(movement);
		Destroy(gameObject, livingTime);
    }
private bool CreateRaycast(float Orientacion, float Longitud,  Transform Dir_Posicion, Vector2 Altura_Vector ,  LayerMask mascara){

    Vector2 dir = Dir_Posicion.position;
    RaycastHit2D hit = Physics2D.Raycast(Altura_Vector, dir, Longitud, mascara);
    if(Orientacion<0.0f || Orientacion==1f){
    dir = Dir_Posicion.TransformDirection(Vector2.right) * Longitud;
    hit = Physics2D.Raycast(Altura_Vector, dir, Longitud, mascara);
    }
    if(Orientacion==2f){
    dir = Dir_Posicion.TransformDirection(Vector2.up) * Longitud;
    hit = Physics2D.Raycast(Altura_Vector, dir, Longitud, mascara);
    }
    Debug.DrawRay(Altura_Vector, dir , hit ? Color.green : Color.blue); //Ya no es un Gizmo
    
    if(hit)
        return true;
    else
        return false;
}


}
