using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnOpenShop : BaseButtonController
{

    protected override void OnClick()
    {
        UIManager.Instance.Popup.PopupShop.gameObject.SetActive(true);
    }
}
