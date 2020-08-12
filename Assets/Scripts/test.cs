using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class test : MonoBehaviour
{
    public static bool atack_animation = false;
    public Text scoreText;
    private int hitChecker;
    private int co;
    private float score = 0;
    private ParticleSystem ps;
    private AudioSource slashh;
    private AudioSource fadee;

    private void Start()
    {
        hitChecker = 0;
        scoreText.text = "Score : 0";
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Enemy new(Clone)"))
        {
            if (AnimationControl.isattacking)  //anime state
            {
                atack_animation = true;
                other.GetComponent<Animator>().SetBool("coli", true);
                AI_Code.speed = -100f;        
                other.GetComponent<enemy_anima>().damagecount++;
                slashh = GameObject.Find("slash").GetComponent<AudioSource>();
                slashh.Play();
                if (other.GetComponent<enemy_anima>().damagecount>2)
                {
                    score = score + 10;
                    scoreText.text = "Score : " + score.ToString();
                    GameObject.Find("fade").transform.position = other.transform.position;
                    ps = GameObject.Find("fade").GetComponent<ParticleSystem>();
                    ps.Play();
                    Destroy(other.gameObject);
                    fadee = GameObject.Find("Fades").GetComponent<AudioSource>();
                    fadee.Play();
                }
            }
        }
    }
}

