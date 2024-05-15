using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;
using System.Threading.Tasks;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    
    public GameObject PauseMenu;
    public GameObject LevelUpMenu;
    
    Rigidbody2D rbPlayer; 
    public bool ispaused = false;
   
   
    private AudioManager audioManager;
    PausepanelTransistion pausePanelTransition;
    ButtonsTransition buttonsTransition;
    private void Awake()
    {
        rbPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        pausePanelTransition = FindObjectOfType<PausepanelTransistion>();
        buttonsTransition = FindObjectOfType<ButtonsTransition>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        LevelUpMenu.SetActive(false);

    }
    public void PausedBtnClicked()
    {
        Time.timeScale = 0;
        audioManager.Pause();
        
        buttonsTransition.DisableButtons();
        pausePanelTransition.PausePanelIntro();
        PauseMenu.SetActive(true);
        ispaused = true;
    }
    public async void ResumeBtnClicked()
    {
        Time.timeScale = 1;
        audioManager.Resume();
        
        buttonsTransition.Enablebuttons();
       await pausePanelTransition.PausePanelOutro();
        PauseMenu.SetActive(false);
        ispaused = false; 
    }

    public void RestartBtnClicked()
    {
        Time.timeScale = 1;
        rbPlayer.simulated = false;
        audioManager.Resume();
        SceneController.instance.Restart();
        
    }
    public void MainMenuBtnClicked()
    {
        Time.timeScale = 1;
        audioManager.Resume();
        
        SceneController.instance.LoadScene(0);
    }
   
}
