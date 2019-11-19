using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void CustumizeButton()
    {
        SceneManager.LoadScene("Custumize");
    }

    public void SortieButton()
    {
        SceneManager.LoadScene("Main");
    }
}
