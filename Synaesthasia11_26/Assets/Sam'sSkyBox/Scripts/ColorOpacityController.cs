using System;
using UnityEngine;
public class ColorOpacityController : MonoBehaviour
{
    [Header("Assign slider fill renderer (from SpatialUISlider)")]
    public MeshRenderer sliderFillRendereruno;

    [Header("Assign slider fill renderer (from SpatialUISlider)")]
    public MeshRenderer sliderFillRendererdos;
    [Header("Assign your sky sphere mesh renderer")]
    public MeshRenderer skySphereRenderer;
    void Update()
    {
        if (sliderFillRendereruno == null || skySphereRenderer == null || sliderFillRendererdos == null)
            return;
        // 1. Read slider "percentage"
        float percentage = sliderFillRendereruno.material.GetFloat("_Percentage");
        percentage = Mathf.Clamp01(percentage);
        // 2. Reverse it
        float reversed = 1f - percentage;
        // 3. Apply reversed value to sky alpha
        Material skyMat = skySphereRenderer.material;
        Color c = skyMat.color;
        c.a = reversed;
        skyMat.color = c;
    }
}
