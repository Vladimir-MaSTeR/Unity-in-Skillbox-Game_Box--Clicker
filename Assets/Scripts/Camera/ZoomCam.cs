using System;
using UnityEngine;

public class ZoomCam : MonoBehaviour
{
    [SerializeField] private float _zoomMin = 1;
    [SerializeField] private float _zoomMax = 8;

    private Vector3 touch;

    private const int LEFT_BUTTON_IN_MOUSE = 0;
    private const String SCROLL_IN_MOUSE = "Mouse ScrollWheel";

    void Update()
    {
        if (Input.GetMouseButtonDown(LEFT_BUTTON_IN_MOUSE))
        {
            touch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroLastPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOneLastPos = touchOne.position - touchOne.deltaPosition;

            float distTouch = (touchZeroLastPos - touchOneLastPos).magnitude;
            float currenDistTouch = (touchZero.position - touchOne.position).magnitude;

            float defference = currenDistTouch - distTouch;
            
            Zoom(defference * 0.01f); // Умножение для плавности.
        }

        if (Input.GetMouseButton(LEFT_BUTTON_IN_MOUSE))
        {
            Vector3 direction = touch - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
            // Camera.main.transform.position += direction * Time.deltaTime;
        }

        Zoom(Input.GetAxis(SCROLL_IN_MOUSE));
    }

    private void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, _zoomMin, _zoomMax);
    }
}