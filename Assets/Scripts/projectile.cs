using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public Transform player;
    private readonly float x = 25.0f;
    private readonly float y = 55.0f;
    private ParticleSystem ps;
    private AudioSource fadee;
    private float exp_direction;
    public static Quaternion rot;
    private int direction; 

    private void Start()
    {
        ps = GameObject.Find("Enemy_EXP").GetComponent<ParticleSystem>();
        fadee = GameObject.Find("explosion").GetComponent<AudioSource>();
        transform.position = new Vector3(0.0f, 7.0f, 4.0f);
        if (player.rotation == new Quaternion(0.0f, 90.0f, 0.0f, 0.0f))
        {
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(x, y, 0.0f));
            exp_direction = 9.3f;
            direction = 1; 
        }
        else if (player.rotation == new Quaternion(0.0f, -90.0f, 0.0f, 0.0f))
        {
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(-x, y, 0.0f));
            exp_direction = -9.3f;
            direction = 0;
        }
    }

    private void Update()
    {
        if (transform.position.y <= 0.5f)
        {
            Destroy(gameObject);
            Action();
            foreach (GameObject preenemy in AI_Code.enemies)
            {
                if(preenemy != null)
                {
                    if (direction == 0)
                    {
                        if (preenemy.transform.position.x < 0.0f)
                        {
                            Action();
                            Destroy(preenemy);
                        }
                    }
                    else if (direction == 1)
                    {
                        if (preenemy.transform.position.x > 0.0f)
                        {
                            Action();
                            Destroy(preenemy);
                        }
                    }
                }
            }
        }
    }

    private void Action()
    {
        GameObject.Find("Enemy_EXP").transform.position = new Vector3(exp_direction, 3.0f, 0.0f);
        ps.Play();
        fadee.Play();
    }
}
