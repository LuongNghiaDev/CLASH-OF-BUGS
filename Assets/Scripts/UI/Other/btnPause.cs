using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnPause : BaseButtonController
{

    protected override void OnClick()
    {
        Time.timeScale = 0f;
        UIManager.Instance.Popup.PopupPause.gameObject.SetActive(true);
    }
}
