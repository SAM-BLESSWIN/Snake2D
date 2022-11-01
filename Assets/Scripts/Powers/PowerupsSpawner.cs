using System.Collections;
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

        ActivateSpawnTimer();
    }

    public void ActivateSpawnTimer()
    {
        StartCoroutine(StartSpawnTimer());
    }

    IEnumerator StartSpawnTimer()
    {
        int ttl = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(ttl);
        SpawnPower();
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
