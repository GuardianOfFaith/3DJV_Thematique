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

    public struct sp //structure du vaisseaux
    {
        public float x, y;

        public sp(float i, float j)
        {
            x = i;
            y = j;
        }

    }

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
        //sp s1 = new sp(spaceShip.position.x, spaceShip.position.y);
        int action;
        List<int> list = new List<int>();
        /*
        //créer graph et explorer
        for (int i =0; i<4;i++)
        {
            list[i] = 0;
        }*/
        //appel recursif
        action = DijkstraRec(list);
        //recupérer meilleur chemin
        Debug.Log(action);
        //choisir action
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
            case 4:
                break;            
        }
        spaceShip.position = new Vector2(x, y);
    }

    //list nodes dois comporté le cout de l'arc et la node parent
    int DijkstraRec(List<int> listNodes)
    {
        //save etat du jeu
        //sp s1 = new sp(spaceShip.position.x, spaceShip.position.y);

        int tmp = 0;
        int cost = 1000;
        List<int> listtmp = new List<int>();
        int tt = 0;
        for (int vari = 0;vari <listNodes.Count;vari++)
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
                       // s1.y += stepPerFrame;
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
                        //s1.y -= stepPerFrame;
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
                        //s1.x += stepPerFrame;
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
                        //s1.x -= stepPerFrame;
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
                listtmp.Add(cost+ listNodes[vari]);//crée la branche avec le cout
                if (true) //s'il n'est pas touché
                {
                    
                }
                if (false) //si atteindre but ou toucher
                {
                    tmp = tmp + 6; //sortir de la boucle et de la récursive
                }
                listtmp[listtmp.Count] = 1651;
            }
            if (tmp > 5)
            {
                return tt; //remonter au parent;
            }

            tt++;
        }

        if (listtmp.Count > iteration)
        {
            return listtmp.IndexOf(listtmp.Min());//vérifier si on atteint approximativement le nombre d'iteration
        }
        //   int tempo = DijkstraRec(listtmp);

        //sortie de secours pour eviter l'explosion du stack 
        if (leftside)
            return 2;
        else
            return 3;
        //listtmp.IndexOf(listtmp[]);//retourn le résultat récursif du chemin le plus cours ou du premier chemin menant à la victoire

    }
}
