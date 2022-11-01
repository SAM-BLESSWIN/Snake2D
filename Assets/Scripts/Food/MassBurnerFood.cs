using System.Collections;
using TMPro;
using UnityEngine;

public class MassBurnerFood : Food
{
    [SerializeField] private int ttl = 10;
    private void Awake()
    {
        StartCoroutine(SpawnAndStartTimer());
    }

    IEnumerator SpawnAndStartTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(ttl);
            Spawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Snake>(out Snake snake))
        {
            snake.Shrink(value);
            Spawn();
        }
    }
}
