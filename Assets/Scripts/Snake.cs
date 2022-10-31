using System.Collections.Generic;
using UnityEngine;

public enum MoveDirection
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
    [SerializeField] protected GameOverUI gameOverUI;

    [Header("Parameters")]
    [SerializeField] private float moveTimerMax =1f;
    [SerializeField] private int defaultSpeed = 5;

    [SerializeField] protected Player player;


    [SerializeField] private Color[] powerColor;

    protected MoveDirection moveDirection;
    protected Powerups activatedPower;

    private int[] powerSpeeds = {3,4,6,7};
    private Vector3 direction;
    private Vector3 spawnPosition;
    private float moveTimer;
    private List<Transform> parts;
    protected bool dead;
    private int speed;

    private void Start()
    {
        moveDirection = MoveDirection.RIGHT;
        direction = Vector3.right;

        head.position = new Vector3(Mathf.RoundToInt(head.position.x),Mathf.RoundToInt(head.position.y));

        parts = new List<Transform>();
        parts.Add(head);

        speed = defaultSpeed;
    }

    public virtual void Update()
    {
        if(dead) return;

        if (player == Player.Player1)
            ManageInput();

        moveTimer += speed * Time.deltaTime;

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
        int score = activatedPower == Powerups.SCORE_BOOSTER ? count * 2 : count;
        ScoreManager.Instance.UpdateScore(-score);
    }

    public void ActivatePower(Powerups power)
    {
        activatedPower = power;
        head.GetComponent<SpriteRenderer>().color = powerColor[(int)power];

        if (activatedPower == Powerups.SPEED)
        {
            speed = powerSpeeds[Random.Range(0, powerSpeeds.Length)];
        }

        Invoke(nameof(ResetPower), 10);
    }

    private void ResetPower()
    {
        if (activatedPower == Powerups.SPEED)
        {
            speed = defaultSpeed;
        }

        activatedPower = Powerups.NONE;
        head.GetComponent<SpriteRenderer>().color = powerColor[0];
    }

    protected void ManageInput()
    {
        if(Input.GetKeyDown(KeyCode.W) && moveDirection!=MoveDirection.DOWN)
        {
            MoveUP();
        }

        else if(Input.GetKeyDown(KeyCode.S) && moveDirection != MoveDirection.UP)
        {
            MoveDOWN();
        }

        else if (Input.GetKeyDown(KeyCode.A) && moveDirection != MoveDirection.RIGHT)
        {
            MoveLEFT();
        }

        else if (Input.GetKeyDown(KeyCode.D) && moveDirection != MoveDirection.LEFT)
        {
            MoveRIGHT();
        }
    }

    protected void MoveUP()
    {
        moveDirection = MoveDirection.UP;
        direction = Vector3.up;
        head.eulerAngles = Vector3.forward * 90;
    }

    protected void MoveDOWN()
    {
        moveDirection = MoveDirection.DOWN;
        direction = Vector3.down;
        head.eulerAngles = Vector3.forward * 270;
    }

    protected void MoveLEFT()
    {
        moveDirection = MoveDirection.LEFT;
        direction = Vector3.left;
        head.eulerAngles = Vector3.forward * 180;
    }

    protected void MoveRIGHT()
    {
        moveDirection = MoveDirection.RIGHT;
        direction = Vector3.right;
        head.eulerAngles = Vector3.zero;
    }

    public void Dead()
    {
        dead = true;
        Invoke("EnableEndScreen", 1);
    }

    private void EnableEndScreen()
    {
        gameOverUI.SwitchOnGameoverPanel();
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Body"))
        {
            if (activatedPower == Powerups.SHIELD) return;
            Dead();
        }
    }
}
