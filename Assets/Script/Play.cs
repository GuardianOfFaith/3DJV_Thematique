using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour {

    public Dropdown m_player1;
    public Dropdown m_player2;
    public Button butt;
    private string test;

    // Use this for initialization
    void Start()
    {
        butt.onClick.AddListener(onClick);
    }
    
    void onClick () {
        test = m_player1.options[m_player1.value].text;
        if (test == "Human")
        {

        }
        if (test == "Random")
        {

        }
        if (test == "RollOut")
        {
        
        }
        if (test == "Disjkstra")
        {

        }
        
        test = m_player2.options[m_player2.value].text;
        
        if (test == "Human")
        {

        }
        if (test == "Random")
        {

        }
        if (test == "RollOut")
        {

        }
        if (test == "Disjkstra")
        {

        }

    }
}
