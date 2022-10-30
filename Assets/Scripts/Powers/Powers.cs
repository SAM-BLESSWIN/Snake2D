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
        Invoke(nameof(TurnOff), ttl);
    }

    private void TurnOff()
    {
        spawner.StartSpawnTimer();
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Snake>(out Snake snake))
        {
            CancelInvoke(nameof(TurnOff));
            snake.ActivatePower(power);
            spawner.StartSpawnTimer();
            this.gameObject.SetActive(false);
        }
    }
}
