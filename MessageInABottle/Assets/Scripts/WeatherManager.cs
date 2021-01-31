using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{

    [SerializeField] private List<Weather> weathers;
    private Weather currentWeather;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox.SetFloat("_Exposure", 1.0f);
        
        currentWeather = weathers[0];

        SwitchWeather(0);

        SwitchWeather(2);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SwitchWeather(int newWeather)
    {
        currentWeather.FadeDown();

        currentWeather = weathers[newWeather];
        
        currentWeather.FadeIn();
    }
}
