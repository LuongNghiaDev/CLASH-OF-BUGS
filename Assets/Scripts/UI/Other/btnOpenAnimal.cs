using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnOpenAnimal : BaseButtonController
{
    protected override void OnClick()
    {
        if (UIManager.Instance.OpenCardAnimal.gameObject.activeInHierarchy)
        {
            UIManager.Instance.OpenCardAnimal.gameObject.SetActive(false);
        }
        else if (!UIManager.Instance.OpenCardAnimal.gameObject.activeInHierarchy)
        {
            UIManager.Instance.OpenCardAnimal.gameObject.SetActive(true);
        }
    }
}
