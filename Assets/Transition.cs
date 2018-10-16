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

    void Start()
    {
        arena = 0;
        cam = Camera.main;
        p1 = GameObject.FindWithTag("Player1");
        p2 = GameObject.FindWithTag("Player2");
        i = 11;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (arena == 0 && this.tag == ("TriggerOff") && col.CompareTag("Player1")/* && TODO DOMINATE*/)
        {
            cam.transform.position = new Vector3(cam.transform.position.x + i, cam.transform.position.y, cam.transform.position.z);
            //SetPosition to P2
            arena++;
        }
        if (arena == 1 && this.tag == ("TriggerOff") && col.CompareTag("Player2")/* && TODO DOMINATE*/)
        {
            cam.transform.position = new Vector3(cam.transform.position.x - i, cam.transform.position.y, cam.transform.position.z);
            //SetPosition to P1
            arena--;
        }
        if (arena == 0 && this.tag == ("TriggerDef") && col.CompareTag("Player2")/* && TODO DOMINATE*/)
        {
            cam.transform.position = new Vector3(cam.transform.position.x - i, cam.transform.position.y, cam.transform.position.z);
            //SetPosition to P1
            arena--;
        }
        if (arena == -1 && this.tag == ("TriggerDef") && col.CompareTag("Player1")/* && TODO DOMINATE*/)
        {
            cam.transform.position = new Vector3(cam.transform.position.x - i, cam.transform.position.y, cam.transform.position.z);
            //SetPosition to P1
            arena++;
        }

        if (arena == -1 && this.tag == ("TriggerDef") && col.CompareTag("Player2")/* && TODO DOMINATE*/)
        {
            //TODO CALL LOSE
        }
        if (arena == 1 && this.tag == ("TriggerOff") && col.CompareTag("Player1")/* && TODO DOMINATE*/)
        {
            //TODO CALL WIN;
        }
    }

}
