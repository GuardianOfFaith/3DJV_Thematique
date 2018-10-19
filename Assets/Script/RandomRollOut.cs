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

    public struct sp //structure du vaisseaux
    {
        public float x, y;

        public sp (float i, float j)
        {
            x = i;
            y = j;
        }

    }

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
        int[] rew = { 0, 0, 0, 0, 0 };
        for (int z = 0; z < 5; z++)
        {
            sp s1 = new sp(spaceShip.position.x, spaceShip.position.y);
            sp s2 = new sp(spaceShip2.position.x, spaceShip2.position.y);
            ActionSpaceShip(s2.x, s2.y);

            rew[z] = Reward(z, false, s1);
            if (iteration > 0)
            {
                int tmp = RRAgentRecur(0, false, s1, s2);
                rew[z] = tmp + rew[z];
            }
        }
        int tmp2 = System.Array.IndexOf(rew, rew.Max());
       
        if (tmp2 == 0)
        {
            y += stepPerFrame;
        }
        if (tmp2 == 1)
        {
            y -= stepPerFrame;
        }
        if (tmp2 == 2)
        {
            x -= stepPerFrame;
        }
        if (tmp2 == 3)
        {
            x += stepPerFrame;
        }
        if (tmp2 ==4)
        {
            //Shoot();
        }
        spaceShip.position = new Vector2(x, y);
    }

    int RRAgentRecur(int w, bool bill, sp i, sp j)
    {
        int var = 0;
        int[] rewlist = { 0, 0, 0, 0, 0 };
        //itération adversaire state en random
        for (int y = 0; y < 5; y++)
        {
            sp k = new sp(j.x, j.y);
            sp p = new sp(i.x, i.y);
            ActionSpaceShip(k.x, k.y);
            rewlist[y] = Reward(y, bill, p);
            if (w+1 < iteration)
            {
                var = RRAgentRecur(w + 1, bill, p, k);
            }
           
            rewlist[y] = rewlist[y] + var;
        }
        return rewlist.Max();
    }

    int Reward(int state, bool left, sp p)
    {
        if (state == 0)
        {
            p.y += stepPerFrame;
            return 1;
        }
        if (state == 1)
        {
            p.y -= stepPerFrame;
            return 1;
        }
        if (state == 2)
        {
            if (!left)
            {
                p.x += stepPerFrame;
                return 3;
            }
            else
            {
                p.x += stepPerFrame;
                return 1;
            }
        }
        if (state == 3)
        {
            if (left)
            {
                p.x -= stepPerFrame;
                return 3;
            }
            else
            {
                p.x += stepPerFrame;
                return 1;
            }
        }
        if (state == 4)
        {
            if (false) //Check touch
            {
                return 25;
            }
            else
            {
                return 2;
            }
        }
        return 0;
    }

    //random calculs
    private void ActionSpaceShip(float u, float v)
    {
        int randAction;
        randAction = Random.Range(0, 3);
        switch (randAction)
        {
            case 0:         //UP
                u += stepPerFrame;
                break;
            case 1:         //DOWN
                u -= stepPerFrame;
                break;
            case 2:         //RIGHT
                v += stepPerFrame;
                break;
            case 3:         //LEFT
                v -= stepPerFrame;
                break;
        }

        u += Random.Range(-stepPerFrame, stepPerFrame);
        v += Random.Range(-stepPerFrame, stepPerFrame);
    }
}
