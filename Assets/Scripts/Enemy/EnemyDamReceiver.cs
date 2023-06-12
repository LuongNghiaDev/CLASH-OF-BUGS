using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamReceiver : DamageReceiver
{

    [SerializeField]
    protected EnemyCtrl enemyCtrl;
    [SerializeField]
    protected GameObject bloodObj;
    [SerializeField]
    protected typeBoss type;
    public static bool dieBoss = false;
    public static bool dieBoss2 = false;

    public EnemyCtrl EnemyCtrl { get => enemyCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
    }

    protected override void OnDead()
    {
        if(this.type.ToString() == "boss")
        {
            dieBoss = true;           
        } else if (this.type.ToString() == "boss2")
        {
            dieBoss2 = true;
        }
        this.enemyCtrl.gameObject.SetActive(false);
        Instantiate(bloodObj, transform.position, Quaternion.identity);
        if(this.enemyCtrl.FootprintSpawner != null)
        {
            this.enemyCtrl.FootprintSpawner.gameObject.SetActive(false);
        }
    }

}

public enum typeBoss
{
    bug,
    boss,
    boss2
}
