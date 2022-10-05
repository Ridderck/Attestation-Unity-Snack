using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFood : MonoBehaviour
{
    private SnakeTail SnakeTail;
    private GameObject SnakeHead;

    private void Start()
    {
        SnakeHead = GameObject.Find("Snake");

    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {

           

        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        SnakeTail.AddCircle();   
    }*/
}
