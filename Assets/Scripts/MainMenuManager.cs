using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void CustumizeButton()
    {
        SceneManager.LoadScene("Custumize");
    }

    public void SortieButton()
    {
        SceneManager.LoadScene("Main");
    }
}
