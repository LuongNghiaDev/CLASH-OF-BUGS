using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class btnOpenHome : BaseButtonController
{

    protected override void OnClick()
    {
        UIManager.Instance.Popup.PopupPauseHome.gameObject.SetActive(true);
    }
}
