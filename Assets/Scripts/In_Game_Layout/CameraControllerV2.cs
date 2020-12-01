using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerV2 : MonoBehaviour
{
    public Transform target;

    public float ZoomSpeed = 5.0f;
    public float PanSpeed = 25.0f;
    public float PanBuffer = 50.0f;

    private Plane _Plane;
    public Vector2 panLimit;

    // Start is called before the first frame update
    void Start()
    {
        _Plane = new Plane(Vector3.up, Vector3.zero);
        Vector3 mapCenter = target.transform.position;
        transform.LookAt(mapCenter);
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.GameIsPause != true)
        {
            HandleZoom();
            HandlePan();
        }
    }

    private void HandlePan()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 dRight = transform.right.XZ();
        Vector3 dUp = transform.up.XZ();

        var pos = transform.position;

        if (mousePos.x < PanBuffer || Input.GetKey("a"))
        {
            transform.position -= dRight * Time.fixedDeltaTime * PanSpeed;
        }
        else if (mousePos.x> Screen.width - PanBuffer || Input.GetKey("d"))
        {
            transform.position += dRight * Time.fixedDeltaTime * PanSpeed;
        }

        if (mousePos.y < PanBuffer || Input.GetKey("s"))
        {
            transform.position -= dUp * Time.fixedDeltaTime * PanSpeed;
        }
        else if (mousePos.y > Screen.height - PanBuffer || Input.GetKey("w"))
        {
            transform.position += dUp * Time.fixedDeltaTime * PanSpeed;
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -panLimit.x, panLimit.x),
            transform.position.y, Mathf.Clamp(transform.position.z, -panLimit.y, panLimit.y));
    }

    private void HandleZoom()
    {
        float scrollValue = Input.mouseScrollDelta.y;

        if(scrollValue != 0.0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //Rotation
                Vector3 center = GetCenter();
                Vector3 dToCenter = transform.position - center;
                Vector3 angles = new Vector3(0, scrollValue * ZoomSpeed, 0);
                Quaternion newRot = Quaternion.Euler(angles);
                Vector3 newDir = newRot * dToCenter;
                transform.position = center + newDir;
                transform.LookAt(center);
            }
            else
            {
                //Zoom
                float newSize = Camera.main.orthographicSize - scrollValue * ZoomSpeed;
                Camera.main.orthographicSize = Mathf.Clamp(newSize, 10.0f, 70.0f);
            }
        }
    }

    private Vector3 GetCenter()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        float distance = 0.0f;

        if (_Plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        }

        return Vector3.zero;
    }
}
