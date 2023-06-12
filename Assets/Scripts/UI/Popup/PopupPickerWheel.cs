using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupPickerWheel : BaseMonobehavior
{

    [SerializeField]
    protected Button btnExit;
    [SerializeField]
    protected GameObject panelPicker;

    private void Update()
    {
        btnExit.onClick.AddListener(() =>
        {
            this.panelPicker.SetActive(false);
        });
    }
}
