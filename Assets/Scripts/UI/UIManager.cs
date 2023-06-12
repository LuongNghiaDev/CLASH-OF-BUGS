using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : BaseMonobehavior
{

    protected static UIManager instance;

    [SerializeField]
    protected GameObject openCard;
    [SerializeField]
    protected GameObject openCardAnimal;
    [SerializeField]
    protected GameObject openCardCombat;
    [SerializeField]
    protected BuildingSystem buildingSystem;
    [SerializeField]
    protected Transform holder;
    [SerializeField]
    private Tabbar tabbar;
    [SerializeField]
    private Popup popup;
    [SerializeField]
    private PopupTimer popupTimer;
    [SerializeField]
    private PopupWarning popupWarning;
    [SerializeField]
    private DetailHome detailHome;

    public static UIManager Instance { get => instance; set => instance = value; }
    public GameObject OpenCard { get => openCard; set => openCard = value; }
    public BuildingSystem BuildingSystem { get => buildingSystem; }

    public Transform Holder { get => holder; set => holder = value; }
    public GameObject OpenCardAnimal { get => openCardAnimal; set => openCardAnimal = value; }
    public GameObject OpenCardCombat { get => openCardCombat; set => openCardCombat = value; }
    public Tabbar Tabbar { get => tabbar; set => tabbar = value; }
    public Popup Popup { get => popup; set => popup = value; }
    public PopupTimer PopupTimer { get => popupTimer; set => popupTimer = value; }
    public PopupWarning PopupWarning { get => popupWarning; set => popupWarning = value; }
    public DetailHome DetailHome { get => detailHome; set => detailHome = value; }

    protected override void Awake()
    {
        base.Awake();
        if (instance == null)
            instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBuildingSystem();
        this.LoadTabBar();
        this.LoadPopup();
        this.LoadPopupTimer();
        this.LoadPopupWarning();
    }

    protected virtual void LoadBuildingSystem()
    {
        if (this.buildingSystem != null) return;
        this.buildingSystem = FindObjectOfType<BuildingSystem>();
    }

    protected virtual void LoadTabBar()
    {
        if (this.tabbar != null) return;
        this.tabbar = FindObjectOfType<Tabbar>();
    }

    protected virtual void LoadPopup()
    {
        if (this.popup != null) return;
        this.popup = FindObjectOfType<Popup>();
    }

    protected virtual void LoadPopupTimer()
    {
        if (this.popupTimer != null) return;
        this.popupTimer = FindObjectOfType<PopupTimer>();
    }

    protected virtual void LoadPopupWarning()
    {
        if (this.popupWarning != null) return;
        this.popupWarning = FindObjectOfType<PopupWarning>();
    }

}
