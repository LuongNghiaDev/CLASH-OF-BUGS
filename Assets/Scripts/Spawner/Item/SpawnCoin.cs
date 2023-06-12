using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : BaseMonobehavior
{

    [SerializeField]
    protected float timeDelay;
    private float timer;
    [SerializeField]
    protected Transform posSpawn;
    [SerializeField]
    protected float timeDestroy;
    private static int countCoin = 0;

    private void FixedUpdate()
    {
        this.SpawnCoinDelay();
    }

    protected override void Start()
    {
        base.Start();
        if(PlayerPrefs.GetFloat("TimeDelayCoin") != 0f)
        {
            this.timeDelay = PlayerPrefs.GetFloat("TimeDelayCoin");
        }
    }

    protected virtual void SpawnCoinDelay()
    {
        this.timer -= Time.fixedDeltaTime;
        if (this.timer > 0) return;
        this.timer = this.timeDelay;

        GameObject coin = (GameObject)Instantiate(Resources.Load("Icon_Gold"), posSpawn.position, Quaternion.identity);
        GameObject curCoin = coin;
        if(curCoin != null)
        {
            var txtCoin = UIManager.Instance.Tabbar.TxtCoin.text.Replace("g", "");
            countCoin = int.Parse(txtCoin.ToString());
            countCoin += 10;
            UIManager.Instance.Tabbar.coin = countCoin;
            curCoin = null;
        }
        
        Destroy(coin, this.timeDestroy);
    }
}
