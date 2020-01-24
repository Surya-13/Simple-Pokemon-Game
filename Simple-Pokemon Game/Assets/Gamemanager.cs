using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public Text t;
    private void Start()
    {   
        if(blast.scy != true)
        {
            t.text = "Scyther Won!!";
        }
        if (blast.scy != false)
        {
            t.text = "Blastoise Won!!";
        }

    }
    public void Restart()
    {
        blast.scy = true;
        blast.health1 = 100f;
        Button1.health2 = 100f;
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
