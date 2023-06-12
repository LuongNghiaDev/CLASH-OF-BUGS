using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnBuyTank : BaseButtonController
{
    [SerializeField]
    protected GameObject tankObj;

    protected override void OnClick()
    {
        var coin = int.Parse(UIManager.Instance.Tabbar.TxtCoin.text.Replace('g', ' '));
        if (coin == 0)
        {
            UIManager.Instance.Popup.PopupCoin1.gameObject.SetActive(true);
        } else
        {
            if(coin >= 400)
            {
                var totalCoin = coin - 400;
                UIManager.Instance.Tabbar.coin = totalCoin;
                Instantiate(tankObj, new Vector2(-24, 4), Quaternion.identity);
            } else
            {
                UIManager.Instance.Popup.PopupCoin1.gameObject.SetActive(true);
            }
        }
    }
}
