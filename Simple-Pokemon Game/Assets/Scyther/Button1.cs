using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button1 : MonoBehaviour
{
    public Animator a;
    public Animator b;
    public Text t;
    public static float health2 = 100f;
    private float time = 0f;
    private bool set = true;
    public Transform obj;
    private void Start()
    {
        t.text = health2.ToString("0");
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 1.2f)
        {
            set = true;
        }
        if(health2 <= 0f)
        {
            blast.scy = false;
            SceneManager.LoadScene(1);
        }
    }
    public void Clicked()
    {
        if (set == true)
        {
            a.SetBool("Attack", true);
            b.SetBool("AttackB", true);

            Invoke("StopAnimation", 1.2f);
            time = 0f;
            set = false;
        }
    }
    private void StopAnimation()
    {
        a.SetBool("Attack", false);
        b.SetBool("AttackB", false);
        health2 -= Random.Range(20f, 40f);
        t.text = health2.ToString("0");

    }

    public void Rotate()
    {
        obj.Rotate(0f, 10f, 0f);
    }
}
