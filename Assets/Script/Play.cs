using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {

    public Dropdown m_player1;
    public Dropdown m_player2;
    public Button butt;
    public int var_p1;
    public int var_p2;
    public static Play instancePlay;

    // Use this for initialization
    void Start()
    {
         instancePlay = this;
         butt.onClick.AddListener(onClick);
         DontDestroyOnLoad(this);
    }
    
     void onClick () {
        var_p1 = m_player1.value;
        var_p2 = m_player2.value;
        
        SceneManager.LoadSceneAsync("Arena");

    }
}
