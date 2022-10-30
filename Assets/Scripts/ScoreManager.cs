using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int score;
    public int Score { get { return score; } }

    [SerializeField] private TMP_Text text_score;

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void UpdateScore(int value)
    { 
        score+=value;

        if(score<0)
            score=0;

        text_score.text = score.ToString("00000");
    }
}
