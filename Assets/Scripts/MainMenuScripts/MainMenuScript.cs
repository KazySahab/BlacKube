using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Options;
    public GameObject LevelsPanel;
    

    void Start()
    {
        MainMenu.SetActive(true);
        Options.SetActive(false);
        LevelsPanel.SetActive(false);
    }
    public void PlayBtnClicked()
    {
        SceneController.instance.LoadScene(PlayerPrefs.GetInt("UnlockedLevel", 1));
    }

    public void OptionBtnClicked()
    {
        Options.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void LevelsBtnClicked()
    {
       LevelsPanel.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void ExitBtnClicked()
    {
        Application.Quit();
    }
    public void BackBtnClicked()
    {
       
        MainMenu.SetActive(true);
        Options.SetActive(false);
        LevelsPanel.SetActive(false);
    }
    
}
