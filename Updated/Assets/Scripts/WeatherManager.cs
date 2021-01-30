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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchWeather(int newWeather)
    {
        currentWeather.FadeOut();

        currentWeather = weathers[newWeather];
        
        currentWeather.FadeIn();
    }
}
