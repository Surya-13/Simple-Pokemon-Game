using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class blast : MonoBehaviour
{
    public Animator b;
    public Text t;
    public static float health1 = 100f;
    public ParticleSystem P;
    public ParticleSystem P1;
    public static bool scy = true;
    private float time = 0f;
    private bool set = true;
    public Transform obj;
    private void Start()
    {
        t.text = health1.ToString("0");
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 1.5f)
        {
            set = true;
        }
        if (health1 <= 0f)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void Clicked()
    {
        if (set == true)
        {
            b.SetBool("AttackB", true);
            Invoke("StopAnimation", 2f);
            P.Play();
            P1.Play();
            time = 0f;
            set = false;
        }
    }
    private void StopAnimation()
    {
        b.SetBool("AttackB", false);
        health1 -= Random.Range(20f, 40f);
        t.text = health1.ToString("0");

    }
    public void Rotate()
    {
        obj.Rotate(0f,10f,0f);
    }
}
