using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEditor;
using UnityEngine;

public class playerController : MonoBehaviour
{
	[SerializeField] private Transform spatialShip;
	[SerializeField] private Rigidbody2D rbSpatialShip;
	[SerializeField] private float speed = 10f;
	[SerializeField] private fireScript fire;

	private Vector2 move = Vector2.zero;
	
	private bool facingDirection=true;
	
	void Update ()
	{		
		move.x = Input.GetAxis("HorizontalX2");
		move.y = Input.GetAxis("VerticalY2");
	
	
		if (move.x>0 && !facingDirection)
		{
			flipDirection();
		}
		else if (move.x < 0 && facingDirection)
		{
			flipDirection();
		}
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(fire.shoot());
		}

	}

	void FixedUpdate()
	{
		rbSpatialShip.velocity = move * speed;
	}

	// tourner le vaisseau vers la direction appuyée
	void flipDirection()
	{
		spatialShip.Rotate(0f,180f,0f);
		facingDirection = !facingDirection;
	}

}
