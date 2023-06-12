using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Origin : BaseMonobehavior
{

    [SerializeField]
    protected List<GameObject> listOrigin;
    private static int countTake = 0;
    private int count = 1;
    private int rand = 0;

    protected override void Start()
    {
        base.Start();
        this.GetChildObject();
    }

    protected virtual void GetChildObject()
    {
        Transform parentTransform = gameObject.transform;

        for (int i = 0; i < parentTransform.childCount; i++)
        {
            Transform childTransform = parentTransform.GetChild(i);

            listOrigin.Add(childTransform.gameObject);
        }
    }

    private void FixedUpdate()
    {
        this.RemoveOrigin();
    }

    protected virtual void RemoveOrigin()
    {
        if(countTake == 10)
        {
            this.rand = Random.Range(0, this.listOrigin.Count);
            if(this.listOrigin[rand].activeInHierarchy)
            {
                this.listOrigin[rand].gameObject.SetActive(false);
            } else
            {
                this.rand = Random.Range(0, this.listOrigin.Count);
            }
            countTake = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(this.count > 0)
            {
                countTake++;
                this.count--;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.count = 1;
        }
    }

}
