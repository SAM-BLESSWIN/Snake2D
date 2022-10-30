using UnityEngine;

public class Blocks : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Snake>(out Snake snake))
        {
            snake.Dead();
        }
    }
}
