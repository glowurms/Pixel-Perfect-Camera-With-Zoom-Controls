using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectPixelWithZoom : MonoBehaviour
{
    [SerializeField]
    private float pixelsPerUnit = 32;
    //[SerializeField] // Uncomment if you want to watch scaling in the editor
    private float pixelsPerUnitScale = 1;
    [SerializeField]
    private float zoomScaleMax = 10f;
    [SerializeField]
    private float zoomScaleStart = 1f;
    [SerializeField]
    private bool smoovZoom = true;
    [SerializeField]
    private float smoovZoomDuration = 0.5f; // In seconds

    private int screenHeight;

    private float cameraSize;
    private Camera cameraComponent;

    private float zoomStartTime = 0f;
    private float zoomScaleMin = 1f;
    private float zoomCurrentValue = 1f;
    private float zoomNextValue = 1f;
    private float zoomInterpolation = 1f;

    public float currentZoomScale { get { return pixelsPerUnitScale; } }

    void Start()
    {
        screenHeight = Screen.height;
        cameraComponent = gameObject.GetComponent<Camera>();
        cameraComponent.orthographic = true;
        SetZoomImmediate(zoomScaleStart);
    }

    void Update()
    {
        if (screenHeight != Screen.height)
        {
            screenHeight = Screen.height;
            UpdateCameraScale();
        }

        if (midZoom)
        {
            if (smoovZoom)
            {
                zoomInterpolation = (Time.time - zoomStartTime) / smoovZoomDuration;
            }
            else
            {
                zoomInterpolation = 1f; // express to the end
            }
            pixelsPerUnitScale = Mathf.Lerp(zoomCurrentValue, zoomNextValue, zoomInterpolation);
            UpdateCameraScale();
        }
    }

    private void UpdateCameraScale()
    {
        // The magic formular from teh Unity Docs
        cameraSize = (screenHeight / (pixelsPerUnitScale * pixelsPerUnit)) * 0.5f;
        cameraComponent.orthographicSize = cameraSize;
    }

    private bool midZoom { get { return zoomInterpolation < 1; } }

    private void SetUpSmoovZoom()
    {
        zoomStartTime = Time.time;
        zoomCurrentValue = pixelsPerUnitScale;
        zoomInterpolation = 0f;
    }

    public void SetPixelsPerUnit(int pixelsPerUnitValue)
    {
        pixelsPerUnit = pixelsPerUnitValue;
        UpdateCameraScale();
    }

    // Has to be >= zoomScaleMin
    public void SetZoomScaleMax(int zoomScaleMaxValue)
    {
        zoomScaleMax = Mathf.Max(zoomScaleMaxValue, zoomScaleMin);
    }

    public void SetSmoovZoomDuration(float smoovZoomDurationValue)
    {
        smoovZoomDuration = Mathf.Max(smoovZoomDurationValue, 0.0333f); // 1/30th of a second sounds small enough
    }

    // Clamped to the range [1, zoomScaleMax], Integer values will be pixel-perfect
    public void SetZoom(float scale)
    {
        SetUpSmoovZoom();
        zoomNextValue = Mathf.Max(Mathf.Min(scale, zoomScaleMax), zoomScaleMin);
    }

    // Clamped to the range [1, zoomScaleMax], Integer values will be pixel-perfect
    public void SetZoomImmediate(float scale)
    {
        pixelsPerUnitScale = Mathf.Max(Mathf.Min(scale, zoomScaleMax), zoomScaleMin);
        UpdateCameraScale();
    }

    public void ZoomIn()
    {
        if (!midZoom)
        {
            SetUpSmoovZoom();
            zoomNextValue = Mathf.Min(pixelsPerUnitScale + 1, zoomScaleMax);
        }
    }

    public void ZoomOut()
    {
        SetUpSmoovZoom();
        zoomNextValue = Mathf.Max(pixelsPerUnitScale - 1, zoomScaleMin);
    }
}
