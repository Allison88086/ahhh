using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Threading;
public class GemScript : MonoBehaviour
{
    private Vector2 movementVector; //variable (field since in a class)
    private Rigidbody2D rb;
    [SerializeField] int speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Nothing happened");
        }
    }
}
