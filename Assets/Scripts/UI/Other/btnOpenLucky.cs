using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnOpenLucky : BaseButtonController
{
    [SerializeField]
    protected GameObject panelPicker;

    protected override void OnClick()
    {
        this.panelPicker.SetActive(true);
    }
}
