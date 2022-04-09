using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject shooter;

	public Transform _firePoint;

	private Weapon arma;
	private bool Cont;

	void Awake()
	{
		arma = this.GetComponent<Weapon>();
	}


	public void Shoot()
	{
		if (bulletPrefab != null && _firePoint != null && shooter != null) {
			GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;
			
			myBullet.SetActive(true);
			Bullet bulletComponent = myBullet.GetComponent<Bullet>();
			SpriteRenderer bulletComponent2 = myBullet.GetComponent<SpriteRenderer>();
			bulletComponent2.enabled=true;
			
			if (_firePoint.position.x < shooter.transform.position.x) {
				// Left
				if(Cont){
				bulletComponent.direction = Vector2.right;
				Cont=false;
				}
				else{
				bulletComponent.direction = Vector2.down;
				Cont=true;
				}
			} 
			if (_firePoint.position.x > shooter.transform.position.x){
				// Right
				bulletComponent.transform.localScale*=-1;
				if(Cont){
				bulletComponent.direction = Vector2.left;
				Cont=false;
				}
				else{
				bulletComponent.direction = Vector2.down;
				Cont=true;
				}
			}
			
			Destroy(myBullet, 2f);

		}
	}
}
