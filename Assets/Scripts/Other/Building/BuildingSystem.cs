using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class BuildingSystem : BaseMonobehavior
{
    protected static BuildingSystem instance;

    [SerializeField]
    protected int rows = 4;
    [SerializeField]
    protected int cols = 14;
    [SerializeField]
    protected float tileSize = 3;
    [SerializeField]
    protected Transform holder;
    [SerializeField]
    protected GameObject weapon;
    [SerializeField]
    protected Transform holderWeapon;
    [SerializeField]
    protected List<GameObject> listUnlock;
    private int coinWeapon;

    public static BuildingSystem Instance { get => instance;}
    public GameObject Weapon { get => weapon; set => weapon = value; }
    public Transform HolderWeapon { get => holderWeapon; }
    public int CoinWeapon { get => coinWeapon; set => coinWeapon = value; }

    protected override void Awake()
    {
        base.Awake();
        if (instance == null)
            instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.GenerateGrid();
        this.holder.gameObject.SetActive(false);
    }

    public virtual void GenerateGrid()
    {
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("Unlock"));
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);
                listUnlock.Add(tile);

                float posX = col * tileSize;
                float posY = row * -tileSize;
                tile.name = "Unlock" + col + "_" + row;
                tile.transform.position = new Vector2(posX, posY);
            }
        }
        Destroy(referenceTile);
        Destroy(this.holder.Find("Unlock0_5").gameObject);
        Destroy(this.holder.Find("Unlock1_5").gameObject);
        Destroy(this.holder.Find("Unlock6_1").gameObject);
        Destroy(this.holder.Find("Unlock5_1").gameObject);
        Destroy(this.holder.Find("Unlock5_2").gameObject);
        Destroy(this.holder.Find("Unlock6_2").gameObject);

        float gridW = cols * tileSize;
        float gridH = rows * tileSize;

        transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);
        
    }

}
