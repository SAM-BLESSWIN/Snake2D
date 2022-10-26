using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassGainerFood : Food
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Snake>(out Snake snake))
        {
            snake.Grow(value);
            Spawn();
        }
    }

}
