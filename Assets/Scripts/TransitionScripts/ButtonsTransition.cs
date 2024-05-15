using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsTransition : MonoBehaviour
{
    public Button moveLeft, moveRight, Jump, Pause;

    public void DisableButtons()
    {
        moveLeft.gameObject.SetActive(false);
        moveRight.gameObject.SetActive(false);
        Jump.gameObject.SetActive(false);
        Pause.gameObject.SetActive(false);
    }
   public  void Enablebuttons()
    {
        moveLeft.gameObject.SetActive(true);
        moveRight.gameObject.SetActive(true);
        Jump.gameObject.SetActive(true);
        Pause.gameObject.SetActive(true);
    }
}
