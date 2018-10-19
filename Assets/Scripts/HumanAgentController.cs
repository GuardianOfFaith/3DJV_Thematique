using System;
using System.Collections;
using Rush.Physics;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// RAKOTOASIMBOLA Manasseh 
/// </summary>
public class HumanAgentController : MonoBehaviour
{
	[SerializeField] private Transform spaceShip;
	[SerializeField] private float stepPerFrame;
	[SerializeField] private GameObject bullet;
	[SerializeField] private Transform spawnBullet;
	
	private float x=0f;
	private float y=0f;

	private bool Collision = false;

	private float normalX = 0f;
	private float normalY = 0f;
	private float vx, vy;
	

	private void Awake()
	{
		vx = vy = 0f;
		x = spaceShip.position.x;
		y = spaceShip.position.y;
	}

	private void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//Shoot();
		}

		if (Collision)
		{
			if (normalX > 0) //à gauche
			{
				x -= stepPerFrame;
				spaceShip.position = new Vector2(x, y);
			}
			if (normalX < 0) //à droite
			{
				x += stepPerFrame;
				spaceShip.position = new Vector2(x, y);
			}
			if (normalY < 0) //en haut
			{
				y -= stepPerFrame;
				spaceShip.position = new Vector2(x, y);
			}
			if (normalY > 0) //en bas 
			{
				y += stepPerFrame;
				spaceShip.position = new Vector2(x, y);
			}
			
		}
		else if(!Collision)
		{
			
			InputSpaceShip();
			spaceShip.position= new Vector2(x,y);
		}
	}

	private void InputSpaceShip()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			y += stepPerFrame;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			y -= stepPerFrame;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			x -= stepPerFrame;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			x += stepPerFrame;
		}	
		
	}

	private void OnEnable()
	{
		CollisionScript.SendIsCollision += OnReceive;
	}

	private void OnDisable()
	{
		CollisionScript.SendIsCollision -= OnReceive;
	}

	public void OnReceive(bool isCollision,float nX, float nY)
	{
		Collision = isCollision;
		normalX = nX;
		normalY = nY;
	}
}
