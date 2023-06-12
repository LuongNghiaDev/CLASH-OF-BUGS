using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupCoinWarning : BaseMonobehavior
{

    [SerializeField]
    private Text txt;

    public Text Txt { get => txt; set => txt = value; }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(DelayClose());
            StopCoroutine(DelayClose());
        }
    }

    IEnumerator DelayClose()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
