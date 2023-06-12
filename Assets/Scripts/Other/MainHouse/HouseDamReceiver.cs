using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseDamReceiver : DamageReceiver
{
    [SerializeField]
    protected Slider health;
    public static bool checkPerfect;

    protected override void Awake()
    {
        base.Awake();
        checkPerfect = true;
    }

    protected override void Start()
    {
        base.Start();
        this.health.maxValue = this.maxHp;
        this.health.value = this.maxHp;
    }

    public override void Deduct(float deduct)
    {
        if(!this.IsDead())
        {
            this.health.gameObject.SetActive(true);
        }
        checkPerfect = false;
        this.health.value = this.hp;
        base.Deduct(deduct);
    }

    protected override void OnDead()
    {
        this.health.gameObject.SetActive(false);
        Time.timeScale = 0f;
        UIManager.Instance.Popup.PopupGameOver.gameObject.SetActive(true);
    }
}
