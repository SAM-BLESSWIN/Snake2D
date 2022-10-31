using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button btn_Restart;
    [SerializeField] private Button btn_Quit;
    [SerializeField] private GameObject go_gameoverPanel;
    [SerializeField] private TMP_Text text_message;

    void Start()
    {
        btn_Restart.onClick.AddListener(() =>
        {
            LevelManager.RestartLevel();
        });

        btn_Quit.onClick.AddListener(() =>
        {
            LevelManager.LoadMainMenu();
        });
    }


    public void SwitchOnGameoverPanel()
    {
        ScoreManager.Instance.SetFinalScore();
        go_gameoverPanel.SetActive(true);
    }

    public void SetMessage(string message)
    {
        text_message.text = message;
    }
}
