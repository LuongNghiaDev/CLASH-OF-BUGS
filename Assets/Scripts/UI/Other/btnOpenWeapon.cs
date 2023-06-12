using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnOpenWeapon : BaseMonobehavior
{

    public void OnClick()
    {
        if (UIManager.Instance.OpenCard.gameObject.activeInHierarchy)
        {
            UIManager.Instance.OpenCard.gameObject.SetActive(false);
            UIManager.Instance.Holder.gameObject.SetActive(false);
            BuildingSystem.Instance.Weapon = null;
        }
        else if (!UIManager.Instance.OpenCard.gameObject.activeInHierarchy)
        {
            UIManager.Instance.OpenCard.gameObject.SetActive(true);
            UIManager.Instance.Holder.gameObject.SetActive(true);
        }
    }
}
