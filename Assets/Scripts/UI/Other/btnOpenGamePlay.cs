using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnOpenGamePlay : BaseButtonController
{

    protected override void OnClick()
    {
        UIManager.Instance.Popup.PopupChooseGamePl.gameObject.SetActive(true);
    }
}
