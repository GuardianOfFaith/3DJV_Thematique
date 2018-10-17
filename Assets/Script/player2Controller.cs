using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using UnityEditor;
using UnityEngine;

public class player2Controller : MonoBehaviour
{
	[SerializeField] private Transform spatialShip;
	[SerializeField] private Rigidbody2D rbSpatialShip;
	[SerializeField] private float speed = 10f;
	[SerializeField] private fire2Script fire;
    [SerializeField] private GameObject adv;
    [SerializeField] private GameObject us;

    private Vector2 move = Vector2.zero;
    public int rand; //random pour routine random
    public int i; //pour tester les capacités de la RR sur la durée
	private bool facingDirection=true;
	
	void Update ()
	{	
		//move.x = Input.GetAxis("HorizontalX1");
		//move.y = Input.GetAxis("VerticalY1");

        
		if (move.x>0 && !facingDirection)
		{
			flipDirection();
		}
		else if (move.x < 0 && facingDirection)
		{
			flipDirection();
		}
		
		if (Input.GetKeyDown(KeyCode.M))
		{
			StartCoroutine(fire.shoot());
		}

	}

	void FixedUpdate()
	{
        RRAgent();
        rbSpatialShip.velocity = move * speed;

	}
	
	// tourner le vaisseau vers la direction appuyée
	void flipDirection()
	{
		spatialShip.Rotate(0f,180f,0f);
		facingDirection = !facingDirection;
	}

    void random()
    {

        rand = Mathf.RoundToInt(Random.value * 5);

        switch (rand)
        {
            case 1:
                move.x = -1;
                
                break;
            case 2:
                move.y = 1;
                break;
            case 3:
                move.y = - 1;
                break;
            case 4:
                StartCoroutine(fire.shoot());
                break;
            default:
                move.x = 1;
                break;
        }
    }

    int random(Vector3 pos)
    {
        
        rand = Mathf.RoundToInt(Random.value * 5);
        
        switch (rand)
        {
            case 1:
                //pos = new Vector3((pos.x - 1), pos.y, pos.z);
                pos.x = pos.x - 1;
                break;
            case 2:
                pos.y = pos.y + 1;
                break;
            case 3:
                pos.y = pos.y - 1;
                break;
            case 4:
                StartCoroutine(fire.shoot());
                break;
            default:
                pos.x = pos.x + 1;
                break;
        }
        Debug.Log(rand);
        return rand;
    }

    void RRAgent()
    {
        int[] actionList = new int[5] { 0,0,0,0,0 };

        for (int z = 0; z < 5; z++)
        { 
            int y = 0;
            Vector3 advCPos = GameObject.FindWithTag("Player1").transform.position;
            int advRew = 0;
            Vector3 usCPos = GameObject.FindWithTag("Player2").transform.position;
            int usRew = 0;

            //bool dominate;
            
            while (y < i){
                Reward(random(advCPos), true, advRew);
                Reward(random(usCPos), false, usRew);
                Debug.Log(usCPos);
                Debug.Log(usRew);
            }
            actionList[z] = usRew;
            
        }
        
        switch (actionList[System.Array.IndexOf(actionList, actionList.Max())])
        {
            case 0:
                move.x = - 1;
                break;
            case 1:
                move.y = 1;
                break;
            case 2:
                move.y = - 1;
                break;
            case 3:
                StartCoroutine(fire.shoot());
                break;
            default:
                move.x = 1;
                break;
        }


    }

    void Reward(int state, bool atk, int rew)
    {
        switch (state)
        {
            case 1:
                if (!atk)
                {
                    rew = rew + 3;
                }
                break;
            case 2:
                rew++;
                break;
            case 3:
                rew++;
                break;
            case 4:
                //Check touch
                break;
            default:
                if (atk)
                {
                    rew = rew + 3;
                }
                break;
        }
    }
}
