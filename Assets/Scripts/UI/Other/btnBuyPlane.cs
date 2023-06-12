using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnBuyPlane : BaseButtonController
{
    [SerializeField]
    protected GameObject pointObj;

    protected override void OnClick()
    {
        var coin = int.Parse(UIManager.Instance.Tabbar.TxtCoin.text.Replace('g', ' '));
        if (coin == 0)
        {
            UIManager.Instance.Popup.PopupCoin1.gameObject.SetActive(true);
        } else
        {
            if(coin >= 200)
            {
                var totalCoin = coin - 200;
                UIManager.Instance.Tabbar.coin = totalCoin;

                ClickMouse.Instance.IsBuy = true;
                ClickMouse.Instance.Obj = pointObj;
            } else
            {
                UIManager.Instance.Popup.PopupCoin1.gameObject.SetActive(true);
            }
        }
    }
}
