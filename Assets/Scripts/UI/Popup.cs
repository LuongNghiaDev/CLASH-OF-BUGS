using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : BaseMonobehavior
{

    [SerializeField]
    private PopupPause popupPause;
    [SerializeField]
    private PopupFerfect popupPerfect;
    [SerializeField]
    private PopupGameOver popupGameOver;
    [SerializeField]
    private PopupGameWin popupGameWin;
    [SerializeField]
    private PopupChooseGamePl popupChooseGamePl;
    [SerializeField]
    private PopupPauseHome popupPauseHome;
    [SerializeField]
    private PopupNotiUnlock popupNotiUnlock;
    [SerializeField]
    private PopupCoinWarning popupCoin;
    [SerializeField]
    private PopupRotationLucky popupRotation;
    [SerializeField]
    private PopupShop popupShop;

    public PopupPause PopupPause { get => popupPause; set => popupPause = value; }
    public PopupFerfect PopupPerfect { get => popupPerfect; set => popupPerfect = value; }
    public PopupGameOver PopupGameOver { get => popupGameOver; set => popupGameOver = value; }
    public PopupGameWin PopupGameWin { get => popupGameWin; set => popupGameWin = value; }
    public PopupChooseGamePl PopupChooseGamePl { get => popupChooseGamePl; set => popupChooseGamePl = value; }
    public PopupPauseHome PopupPauseHome { get => popupPauseHome; set => popupPauseHome = value; }
    public PopupNotiUnlock PopupNotiUnlock { get => popupNotiUnlock; set => popupNotiUnlock = value; }
    public PopupCoinWarning PopupCoin1 { get => popupCoin; set => popupCoin = value; }
    public PopupRotationLucky PopupRotation { get => popupRotation; set => popupRotation = value; }
    public PopupShop PopupShop { get => popupShop; set => popupShop = value; }
}
