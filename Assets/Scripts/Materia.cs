using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materia : MonoBehaviour
{
    // params
    [SerializeField] BusterSword bustersword1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

    // state
    Vector2 swordToMateriaVector;
    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        swordToMateriaVector = transform.position - bustersword1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       

        if(!hasStarted)
        {
            LockSwordToMateria();
            LaunchOnMouseClick();
        }
        
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockSwordToMateria()
    {
        Vector2 swordPos = new Vector2(bustersword1.transform.position.x, bustersword1.transform.position.y);
        transform.position = swordPos + swordToMateriaVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
        }
       
    }
}
