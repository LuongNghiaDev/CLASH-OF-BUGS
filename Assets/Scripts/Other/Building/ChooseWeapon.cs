using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseWeapon : BaseMonobehavior
{
    [SerializeField]
    protected GameObject objWeapon;
    [SerializeField]
    protected Text txtCoin;

    public void OnClick()
    {
        var coin = int.Parse(UIManager.Instance.Tabbar.TxtCoin.text.Replace('g', ' '));
        if (coin == 0)
        {
            UIManager.Instance.Popup.PopupCoin1.gameObject.SetActive(true);
        }
        else
        {
            var totalcoin = int.Parse(txtCoin.text.Replace('g', ' '));
            BuildingSystem.Instance.CoinWeapon = totalcoin;
            BuildingSystem.Instance.Weapon = objWeapon;
        }
    }
}
