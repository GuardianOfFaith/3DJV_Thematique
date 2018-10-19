using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Dijkstra : MonoBehaviour {


    [SerializeField]
    private Transform spaceShip;
    [SerializeField]
    private Transform spaceShip2;
    [SerializeField]
    private float stepPerFrame;
    private float x = 0f;
    private float y = 0f;
    public int iteration;
    public Vector2 vec1;
    public Vector2 vec2;
    public bool chase;
    public bool leftside;

    void Awake () {
        chase = true;
        x = spaceShip.position.x;
        y = spaceShip.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        DijkstraAgent();
	}

    void DijkstraAgent() //sortir du graph si l'on tue ou change d'écran
    {
        //save etat du jeu
        float xa = spaceShip2.position.x;
        float ya = spaceShip2.position.y;
        int action;
        int[] list = new int[8];
        //créer graph et explorer
        for (int i =0; i<8;i++)
        {
            list[i] = 0;
        }
        //appel recursif
        action = DijkstraRec(list);
        //recupérer meilleur chemin

        //choisir action
        Debug.Log(action);
        switch (action)
        {
            case 0:         //UP
                y += stepPerFrame;
                break;
            case 1:         //DOWN
                y -= stepPerFrame;
                break;
            case 2:         //RIGHT
                x += stepPerFrame;
                break;
            case 3:         //LEFT
                x -= stepPerFrame;
                break;
        }
        spaceShip.position = new Vector2(x, y);
    }

    //list nodes dois comporté le cout de l'arc et la node parent
    int DijkstraRec(int[] listNodes)
    {
        
        int tmp = 0;
        int cost = 1000;
        int[] listtmp = new int[100];
        int tt = 0;
        foreach (int var in listNodes)
        {
            
            for (tmp = 0; tmp < 5; tmp++)
            {
                
                switch (tmp)//ponderer les arcs du graph
                {
                    case 0: //up
                        if (vec1.y < vec2.y && chase)
                        {
                            cost = 1;
                        }
                        if (vec1.y > vec2.y && chase)
                        {
                            cost = 5;
                        }
                        else //si même hauteur ou en attaque
                        {
                            cost = 2;
                        }
                        break;
                    case 1: //down
                        if (vec1.y > vec2.y && chase)
                        {
                            cost = 5;
                        }
                        if (vec1.y < vec2.y && chase)
                        {
                            cost = 1;
                        }
                        else //si même hauteur ou en attaque
                        {
                            cost = 2;
                        }
                        break;
                    case 2:         //RIGHT
                        if (leftside)
                        {
                            if (vec1.x + 100 > vec2.x)
                            {
                                cost = 5;
                            }
                            if (vec1.x + 100 <= vec2.x)
                            {
                                cost = 1;
                            }
                        }
                        if (!leftside)
                        {
                            if (vec1.x - 100 < vec2.x)
                            {
                                cost = 1;
                            }
                            if (vec1.x + 100 >= vec2.x)
                            {
                                cost = 5;
                            }
                        }
                        break;
                    case 3:         //LEFT
                        if (leftside)
                        {
                            if (vec1.x + 100 > vec2.x)
                            {
                                cost = 1;
                            }
                            if (vec1.x + 100 <= vec2.x)
                            {
                                cost = 5;
                            }
                        }
                        if (!leftside)
                        {
                            if (vec1.x - 100 < vec2.x)
                            {
                                cost = 5;
                            }
                            if (vec1.x + 100 >= vec2.x)
                            {
                                cost = 1;
                            }
                        }
                        break;              
                    /*case 4: //fire
                        if (Mathf.Abs(vec2.y - vec1.y) > 50 && Mathf.Abs(vec2.y - vec1.y) > 750)
                        { //si le joueur est sensiblement sur la même hauteur et pas trop loin
                            if (chase)
                            {
                                cost = 1;
                            }
                            else
                            {
                                cost = 2;
                            }
                        }
                        else
                        {
                            cost = 4;
                        }
                        break;*/
                    default:
                        cost = 1000;
                        break;
                }
                listtmp[tt] = cost+ listNodes[var];//crée la branche avec le cout
                Debug.Log(listtmp[tt]);
                Debug.Log(tt);
                if (true) //s'il n'est pas touché
                {
                    
                }
                if (false) //si atteindre but ou toucher
                {
                    tmp = tmp + 6; //sortir de la boucle et de la récursive
                }
            }
            if (tmp > 5)
            {
                return tt; //remonter au parent;
            }
            tt++;
            
        }
        if (listtmp.Length > 80)//iteraion^5 -125
        {
            return System.Array.IndexOf(listtmp, listtmp.Min());//vérifier si on atteint approximativement le nombre d'iteration
        }
        Debug.Log("ici");
        Debug.Log(System.Array.IndexOf(listtmp, listtmp[listtmp[DijkstraRec(listtmp)]]));
        return System.Array.IndexOf(listtmp, listtmp[listtmp[DijkstraRec(listtmp)]]);//retourn le résultat récursif du chemin le plus cours ou du premier chemin menant à la victoire


    }

    private void ActionSpaceShip(Transform ship)
    {
        int randAction;
        randAction = Random.Range(0, 7);
        switch (randAction)
        {
            case 0:         //UP
                y += stepPerFrame;
                break;
            case 1:         //DOWN
                y -= stepPerFrame;
                break;
            case 2:         //RIGHT
                x += stepPerFrame;
                break;
            case 3:         //LEFT
                x -= stepPerFrame;
                break;
            case 4:         //UP+R
                y += stepPerFrame;
                x += stepPerFrame;
                break;
            case 5:         //UP+L
                y += stepPerFrame;
                x -= stepPerFrame;
                break;
            case 6:         //DOWN+R
                y -= stepPerFrame;
                x += stepPerFrame;
                break;
            case 7:         //DOWN+L
                y -= stepPerFrame;
                x -= stepPerFrame;
                break;
        }

        x += Random.Range(-stepPerFrame, stepPerFrame);
        y += Random.Range(-stepPerFrame, stepPerFrame);
        vec2 = new Vector2(x, y);
    }

}
