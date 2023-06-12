using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupGameWin : BaseMonobehavior
{
    [SerializeField]
    protected List<Image> listStar;

    public void ClickBtnReplay()
    {
        Time.timeScale = 1f;
        UIManager.Instance.Popup.PopupGameWin.gameObject.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ClickBtnExit()
    {
        Time.timeScale = 1f;
        UIManager.Instance.Popup.PopupGameWin.gameObject.SetActive(false);

        SceneManager.LoadScene("HomeScene");
    }

}
