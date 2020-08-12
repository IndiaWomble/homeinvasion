using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_anima : MonoBehaviour
{
    Animator player;
    public int damagecount = 0;
	
    // Use this for initialization
	void Start ()
    {
        player = GetComponent<Animator>();
        player.SetBool("coli", false);
        damagecount = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(player.GetCurrentAnimatorStateInfo(0).IsName("coli"))
        {
            player.SetBool("coli", false);
        }
        else
        {
            AI_Code.speed = AI_Code.speedtemp;
        }
        player.SetInteger("count", AnimationControl.hitcount);
    }
}

