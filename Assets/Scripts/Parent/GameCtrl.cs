using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : BaseMonobehavior
{

    private static GameCtrl instance;

    [SerializeField]
    protected Origin origin;
    [SerializeField]
    protected EnemyMovement enemyMovement;
    [SerializeField]
    protected PlayerMovement playerMovement;
    [SerializeField]
    protected HouseParent houseParent;
    [SerializeField]
    protected PlayerCtrl playerCtrl;
    [SerializeField]
    private BulletParentFly bulletParent;
    [SerializeField]
    private Transform posLimit;
    [SerializeField]
    private MainHouse manHouse;
    [SerializeField]
    private Transform holderFootPrint;
    [SerializeField]
    public Transform limitAnt;
    [SerializeField]
    public Transform limitBug;

    public Origin Origin { get => origin;  }
    public EnemyMovement EnemyMovement { get => enemyMovement;  }
    public PlayerMovement PlayerMovement { get => playerMovement; }
    public HouseParent HouseParent { get => houseParent; }
    public PlayerCtrl PlayerCtrl { get => playerCtrl;}
    public Transform PosLimit { get => posLimit; set => posLimit = value; }
    public static GameCtrl Instance { get => instance; set => instance = value; }
    public MainHouse ManHouse { get => manHouse; set => manHouse = value; }
    public Transform HolderFootPrint { get => holderFootPrint; set => holderFootPrint = value; }

    protected override void Awake()
    {
        base.Awake();
        if (instance == null)
            instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadOrigin();
        this.LoadEnemyMovement();
        this.LoadPlayerMovement();
        this.LoadHouseParent();
        this.LoadPlayerCtrl();
        this.LoadMainHouse();
    }

    protected virtual void LoadMainHouse()
    {
        if (this.manHouse != null) return;
        this.manHouse = FindObjectOfType<MainHouse>();
    }

    protected virtual void LoadOrigin()
    {
        if (this.origin != null) return;
        this.origin = FindObjectOfType<Origin>();
    }

    protected virtual void LoadEnemyMovement()
    {
        if (this.enemyMovement != null) return;
        this.enemyMovement = FindObjectOfType<EnemyMovement>();
    }

    protected virtual void LoadPlayerMovement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = FindObjectOfType<PlayerMovement>();
    }

    protected virtual void LoadHouseParent()
    {
        if (this.houseParent != null) return;
        this.houseParent = FindObjectOfType<HouseParent>();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = FindObjectOfType<PlayerCtrl>();
    }
}
