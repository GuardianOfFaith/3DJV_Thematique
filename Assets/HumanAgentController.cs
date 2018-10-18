using System;
using System.Collections;
using UnityEngine;
public class HumanAgentController : MonoBehaviour
{
	[SerializeField] private Transform spaceShip;
	[SerializeField] private float stepPerFrame;
	private float x=0f;
	private float y=0f;

	private void Awake()
	{
		x = spaceShip.position.x;
		y = spaceShip.position.y;
	}

	private void Update()
	{
		InputSpaceShip();
		spaceShip.position= new Vector2(x,y);
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Shoot();
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
		//Debug.Log("( x = "+x+" ; y = "+y+" )");
	}

	private void Shoot()
	{
	}

}
