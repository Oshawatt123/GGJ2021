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
    public Color waterColor;


    [SerializeField] private MeshRenderer waterMesh;

    public GameObject particles;

    public Color lightColor;

    [SerializeField] private Light directionalLight;

    private AudioSource ambient;

    // Awake is called before start
    void Awake()
    {
        ambient = GetComponent<AudioSource>();
        Debug.Log("Got ambient in " + ambient.gameObject.name);
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
        Color oldColor = waterMat.GetColor("_DeepColor");
        
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            currentExposure = Mathf.Lerp(startAlpha, endAlpha, Mathf.Clamp01(elapsedTime / time));

            waterMat.SetFloat("_Glossiness", Mathf.Lerp(oldGloss, glossiness, Mathf.Clamp01(elapsedTime / time)));
            waterMat.SetFloat("_WaveScale", Mathf.Lerp(oldScale, waveScale, Mathf.Clamp01(elapsedTime / time)));
            waterMat.SetFloat("_WaveSpeed", Mathf.Lerp(oldSpeed, waveSpeed, Mathf.Clamp01(elapsedTime / time)));
            waterMat.SetFloat("_WaveFrequency", Mathf.Lerp(oldFreq, frequency, Mathf.Clamp01(elapsedTime / time)));
            
            waterMat.SetColor("_DeepColor", 
                new Color(Mathf.Lerp(oldColor.r, waterColor.r, Mathf.Clamp01(elapsedTime / time)),
                                Mathf.Lerp(oldColor.g, waterColor.g, Mathf.Clamp01(elapsedTime / time)),
                                Mathf.Lerp(oldColor.b, waterColor.b, Mathf.Clamp01(elapsedTime / time))));

            if (fadeIn)
                ambient.volume = Mathf.Lerp(0, 1, Mathf.Clamp01(elapsedTime / time));
            else
                ambient.volume = Mathf.Lerp(1, 0, Mathf.Clamp01(elapsedTime / time));

            if (fadeIn && currentExposure > 0.5f) UpdateEnvSettings();
            if (!fadeIn && currentExposure < 0.5f) break;
            
            skybox.SetFloat("_Exposure", currentExposure);
            yield return new WaitForEndOfFrame();
        }

        if (fadeIn)
            if(particles) particles.SetActive(true);
        else
            if(particles) particles.SetActive(false);
    }

    private void UpdateEnvSettings()
    {
        RenderSettings.skybox = skybox;
        directionalLight.color = lightColor;
    }
}