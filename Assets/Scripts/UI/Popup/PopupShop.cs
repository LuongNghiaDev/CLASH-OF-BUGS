using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupShop : BaseMonobehavior
{
    [SerializeField]
    protected Text txtCoin1;
    [SerializeField]
    protected Text txtCoin2;
    private int countSpawn = 4;
    private int delayCoin = 3;

    public void OnClickbtn1()
    {
        var coin = int.Parse(UIManager.Instance.DetailHome.TxtCoin.text.Replace('g', ' '));
        if (coin < int.Parse(txtCoin1.text.Replace('g', ' ')))
        {
            Debug.Log("Not Coin");
        } else
        {
            Debug.Log("Success");
            var total = coin - int.Parse(txtCoin1.text.Replace('g', ' '));
            UIManager.Instance.DetailHome.TxtCoin.text = total.ToString();
            countSpawn += 1;
            PlayerPrefs.SetInt("CountSpawn", countSpawn);
        }
    }

    public void OnClickbtn2()
    {
        var coin = int.Parse(UIManager.Instance.DetailHome.TxtCoin.text.Replace('g', ' '));
        if (coin < int.Parse(txtCoin2.text.Replace('g', ' ')))
        {
            Debug.Log("Not Coin");
        }
        else
        {
            Debug.Log("Success");
            var total = coin - int.Parse(txtCoin2.text.Replace('g', ' '));
            UIManager.Instance.DetailHome.TxtCoin.text = total.ToString();
            var delay = delayCoin - 0.2f;
            PlayerPrefs.SetFloat("TimeDelayCoin", delay);
        }
    }
}
