using System.Collections;
using System.Collections.Generic;
using Bitgem.VFX.StylisedWater;
using UnityEngine;

public class Weather : MonoBehaviour
{

    public Material skybox;

    [SerializeField] private Material waterMat;
    public float waveScale;
    public float waveSpeed;
    public float glossiness;
    public float frequency;
    
    
    [SerializeField] private MeshRenderer waterMesh;

    public ParticleSystem particles;

    public Color lightColor;

    [SerializeField] private Light directionalLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public float currentExposure { get; private set; }

    public void FadeDown(){
        StartCoroutine(Fade(1.0f,0.2f, 3.0f));
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(0.2f, 1.0f, 3.0f, true));
    }
    
    IEnumerator Fade(float startAlpha, float endAlpha, float time, bool fadeIn = false)
    {
        float elapsedTime = 0.0f;

        float oldGloss = waterMat.GetFloat("_Glossiness");
        float oldScale = waterMat.GetFloat("_WaveScale");
        float oldSpeed = waterMat.GetFloat("_WaveSpeed");
        float oldFreq = waterMat.GetFloat("_WaveFrequency");
        
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            currentExposure = Mathf.Lerp(startAlpha, endAlpha, Mathf.Clamp01(elapsedTime / time));

            waterMat.SetFloat("_Glossiness", Mathf.Lerp(oldGloss, glossiness, Mathf.Clamp01(elapsedTime / time)));
            waterMat.SetFloat("_WaveScale", Mathf.Lerp(oldScale, waveScale, Mathf.Clamp01(elapsedTime / time)));
            waterMat.SetFloat("_WaveSpeed", Mathf.Lerp(oldSpeed, waveSpeed, Mathf.Clamp01(elapsedTime / time)));
            waterMat.SetFloat("_WaveFrequency", Mathf.Lerp(oldFreq, frequency, Mathf.Clamp01(elapsedTime / time)));
            
            if (fadeIn && currentExposure > 0.5f) UpdateEnvSettings();
            if (!fadeIn && currentExposure < 0.5f) break;
            
            skybox.SetFloat("_Exposure", currentExposure);
            yield return new WaitForEndOfFrame();
        }
    }

    private void UpdateEnvSettings()
    {
        RenderSettings.skybox = skybox;
        directionalLight.color = lightColor;
    }
}