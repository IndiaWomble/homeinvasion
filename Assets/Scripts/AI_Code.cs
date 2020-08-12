using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AI_Code : MonoBehaviour
{
    private Vector3 spawnpoint1, spawnpoint2, spawnpoint;
    float randomnum;
    public GameObject GameOverPanel;
    public int damagecount = 0;
    public static GameObject[] enemies;
    private Vector3 target;
    public Transform house;
    private int numberofenemies = 20,i, j, ne;
    private int characterinstantiate_Index;
    private int flag = 0;
    private int rot = 0;
    private float EnemiesIntan_Timeinterval = 3f;
    public static  float speed = 0.03f;
    int a = 0;
    public static float speedtemp=0.03f;
    int sam = 0;
    private Vector2 v;
    public GameObject enemyob;

    void Start()
    {
        Time.timeScale = 1;
        GameOverPanel.SetActive(false);
        float time = Time.fixedTime;   
        v= new Vector2(56, 56);
        InvokeRepeating("instantiatew", 1, EnemiesIntan_Timeinterval);
        spawnpoint1 = new Vector3(-18, 0, 0.5f);
        spawnpoint2 = new Vector3(18, 0, 0.5f);
        enemies = new GameObject[20];
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        leveldesi();
        sam++;
        enemiesmovement();
    }

    void leveldesi()
    {
        if (sam % 900 == 0)
        {
            if (speed < 0.1f)
            {
                speed = speed + 0.009f;
                speedtemp = speed;
            }
        }
    }

    void instantiatew()
    {
        flag = 0;
        ne = Random.Range(1, 4);
        randomnum = Random.Range(1, 3);
        if (randomnum == 1)
        {
            rot = 90;
            spawnpoint = spawnpoint1;
        }
        else
        {
            rot = -90;
            spawnpoint = spawnpoint2;
        }
        for (i = 0; i < numberofenemies; i++)
        {
            if (enemies[i] == null)
            {
                flag = 1;
                characterinstantiate_Index = i;
                break;
            }
        }
        if (flag == 0)
        {
            characterinstantiate_Index = numberofenemies++;
        }
        enemies[characterinstantiate_Index] = Instantiate(enemyob, spawnpoint, this.transform.rotation);
        enemies[characterinstantiate_Index].transform.Rotate(0, rot, 0);
    }

    void enemiesmovement()
    {
        for (int ii = 0; ii < numberofenemies; ii++)
        {
            if (enemies[ii] != null)
            {
                enemies[ii].transform.position = Vector3.MoveTowards(enemies[ii].transform.position, target, speed);
            }
        }
    }
}

