using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : BaseMonobehavior
{

    protected Vector3 touchStart;
    protected float zoomOutMin = 1;
    protected float zoomOutMax = 8;

    private Vector3 dragOrigin;
    [SerializeField]
    private SpriteRenderer mapRenderer;

    [SerializeField]
    private Camera cam;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    protected override void Awake()
    {
        base.Awake();
        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;
        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;

    }

    private void Update()
    {
        PanCamera();

        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    protected virtual void Zoom(float increment)
    {
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

    protected virtual void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.touchCount == 2)
        {
            Touch tochZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrePos = tochZero.position - tochZero.deltaPosition;
            Vector2 touchOnePrePos = touchOne.position - touchOne.deltaPosition;

            float preMagnitude = (touchZeroPrePos - touchOnePrePos).magnitude;
            float curMagitude = (tochZero.position - touchOne.position).magnitude;

            float diff = curMagitude - preMagnitude;
            Zoom(diff * 0.01f);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position = ClampCamera(cam.transform.position + direction);
        }

    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);
        return new Vector3(newX, newY,-10);
    }


}
