using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupRotationLucky : BaseMonobehavior
{
    [SerializeField]
    private Text txt;
    [SerializeField]
    private Image img;

    public Text Txt { get => txt; set => txt = value; }
    public Image Img { get => img; set => img = value; }

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
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
