using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class enemies_house_collision : MonoBehaviour
{
    public Image healthBar;
    public static float startHealth;
    public static int limiterInHealth = 0;
    private int count = 0;
    public float health;
    public GameObject GameOverPanel;
    private ParticleSystem ps;
    private AudioSource exp;

	// Use this for initialization
	void Start ()
    {
        startHealth = 100;
        health = startHealth;
        count = 0;
	}

    private void Update()
    {
        EndState();
    }

    void OnTriggerEnter(Collider other)
    {       
        if(other.name.Equals("HOME"))
        {
            count++;
            limiterInHealth++;
            health = 100 - limiterInHealth * 10;
            healthBar.fillAmount = health / startHealth; 
            GameObject.Find("Enemy_EXP").transform.position = this.transform.position + new Vector3(0, 2.5f, 0);
            exp = GameObject.Find("explosion").GetComponent<AudioSource>();
            ps = GameObject.Find("Enemy_EXP").GetComponent<ParticleSystem>();
            ps.Play();
            exp.Play();
            Destroy(this.gameObject);
        }
    }

    void EndState()
    {
        if (healthBar.fillAmount < 0.1)
        {
            limiterInHealth = 0;
            SceneManager.LoadScene("gameover");
        }
    }
}
