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

    //test
    public Powerups activatedPower;

    private int nitroSpeed = 7;

    private Vector3 direction;
    private Vector3 spawnPosition;
    private float moveTimer;
    private List<Transform> parts;

    private bool dead;

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
        if(dead) return;

        ManageInput();

        if(activatedPower == Powerups.NITRO)
        {
            moveTimer += nitroSpeed * Time.deltaTime;
        }
        else
        {
            moveTimer += speed * Time.deltaTime;
        }

        if (moveTimer >= moveTimerMax)
        {
            for (int i = parts.Count - 1; i > 0; i--) // [n-1 to 1] move body part in reverse order except head
            {
                parts[i].position = parts[i - 1].position;
            }
            spawnPosition = head.position;
            head.position += direction;
            moveTimer -= moveTimerMax;
        }

    }

    public void Grow(int count)
    {   
        for(int i=0;i<count;i++)
        {
            Transform _body = Instantiate(body, spawnPosition, Quaternion.identity, this.transform.parent);
            parts.Add(_body);
        }
        int score = activatedPower == Powerups.SCORE_BOOSTER ? count * 2 : count;
        ScoreManager.Instance.UpdateScore(score);
    }

    public void Shrink(int count)
    {
        for (int i = 0; parts.Count > 1 && i < count ; i++)
        {
            Transform t = parts[parts.Count - 1];
            Destroy(t.gameObject);
            parts.RemoveAt(parts.Count - 1);
        }
        int score = activatedPower == Powerups.SCORE_BOOSTER ? count * 2 : count;
        ScoreManager.Instance.UpdateScore(-score);
    }

    public void ActivatePower(Powerups power)
    {
        activatedPower = power;
        Invoke(nameof(ResetPower), 10);
    }

    private void ResetPower()
    {
        activatedPower = Powerups.NONE;
    }

    private void ManageInput()
    {
        if(Input.GetKeyDown(KeyCode.W) && moveDirection!=MoveDirection.DOWN)
        {
            moveDirection = MoveDirection.UP;
            direction = Vector3.up;
            head.eulerAngles = Vector3.forward * 90;
        }

        else if(Input.GetKeyDown(KeyCode.S) && moveDirection != MoveDirection.UP)
        {
            moveDirection = MoveDirection.DOWN;
            direction = Vector3.down;
            head.eulerAngles = Vector3.forward * 270;
        }

        else if (Input.GetKeyDown(KeyCode.A) && moveDirection != MoveDirection.RIGHT)
        {
            moveDirection = MoveDirection.LEFT;
            direction = Vector3.left;
            head.eulerAngles = Vector3.forward * 180;
        }

        else if (Input.GetKeyDown(KeyCode.D) && moveDirection != MoveDirection.LEFT)
        {
            moveDirection = MoveDirection.RIGHT;
            direction = Vector3.right;
            head.eulerAngles = Vector3.zero;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Body"))
        {
            if (activatedPower == Powerups.SHIELD) return;

            Time.timeScale = 0;
            dead = true;
            Debug.Log("Dead");
        }
    }
}
