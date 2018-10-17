using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
	[SerializeField] private Transform spatialShip;
	[SerializeField] private Rigidbody2D rbSpatialShip;
	[SerializeField] private float speed = 10f;
	[SerializeField] private fireScript fire;

    
	private Vector2 move = Vector2.zero;
	private bool facingDirection=true;
    public Text t_win;
    
    void Start()
    {
        t_win.text = "";
        StartPlay(GameObject.Find("GameMods").GetComponent<play>().var_p1);
    }

    //Select gameMode depuis le menu principal
    void StartPlay(int gamemode)
    {
        //set Script 
        
    }

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


    void Win()
    {
        t_win.text = "Player 1 won !";
        Invoke("returnMenu", 5.0f);
    }

    void Lose()
    {
        t_win.text = "Player 2 won !";
        Invoke("returnMenu", 5.0f);
    }

    void returnMenu()
    {
        Destroy(GameObject.Find("GameMods"));
        SceneManager.LoadScene("SampleScene");
    }
}
