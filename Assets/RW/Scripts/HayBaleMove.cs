using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayBaleMove : MonoBehaviour
{
    public float speed = 10;
    public float gravityForce = 1.0f;
    public float flootHeight;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 disp = Vector3.forward * speed * Time.deltaTime; // Z displacement
        
        if(transform.position.y > flootHeight) //Y displacement (simulate gravity)
        {
            disp += (Vector3.down * gravityForce);
        }

        transform.Translate(disp);

    }
}
