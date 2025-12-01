using System;
using UnityEngine;

public class SkyGradientSliderController : MonoBehaviour
{
    [Header("Assign TOP color slider fill (from SpatialUISlider)")]
    public MeshRenderer topSliderFillRenderer;

    [Header("Assign BOTTOM color slider fill (from SpatialUISlider)")]
    public MeshRenderer bottomSliderFillRenderer;

    [Header("Assign your sky sphere mesh renderer (with SkyGradientShader material)")]
    public MeshRenderer skySphereRenderer;

    void Update()
    {
        if (topSliderFillRenderer == null ||
            bottomSliderFillRenderer == null ||
            skySphereRenderer == null)
            return;

        // 1. Read slider percentages (0–1) from each slider
        float topPercent    = Mathf.Clamp01(topSliderFillRenderer.material.GetFloat("_Percentage"));
        float bottomPercent = Mathf.Clamp01(bottomSliderFillRenderer.material.GetFloat("_Percentage"));

        // 2. Map slider percentage -> colors
        //    Using HSV so user gets a full rainbow on each slider.
        Color topColor    = Color.HSVToRGB(topPercent, 1f, 1f);
        Color bottomColor = Color.HSVToRGB(bottomPercent, 1f, 1f);

        // 3. Apply to the SkyGradientShader material on the sphere
        //    Make sure your Shader Graph color properties are named:
        //    TopColor  (reference: _TopColor)
        //    BottomColor (reference: _BottomColor)
        Material skyMat = skySphereRenderer.material;
        skyMat.SetColor("_TopColor", topColor);
        skyMat.SetColor("_BottomColor", bottomColor);
    }
}
