using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using EasyUI.PickerWheelUI;

public class SpinPicker : BaseMonobehavior
{

    [SerializeField]
    protected Button btnSpin;
    [SerializeField]
    protected PickerWheel pickerWheel;
    public GameObject rotateLucky;
    [SerializeField]
    protected Text txtCountCard;

    protected override void Start()
    {
        base.Start();
        btnSpin.onClick.AddListener(() =>
        {
            var totalCount = int.Parse(txtCountCard.text.Replace("x", "")) - 1;
            PlayerPrefs.SetInt("CountCard", totalCount);
            if (PlayerPrefs.GetInt("CountCard") < 0)
            {
                Debug.Log("No Card");
            }
            else
            {
                txtCountCard.text = "x" + totalCount;
                /*btnSpin.interactable = false;

                pickerWheel.OnSpinStart(() =>
                {

                });

                pickerWheel.OnSpinEnd(wheel =>
                {
                    btnSpin.interactable = true;
                    Debug.Log(wheel.Label + " " + wheel.Amount + " " + wheel.Icon);

                });
                pickerWheel.Spin();*/

                btnSpin.interactable = false;

                pickerWheel.OnSpinStart(() => {

                });

                pickerWheel.OnSpinEnd(wheel => {
                    btnSpin.interactable = true;
                    if (wheel.Label == "Eletric")
                    {
                        var totalCount = int.Parse(UIManager.Instance.DetailHome.TxtCountPlay.text.Replace('x', ' ')) + wheel.Amount;
                        PlayerPrefs.SetInt("CountPlay", totalCount);
                    }
                    else
                    {
                        var coin = int.Parse(UIManager.Instance.DetailHome.TxtCoin.text.Replace('g', ' '));
                        var total = coin + wheel.Amount;
                        UIManager.Instance.DetailHome.TxtCoin.text = total.ToString();
                    }
                    UIManager.Instance.Popup.PopupRotation.gameObject.SetActive(true);
                    UIManager.Instance.Popup.PopupRotation.Txt.text = wheel.Amount + "g";
                    UIManager.Instance.Popup.PopupRotation.Img.sprite = wheel.Icon;

                });
                pickerWheel.Spin();
            }
        });
    }
}
