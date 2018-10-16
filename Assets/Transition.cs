using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

    public Camera cam;
    public int speed = 4;
    public int arena;
    public int i;
    public GameObject p1;
    public GameObject p2;
    public GameObject S1;
    public GameObject S2;
    public GameObject[] rD;
    public GameObject[] rO;

    void Start()
    {
        arena = 0; //Centre l'arène
        cam = Camera.main;
        i = 11; //déplacement d'arène a arène pour la camera
        p1 = GameObject.FindWithTag("Player1"); //recuperer les joueurs
        p2 = GameObject.FindWithTag("Player2");
        rD = GameObject.FindGameObjectsWithTag("RespawnDef"); //recuperer les spawners de chaque joueurs
        rO = GameObject.FindGameObjectsWithTag("RespawnOff");
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (arena == 0 && this.tag == ("TriggerOff") && col.CompareTag("Player1")/* && TODO DOMINATE*/)
        {
            // 0>1 Player 1 avance, player 2 est replacé
            cam.transform.position = new Vector3(cam.transform.position.x + i, cam.transform.position.y, cam.transform.position.z);
            p2.transform.position = rD[1-arena].transform.position;
            arena++;
        }
        if (arena == 1 && this.tag == ("TriggerOff") && col.CompareTag("Player2")/* && TODO DOMINATE*/)
        {
            // 1>0 Player 1 est replacé, Player 2 avance
            cam.transform.position = new Vector3(cam.transform.position.x - i, cam.transform.position.y, cam.transform.position.z);
            p1.transform.position = rO[1 - arena].transform.position;
            arena--;
        }
        if (arena == 0 && this.tag == ("TriggerDef") && col.CompareTag("Player2")/* && TODO DOMINATE*/)
        {
            // 0>-1 Player 1 est replacé, Player 2 avance
            cam.transform.position = new Vector3(cam.transform.position.x - i, cam.transform.position.y, cam.transform.position.z);
            p1.transform.position = rO[1 - arena].transform.position;
            arena--;
        }
        if (arena == -1 && this.tag == ("TriggerDef") && col.CompareTag("Player1")/* && TODO DOMINATE*/)
        {
            // -1>0 Player 1 Avance, Player 2 est replacé
            cam.transform.position = new Vector3(cam.transform.position.x - i, cam.transform.position.y, cam.transform.position.z);
            p2.transform.position = rD[1 - arena].transform.position;
            arena++;
        }

        if (arena == -1 && this.tag == ("TriggerDef") && col.CompareTag("Player2")/* && TODO DOMINATE*/)
        {
            //Player 2 Gagne
            //TODO CALL LOSE
        }
        if (arena == 1 && this.tag == ("TriggerOff") && col.CompareTag("Player1")/* && TODO DOMINATE*/)
        {
            //Player 1 Gagne
            //TODO CALL WIN;
        }
    }

}
