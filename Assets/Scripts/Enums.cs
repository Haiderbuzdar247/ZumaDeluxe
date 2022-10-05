using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums : MonoBehaviour
{
    public Color balColor;
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (this.balColor == other.GetComponent<Enums>().balColor)
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
            else
            {

            }
        }
    }
}
public enum Color
{
    Red,
    BlUe,
    Yellow

}
