using UnityEngine;

public class PowerupsSpawner : MonoBehaviour
{
    public Transform[] powers;
    public int minTime;
    public int maxTime;
    private int xLimit;
    private int yLimit;

    private void Start()
    {
        foreach (Transform t in powers)
        {
            t.gameObject.SetActive(false);
        }

        xLimit = Boundary.HorizontalBoundary;
        yLimit = Boundary.VerticalBoundary;

        StartSpawnTimer();

    }

    public void StartSpawnTimer()
    {
        Invoke(nameof(SpawnPower), Random.Range(minTime, maxTime));
    }

    private void  SpawnPower()
    {
        int index = Random.Range(0, powers.Length);
        powers[index].position = new Vector3(Random.Range(-xLimit, xLimit + 1),
                                     Random.Range(-yLimit, yLimit + 1),
                                     0);
        powers[index].gameObject.SetActive(true);
    }
}
