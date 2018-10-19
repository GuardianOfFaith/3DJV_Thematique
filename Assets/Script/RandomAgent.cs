using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class RandomAgent : MonoBehaviour 
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
		ActionSpaceShip();
		spaceShip.position= new Vector2(x,y);
		Shoot();
	}

	private void ActionSpaceShip()
	{
		int randAction;
		randAction = Random.Range(0, 7);
		switch (randAction)
		{
			case 0:			//UP
				y += stepPerFrame;
				break;
			case 1:			//DOWN
				y -= stepPerFrame;
				break;
			case 2:			//RIGHT
				x += stepPerFrame;
				break;
			case 3:			//LEFT
				x -= stepPerFrame;
				break;
			case 4:			//UP+R
				y += stepPerFrame;
				x += stepPerFrame;
				break;
			case 5:			//UP+L
				y += stepPerFrame;
				x -= stepPerFrame;
				break;
			case 6:			//DOWN+R
				y -= stepPerFrame;
				x += stepPerFrame;
				break;
			case 7:			//DOWN+L
				y -= stepPerFrame;
				x -= stepPerFrame;
				break;
		}	
			
		x += Random.Range(-stepPerFrame, stepPerFrame);
		y += Random.Range(-stepPerFrame, stepPerFrame);
	}	

	private void Shoot()
	{	
	}
}
