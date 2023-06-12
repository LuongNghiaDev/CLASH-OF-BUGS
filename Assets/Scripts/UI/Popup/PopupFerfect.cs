using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupFerfect : BaseMonobehavior
{

    public void ClickBtnReplay()
    {
        Time.timeScale = 1f;
        UIManager.Instance.Popup.PopupPerfect.gameObject.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ClickBtnExit()
    {
        Time.timeScale = 1f;
        UIManager.Instance.Popup.PopupPerfect.gameObject.SetActive(false);

        SceneManager.LoadScene("HomeScene");
    }
}
