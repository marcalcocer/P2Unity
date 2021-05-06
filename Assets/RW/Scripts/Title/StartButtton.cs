using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButtton : MonoBehaviour
{
    public Vector3 minPos;
    public Vector3 maxPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (ray.origin.x >= minPos.x & ray.origin.y >= minPos.y && ray.origin.z >= minPos.z && ray.origin.x <= maxPos.x && ray.origin.y <= maxPos.y 
                && ray.origin.z <= maxPos.z)
            {
                SceneManager.LoadScene("Game");
            }
        }
    }

}
