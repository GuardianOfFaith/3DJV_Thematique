using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Rush.Runners
{
	public class GameRunner : MonoBehaviour 
	{
        public GameObject player1;
        public GameObject player2;
        //public static GameRunner runner;
        //public Text t_win;

	    void Start()
        {
           //runner = this;
           // t_win.text = "";
           StartPlay(Play.instancePlay.var_p1, Play.instancePlay.var_p2);
        }

        //Select GameState des players depuis le menu principal
        void StartPlay(int gameStateP1, int gameStateP2)
        {
            
            switch (gameStateP1)
            {
                case 0:
                    player1.GetComponent<HumanAgentController>().enabled = true;
                    break;
                case 1:
                    player1.GetComponent<RandomAgent>().enabled = true;
                    break;
                case 2:
                    player1.GetComponent<RandomRollOut>().enabled = true;
                    break;
                case 3:
                    player1.GetComponent<Dijkstra>().enabled = true;
                    break;
            }
            switch (gameStateP2)
            {
                case 0:
                    player2.GetComponent<HumanAgentController>().enabled = true;
                    break;
                case 1:
                    player2.GetComponent<RandomAgent>().enabled = true;
                    break;
                case 2:
                    player2.GetComponent<RandomRollOut>().enabled = true;
                    break;
                case 3:
                    player2.GetComponent<Dijkstra>().enabled = true;
                    break;
            }


        }


        void endGame(int idPlayer)
        {
            //t_win.text = "Player" + 1 + "won !";
            Invoke("returnMenu", 3.5f);
        }

        void returnMenu()
        {
            Destroy(Play.instancePlay);
            SceneManager.LoadScene("MainMenu");
        }
    }
}

