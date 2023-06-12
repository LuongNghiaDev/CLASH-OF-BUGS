using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildUp : BaseMonobehavior, IPointerClickHandler
{

    /*public void OnMouseDown()
    {
        if (BuildingSystem.Instance.Weapon != null)
        {
            var direction = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
            GameObject weapon = Instantiate(BuildingSystem.Instance.Weapon, direction, Quaternion.identity);
            weapon.transform.parent = BuildingSystem.Instance.HolderWeapon;
        }
    }*/

    public void OnPointerClick(PointerEventData eventData)
    {
        if (BuildingSystem.Instance.Weapon != null)
        {
            var coin = int.Parse(UIManager.Instance.Tabbar.TxtCoin.text.Replace('g', ' '));
            if (coin > 0 && coin >= BuildingSystem.Instance.CoinWeapon)
            {
                var totalCoin = coin - BuildingSystem.Instance.CoinWeapon;
                UIManager.Instance.Tabbar.coin = totalCoin;

                var direction = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
                GameObject weapon = Instantiate(BuildingSystem.Instance.Weapon, direction, Quaternion.identity);
                weapon.transform.parent = BuildingSystem.Instance.HolderWeapon;
            } else
            {
                UIManager.Instance.Popup.PopupCoin1.gameObject.SetActive(true);
            }
        }
    }
}
