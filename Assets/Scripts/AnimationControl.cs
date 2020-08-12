using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator player;
    float move;
    public static int hitcount = 0;
    public static bool isattacking = false;
    private int at = 0;
    private int tl = 0;
    int sls = 0;
    private AudioSource slashh;

    void Start()
    {
        player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetCurrentAnimatorStateInfo(0).IsName("hit1") || player.GetCurrentAnimatorStateInfo(0).IsName("hit2") || player.GetCurrentAnimatorStateInfo(0).IsName("ulti"))
        {
            isattacking = true;
        }
        else
        {
            isattacking = false;
            CharacterControl.moveVel = 5.0f;
        }
        if (player.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                hitcount++;
                player.SetInteger("anim", 3);
                isattacking = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            hitcount++;
            player.SetInteger("anim", 2);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {   
            player.SetInteger("anim", 4);
            CharacterControl.moveVel = 10.0f;
        }
        else if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            player.SetInteger("anim", 1);
            if (Input.GetAxis("Horizontal") > 0)
                this.transform.eulerAngles = new Vector3(0, 90, 0);
            else if (Input.GetAxis("Horizontal") < 0)
                this.transform.eulerAngles = new Vector3(0, -90, 0);
        }
        else
        {
            player.SetInteger("anim", 0);
        }
    }
}
