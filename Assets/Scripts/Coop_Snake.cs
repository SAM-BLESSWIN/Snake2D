using UnityEngine;
public enum Player
{
    Player1,
    Player2
}

public class Coop_Snake : Snake
{

    public Player PlayerIndex { get { return player; } }

    public Powerups ActivatedPower { get { return activatedPower; } }

    public override void Update()
    {
        base.Update();

        if (player == Player.Player2)
            ManageInput_2();
    }

    private void ManageInput_2()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && moveDirection != MoveDirection.DOWN)
        {
            MoveUP();
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && moveDirection != MoveDirection.UP)
        {
            MoveDOWN();
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow) && moveDirection != MoveDirection.RIGHT)
        {
            MoveLEFT();
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) && moveDirection != MoveDirection.LEFT)
        {
            MoveRIGHT();
        }
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Body"))
        {
            if (activatedPower == Powerups.SHIELD) return;

            Coop_Snake _snake = collision.transform.parent.Find("Head").GetComponent<Coop_Snake>();
            if (_snake.PlayerIndex == player) //isMine
            {
                gameOverUI.SetMessage(player.ToString() + " bite himself");
                Dead();
                _snake.Dead();
            }
            else
            {
                if (_snake.ActivatedPower == Powerups.SHIELD) return;

                Dead();
                _snake.Dead();
                gameOverUI.SetMessage(player.ToString() + " bite "+ _snake.PlayerIndex.ToString());
            }
        }

        else if(collision.gameObject.CompareTag("Head"))
        {
            Dead();
            gameOverUI.SetMessage("head clash");
        }
    }
}
