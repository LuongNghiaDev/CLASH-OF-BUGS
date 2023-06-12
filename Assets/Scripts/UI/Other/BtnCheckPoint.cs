using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCheckPoint : BaseButtonController
{
    [SerializeField]
    protected GameObject pointObj;

    protected override void OnClick()
    {
        ClickMouse.Instance.Obj = pointObj;
    }
}
