using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectBullet : BaseMonobehavior
{
    private static PoolObjectBullet instance;

    [SerializeField]
    protected GameObject bullet;
    [SerializeField]
    protected GameObject bullet_eletric;
    [SerializeField]
    protected GameObject bullet_express;
    [SerializeField]
    protected GameObject bullet_green;
    [SerializeField]
    protected GameObject bullet_plane;

    protected List<GameObject> poolObjects = new List<GameObject>();
    protected List<GameObject> poolObjEletric = new List<GameObject>();
    protected List<GameObject> poolObjExpress = new List<GameObject>();
    protected List<GameObject> poolObjGreen = new List<GameObject>();
    protected List<GameObject> poolObjPlane = new List<GameObject>();
    protected int amoutToPool = 30;
    public static PoolObjectBullet Instance { get => instance; }
    [SerializeField]
    protected Transform bulletHolder;

    protected override void Awake()
    {
        base.Awake();
        if (instance == null)
            instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.AddBulletPool(poolObjects, bullet);
        this.AddBulletPool(poolObjEletric, bullet_eletric);
        this.AddBulletPool(poolObjExpress, bullet_express);
        this.AddBulletPool(poolObjGreen, bullet_green);
        this.AddBulletPool(poolObjPlane, bullet_plane);
    }

    protected virtual void AddBulletPool(List<GameObject> listObj, GameObject bulletObj)
    {
        for (int i = 0; i < amoutToPool; i++)
        {
            GameObject obj = Instantiate(bulletObj);
            obj.transform.parent = bulletHolder;
            obj.SetActive(false);
            listObj.Add(obj);
        }
    }

    public virtual GameObject GetPoolObjectBullet()
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }
        return null;
    }

    public virtual GameObject GetPoolObjectExpress()
    {
        for (int i = 0; i < poolObjExpress.Count; i++)
        {
            if (!poolObjExpress[i].activeInHierarchy)
            {
                return poolObjExpress[i];
            }
        }
        return null;
    }

    public virtual GameObject GetPoolObjectEletric()
    {
        for (int i = 0; i < poolObjEletric.Count; i++)
        {
            if (!poolObjEletric[i].activeInHierarchy)
            {
                return poolObjEletric[i];
            }
        }
        return null;
    }

    public virtual GameObject GetPoolObjectPlane()
    {
        for (int i = 0; i < poolObjPlane.Count; i++)
        {
            if (!poolObjPlane[i].activeInHierarchy)
            {
                return poolObjPlane[i];
            }
        }
        return null;
    }

    public virtual GameObject GetPoolObjectGreen()
    {
        for (int i = 0; i < poolObjGreen.Count; i++)
        {
            if (!poolObjGreen[i].activeInHierarchy)
            {
                return poolObjGreen[i];
            }
        }
        return null;
    }
}
