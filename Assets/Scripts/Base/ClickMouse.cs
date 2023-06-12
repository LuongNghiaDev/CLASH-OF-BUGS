using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickMouse : BaseMonobehavior
{

    private static ClickMouse instance;

    [SerializeField]
    private GameObject obj;
    private bool isFly = false;
    private bool isBuy = false;

    //plane spawn
    [SerializeField]
    protected float minY;
    [SerializeField]
    protected float maxY;
    [SerializeField]
    protected List<GameObject> planeList;
    private int rand = 0;

    //limit plane
    [SerializeField]
    public GameObject limitPlane;

    public static ClickMouse Instance { get => instance; set => instance = value; }
    public GameObject Obj { get => obj; set => obj = value; }
    public bool IsFly { get => isFly; set => isFly = value; }
    public bool IsBuy { get => isBuy; set => isBuy = value; }

    protected override void Awake()
    {
        base.Awake();
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (this.obj != null)
            {
                if (this.isBuy == true)
                {
                    GameObject point = Instantiate(obj, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                        Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                        0f)
                        , Quaternion.identity);

                    rand = Random.Range(0, this.planeList.Count);
                    Instantiate(this.planeList[rand], new Vector2(-23f, Random.Range(minY, maxY))
                    , Quaternion.identity);
                    PlaneMovement.Instance.PointFlag = point;

                    if (point != null)
                    {
                        this.isFly = true;
                        this.isBuy = false;
                        this.obj = null;
                    }
                }
                else
                {
                    Debug.Log("No Buy");
                }
            }
        }
    }

}
