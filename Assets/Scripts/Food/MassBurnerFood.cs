using TMPro;
using UnityEngine;

public class MassBurnerFood : Food
{
    [SerializeField] private int ttl = 10;
    private void Awake()
    {
        SpawnAndStartTimer();
    }

    private void SpawnAndStartTimer()
    {
        InvokeRepeating(nameof(Spawn),0, ttl);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Snake>(out Snake snake))
        {
            snake.Shrink(value);
            CancelInvoke();
            SpawnAndStartTimer();
        }
    }
}
