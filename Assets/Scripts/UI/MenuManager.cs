using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button btn_start;
    [SerializeField] private GameObject go_mainMenu;
    [SerializeField] private GameObject go_lobby;

    [SerializeField] private Button btn_back;
    [SerializeField] private Button btn_FreeRoam;
    [SerializeField] private Button btn_Boundary;
    [SerializeField] private Button btn_Coop;

    void Start()
    {
        btn_start.onClick.AddListener(() =>
        {
            SwitchToLobbyPanel();
        });

        btn_back.onClick.AddListener(() =>
        {
            SwitchToMainMenu();
        });

        btn_FreeRoam.onClick.AddListener(() =>
        {
            LevelManager.LoadFreeRoam();
        });

        btn_Boundary.onClick.AddListener(() =>
        {
            LevelManager.LoadBoundary();
        });

        btn_Coop.onClick.AddListener(() =>
        {
            LevelManager.LoadCoop();
        });
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void SwitchToMainMenu()
    {
        go_mainMenu.SetActive(true);
        go_lobby.SetActive(false);
    }

    private void SwitchToLobbyPanel()
    {
        go_mainMenu.SetActive(false);
        go_lobby.SetActive(true);
    }


}
