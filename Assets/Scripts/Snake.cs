using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MoveDirection
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}

public class Snake : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform head;
    [SerializeField] private Transform body;

    [Header("Parameters")]
    [SerializeField] private float moveTimerMax =1f;
    [SerializeField] private float speed = 5f;


    private MoveDirection moveDirection;
    private Vector3 direction;

    private Vector3 pos;

    [Header("Test")]
    public float moveTimer;
    public List<Transform> parts;

    private void Start()
    {
        moveDirection = MoveDirection.RIGHT;
        direction = Vector3.right;

        head.position = new Vector3(Mathf.RoundToInt(head.position.x),Mathf.RoundToInt(head.position.y));

        parts = new List<Transform>();
        parts.Add(head);
    }

    private void Update()
    {
        ManageInput();

        moveTimer += speed * Time.deltaTime;

        if (moveTimer > moveTimerMax)
        {
            for (int i = parts.Count - 1; i > 0; i--) // move body part in reverse order except head
            {
                parts[i].position = parts[i - 1].position;
            }

            head.position += direction;
            moveTimer = 0;
        }


        if (Input.GetKeyDown(KeyCode.Space)) 
            Grow();
    }

    private void Grow()
    {
        Transform _body = Instantiate(body,parts[parts.Count-1].position,Quaternion.identity,this.transform);
        parts.Add(_body);
    }

    private void ManageInput()
    {
        if(Input.GetKeyDown(KeyCode.W) && moveDirection!=MoveDirection.DOWN)
        {
            moveDirection = MoveDirection.UP;
            direction = Vector3.up;
            head.eulerAngles = Vector3.forward * 90;
        }

        if(Input.GetKeyDown(KeyCode.S) && moveDirection != MoveDirection.UP)
        {
            moveDirection = MoveDirection.DOWN;
            direction = Vector3.down;
            head.eulerAngles = Vector3.forward * 270;
        }

        if (Input.GetKeyDown(KeyCode.A) && moveDirection != MoveDirection.RIGHT)
        {
            moveDirection = MoveDirection.LEFT;
            direction = Vector3.left;
            head.eulerAngles = Vector3.forward * 180;
        }

        if (Input.GetKeyDown(KeyCode.D) && moveDirection != MoveDirection.LEFT)
        {
            moveDirection = MoveDirection.RIGHT;
            direction = Vector3.right;
            head.eulerAngles = Vector3.zero;
        }
    }
}
