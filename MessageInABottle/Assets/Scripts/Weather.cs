using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{

    public Material skybox;

    public ParticleSystem particles;

    public Color lightColor;
    
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
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            currentExposure = Mathf.Lerp(startAlpha, endAlpha, Mathf.Clamp01(elapsedTime / time));

            if (fadeIn && currentExposure > 0.5f) UpdateEnvSettings();
            if (!fadeIn && currentExposure < 0.5f) break;
            
            skybox.SetFloat("_Exposure", currentExposure);
            yield return new WaitForEndOfFrame();
        }
    }

    private void UpdateEnvSettings()
    {
        RenderSettings.skybox = skybox;
    }
}