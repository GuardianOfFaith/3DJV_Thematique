using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire2Script : MonoBehaviour {

	[SerializeField] private Transform laserSpawn;
	[SerializeField] private LineRenderer laser;	
	
	public IEnumerator shoot()
	{
		RaycastHit2D hit = Physics2D.Raycast(laserSpawn.position, laserSpawn.right);
		if (hit)
		{
			Debug.Log("hit!!");
		}
		
		laser.SetPosition(0,laserSpawn.position);
		laser.SetPosition(1,laserSpawn.position+laserSpawn.right*100);
		
		laser.enabled = true;
		yield return new WaitForSeconds(0.02f);
		laser.enabled = false;
 
	}

	public void affich()
	{
		Debug.Log("loloooll");
	}

}
