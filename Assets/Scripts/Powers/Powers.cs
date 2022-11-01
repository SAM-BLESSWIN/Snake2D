using System.Collections;
using UnityEngine;

public enum Powerups
{
    NONE,
    SPEED,
    SCORE_BOOSTER,
    SHIELD
}

public class Powers : MonoBehaviour
{
    [SerializeField] private Powerups power;
    [SerializeField] private PowerupsSpawner spawner;
    [SerializeField] private int ttl = 10;

    private void OnEnable()
    {
        StartCoroutine(nameof(TurnOff));
    }

    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(ttl);
        spawner.ActivateSpawnTimer();
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Snake>(out Snake snake))
        {
            snake.ActivatePower(power);
            spawner.ActivateSpawnTimer();
            this.gameObject.SetActive(false);
        }
    }
}
