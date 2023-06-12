using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tabbar : BaseMonobehavior
{

    [SerializeField]
    protected Text txtCoin;
    [SerializeField]
    private Text txtCountSpawn;
    [SerializeField]
    private Text txtLevel;
    public int coin = 300;

    public Text TxtCoin { get => txtCoin; set => txtCoin = value; }
    public Text TxtCountSpawn { get => txtCountSpawn; set => txtCountSpawn = value; }
    public Text TxtLevel { get => txtLevel; set => txtLevel = value; }

    protected override void Start()
    {
        base.Start();
        if(PlayerPrefs.GetInt("CountSpawn") != 0)
        {
            txtCountSpawn.text = "x" + (PlayerPrefs.GetInt("CountSpawn")).ToString();
        }
    }

    private void Update()
    {
        this.txtCoin.text = coin + "g";
    }
}
