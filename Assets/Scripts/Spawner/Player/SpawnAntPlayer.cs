using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAntPlayer : BaseButtonController
{

    [SerializeField]
    protected Transform posSpawn;
    [SerializeField]
    protected GameObject antObj;
    private int countSpawn = 0;


    protected override void OnClick()
    {
        var coin = int.Parse(UIManager.Instance.Tabbar.TxtCoin.text.Replace('g', ' '));
        if (coin == 0)
        {
            UIManager.Instance.Popup.PopupCoin1.gameObject.SetActive(true);
        }
        else
        {
            if(coin >= 50)
            {
                var totalCoin = coin - 50;
                if (this.countSpawn < int.Parse(UIManager.Instance.Tabbar.TxtCountSpawn.text.Replace('x', ' ')))
                {

                    UIManager.Instance.Tabbar.coin = totalCoin;
                    Instantiate(antObj, posSpawn.position, Quaternion.identity);
                    this.countSpawn += 1;
                }
            } else
            {
                UIManager.Instance.Popup.PopupCoin1.gameObject.SetActive(true);
            }
        }
    }
}
