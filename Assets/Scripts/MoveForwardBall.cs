using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveForwardBall : MonoBehaviour
{
    public int speed;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward *speed *Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.GetComponent<Renderer>().material.color == collision.gameObject.GetComponent<Renderer>().material.color)
        {
            PlayerMovement.instance.explosions();
            SpawnManager.instance.scoreadd();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            PlayerMovement.instance.explosions();
            SpawnManager.instance.chancesub();
            Destroy(gameObject);

        }
    }
}
