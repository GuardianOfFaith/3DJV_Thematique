using System;
using System.Collections;
using UnityEngine;
public class HumanAgentController : MonoBehaviour
{
	[SerializeField] private Transform spaceShip;
	[SerializeField] private float stepPerFrame;
    [SerializeField] private bool left;
    private float x=0f;
	private float y=0f;


	private void Awake()
	{
		x = spaceShip.position.x;
		y = spaceShip.position.y;
	}

	private void Update()
	{
        if (left)
        {
            InputSpaceShip();
        }
        else
        {
            InputSpaceShip();
        }
		spaceShip.position= new Vector2(x,y);	
	}

    private void InputSpaceShip()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            y += stepPerFrame;
        }
        if (Input.GetKey(KeyCode.S))
        {
            y -= stepPerFrame;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            x -= stepPerFrame;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            x += stepPerFrame;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void InputSpaceShip2()
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
        if (Input.GetKeyDown(KeyCode.M))
        {
            Shoot();
        }
    }

	private void Shoot()
	{
	}

}
