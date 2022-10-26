using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private TMP_Text text_value;

    protected int value;
    private int xLimit;
    private int yLimit;

    public void Start()
    {
        xLimit = Boundary.HorizontalBoundary;
        yLimit = Boundary.VerticalBoundary;
        Spawn();
    }

    public void Spawn()
    {
        value = (Random.Range(1, 1000) % 3) + 1;
        text_value.text = value.ToString();

        transform.position = new Vector3(Random.Range(-xLimit, xLimit+1),
                                 Random.Range(-yLimit, yLimit+1),
                                 0);
    }
}
