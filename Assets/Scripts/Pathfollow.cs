using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfollow : MonoBehaviour
{
    public List<Transform> targets;
    private int currentpos = 0;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != targets[currentpos].position && SpawnManager.instance.gameover==false )
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, targets[currentpos].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            if (currentpos < (targets.Count-1))
            {
                currentpos = (currentpos + 1);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EndPoint"))
        {
            SpawnManager.instance.gameover = true;
            SpawnManager.instance.gameovertext.gameObject.SetActive(true);

        }
    }
}
