using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupPause : BaseMonobehavior
{

    [SerializeField]
    protected Slider sliderMusic;
    [SerializeField]
    protected Slider sliderSound;

    public void ClickBtnResume()
    {
        Time.timeScale = 1f;
        UIManager.Instance.Popup.PopupPause.gameObject.SetActive(false);
    }

    public void ClickBtnReplay()
    {
        Time.timeScale = 1f;
        UIManager.Instance.Popup.PopupPause.gameObject.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ClickBtnExit()
    {
        Time.timeScale = 1f;
        UIManager.Instance.Popup.PopupPause.gameObject.SetActive(false);

        PlayerPrefs.Save();
        SceneManager.LoadScene("HomeScene");
    }
}
