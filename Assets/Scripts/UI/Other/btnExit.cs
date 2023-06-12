using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnExit : BaseButtonController
{

    protected override void OnClick()
    {
        PlayerPrefs.Save();
        if (UIManager.Instance.Popup.PopupPauseHome.gameObject.activeInHierarchy)
        {
            UIManager.Instance.Popup.PopupPauseHome.gameObject.SetActive(false);
        } else if (UIManager.Instance.Popup.PopupChooseGamePl.gameObject.activeInHierarchy)
        {
            UIManager.Instance.Popup.PopupChooseGamePl.gameObject.SetActive(false);
        }
        else if (UIManager.Instance.Popup.PopupRotation.gameObject.activeInHierarchy)
        {
            UIManager.Instance.Popup.PopupRotation.gameObject.SetActive(false);
        }
        else if (UIManager.Instance.Popup.PopupShop.gameObject.activeInHierarchy)
        {
            UIManager.Instance.Popup.PopupShop.gameObject.SetActive(false);
        }
    }
}
