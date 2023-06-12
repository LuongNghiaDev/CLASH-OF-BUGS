using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupWarning : BaseMonobehavior
{

    [SerializeField]
    private GameObject panelWarning;
    [SerializeField]
    private GameObject panelWarningBoss;

    public GameObject PanelWarning { get => panelWarning; set => panelWarning = value; }
    public GameObject PanelWarningBoss { get => panelWarningBoss; set => panelWarningBoss = value; }

    private void Update()
    {
        StartCoroutine(DelayClose());
        StopCoroutine(DelayClose());
    }

    IEnumerator DelayClose()
    {
        if (this.panelWarning.activeInHierarchy)
        {
            yield return new WaitForSeconds(2f);
            this.panelWarning.SetActive(false);
        }
        else if (this.panelWarningBoss.activeInHierarchy)
        {
            yield return new WaitForSeconds(2f);
            this.panelWarningBoss.SetActive(false);
        }
    }
}
