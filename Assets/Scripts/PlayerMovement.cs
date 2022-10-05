using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public TMP_Text nextBall;
    public GameObject[] fireBalls;
    public AudioSource gameplay;
    public AudioClip explosion;
    public AudioClip fire;
    public static PlayerMovement instance;
    public int index = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        m_camera = Camera.main;  // Don't keep calling Camera.main
        nextBall.text = fireBalls[index].name;
        Debug.Log(fireBalls[index] + " ball is selected");
    }

    void Update()
    {
        var lookAtPos = Input.mousePosition;
        lookAtPos.z = m_camera.transform.position.y - transform.position.y;
        lookAtPos = m_camera.ScreenToWorldPoint(lookAtPos);
        transform.forward = lookAtPos - transform.position;

        if (Input.GetMouseButtonUp(0))
        {
            if (SpawnManager.instance.gameover == false)
            {
                index = Random.Range(0, fireBalls.Length);
                nextBall.text = fireBalls[index].name;
                Debug.Log(fireBalls[index].name + " Ball is selected");
            }
                
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (SpawnManager.instance.gameover == false)
            {
                spawnball();
                gameplay.PlayOneShot(fire);

            }

        }

    }

    Camera m_camera;

    void spawnball()
    {
        Instantiate(fireBalls[index], transform.position, transform.rotation,transform.parent);
    }
    public void explosions()
    {
        gameplay.PlayOneShot(explosion);
    }



    

    
}

