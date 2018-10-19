using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomRollOut : MonoBehaviour {

    [SerializeField]
    private Transform spaceShip;
    [SerializeField]
    private Transform spaceShip2;
    [SerializeField]
    private float stepPerFrame;
    private float x = 0f;
    private float y = 0f;
    public int iteration;

    private void Awake()
    {
        x = spaceShip.position.x;
        y = spaceShip.position.y;
    }

	// Update is called once per frame
	void Update () {
        RRAgent();
	}

    void RRAgent()
    {
        float xa = spaceShip2.position.x;
        float ya = spaceShip2.position.y;
        
        int[] rew = { 0, 0, 0, 0, 0 };
        for (int z = 0; z < 5; z++)
        {
            rew[z] = Reward(z, false);
            if (iteration > 0)
            {
                int tmp = RRAgentRecur(0, false);
                rew[z] = tmp + rew[z];
            }
        }
        Debug.Log(System.Array.IndexOf(rew, rew.Max()));
        switch (System.Array.IndexOf(rew, rew.Max()))
        {
            case 0:
                x -= stepPerFrame;
                break;
            case 1:
                y += stepPerFrame;
                break;
            case 2:
                y -= stepPerFrame;
                break;
            case 3:
                //StartCoroutine(fire.shoot());
                break;
            default:
                x += stepPerFrame;
                break;
        }
        spaceShip.position = new Vector2(x, y);
    }

    int RRAgentRecur(int w, bool bill)
    {
        int var = 0;
        int[] rewlist = { 0, 0, 0, 0, 0 };
        //itération adversaire state en random
        for (int y = 0; y < 5; y++)
        {
            if (w < iteration)
            {
                var = RRAgentRecur(w + 1, bill);
            }
            rewlist[y] = Reward(y, bill);
            rewlist[y] = rewlist[y] + var;
        }
        return rewlist.Max();
    }

    int Reward(int state, bool atk)
    {
        switch (state)
        {
            case 1:
                if (!atk)
                {
                    return 3;
                }
                else
                {
                    return 1;
                }
                break;
            case 2:
                return 1;
                break;
            case 3:
                return 1;
                break;
            case 4:
                if (false) //Check touch
                {
                    return 25;
                }
                else
                {
                    return 2;
                }
                break;
            default:
                if (atk)
                {
                    return 3;
                }
                else
                {
                    return 1;
                }
                break;
        }
    }
}
