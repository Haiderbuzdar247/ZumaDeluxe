using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SpawnManager : MonoBehaviour
{
    public GameObject gameovertext;
    public GameObject winnerText;
    public int Level = 1;
    private int spawnball;
    public TMP_Text score;
    public TMP_Text chances;
    private int chance = 5;
    private int scoree = 0;
    public GameObject[] enemyballs;
    public static SpawnManager instance;
    public bool gameover=  false;
    private void Awake()
    {
        spawnball = Level * 10;
        instance = this;
    }
    void Start()
    {
        gameovertext.gameObject.SetActive(false);
        winnerText.gameObject.SetActive(false);

        score.text = scoree.ToString();
        chances.text = chance.ToString();
        InvokeRepeating("enemySpawnBall", 1, 1);

        
    }

    
    void Update()
    {
        //if ()
        //{
        //    winnerText.gameObject.SetActive(true);

        //}
    }
    void  enemySpawnBall()
    {
        if (!gameover)
        {
            if (spawnball >= 1)
            {
                spawnball--;
                GameObject go = Instantiate(enemyballs[Random.Range(0, enemyballs.Length)], transform.position, Quaternion.identity, transform.parent);
                go.SetActive(true);
            }
            
        }
        
        
    }
    public void scoreadd()
    {
        scoree++;
        score.text = scoree.ToString();
    }
    public void chancesub()
    {
        chance--;
        chances.text = chance.ToString();
        if (chance < 0)
        {
            gameover = true;
            gameovertext.gameObject.SetActive(true);

        }

    }
}
