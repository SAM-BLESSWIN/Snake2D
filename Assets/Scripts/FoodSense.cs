using UnityEngine;

public class FoodSense : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Food>(out Food food)
            || collision.TryGetComponent<Powers>(out Powers power))
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Food>(out Food food) 
            || collision.TryGetComponent<Powers>(out Powers power))
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
