using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private float inputDelay;
    private float moveInput;
    public float speed = 5.0f;
    public float dashVel = 30.0f;
    public static float  moveVel;
    private Rigidbody player;
    private Vector3 vel;
    public Transform target;
    public GameObject cannon_ball;
    private Vector3 spawn;
    private GameObject cannon;
    public static float cooldowntime = 0.0f;
    public static int direction;

    // Use this for initialization
    void Start()
    {
        moveVel = speed;
        player = GetComponent<Rigidbody>();
        moveInput = 0;
        inputDelay = 0.1f;
        spawn = new Vector3(0.0f, 7.0f, 4.0f);
    }

    void FixedUpdate()
    {
        if (player.transform.position.x <= -15.5f && direction == 0)
            player.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        else if (player.transform.position.x <= -15.5f && direction == 1)
        {
            getInput();
            move();
        }
        else if(player.transform.position.x >= 15.5f && direction == 1)
            player.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        else if(player.transform.position.x >= 15.5f && direction == 0)
        {
            getInput();
            move();
        }
        else
        {
            getInput();
            move();
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (cooldowntime == 0.0f || cooldowntime < Time.time)
            {
                cannon = Instantiate(cannon_ball, spawn, projectile.rot);
                cannon.SetActive(true);
                cooldowntime = Time.time + 10.0f;
            }
        }
        if (player.rotation == new Quaternion(0.0f, 90.0f, 0.0f, 0.0f))
            direction = 1;
        else if (player.rotation == new Quaternion(0.0f, -90.0f, 0.0f, 0.0f))
            direction = 0;
    }

    void getInput()
    {
        moveInput = Input.GetAxis("Horizontal");
    }

    void move()
    {
        if (Mathf.Abs(moveInput) > inputDelay)
            player.velocity = new Vector3(moveInput * moveVel, 0, 0);
        else
            player.velocity = new Vector3(0, 0, 0);
    }

    void turn()
    {
        this.transform.LookAt(target);
    }

    void dash()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            moveVel = dashVel;
            cooldown();
        }
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(2);
        moveVel = speed;
    }
}
