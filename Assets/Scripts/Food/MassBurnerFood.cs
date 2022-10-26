using TMPro;
using UnityEngine;

public class MassBurnerFood : Food
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Snake>(out Snake snake))
        {
            snake.Shrink(value);
            Spawn();
        }
    }
}
