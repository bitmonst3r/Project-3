using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TestRaycast : MonoBehaviour
{
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
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 1000, Color.red);
            RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, ray.direction);

            if(hit2D.collider != null)
            {
                Debug.Log("I hit: " + hit2D.collider.name);
            }
            else
            {
                Debug.Log("hit nothing");
            }
        }
    }
}
