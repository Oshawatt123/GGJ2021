using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{

    public Skybox skybox;

    public ParticleSystem particles;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FadeIn()
    {
        
    }

    private IEnumerator FadeOutCR()
    {
        yield return new WaitForSeconds(1);
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCR());
    }
}