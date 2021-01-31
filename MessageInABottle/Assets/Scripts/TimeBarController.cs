using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarController : MonoBehaviour
{
    [SerializeField] private Slider sliderA;
    [SerializeField] private Slider sliderB;

    [SerializeField] private CanvasGroup cg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTimer(float show)
    {
        cg.alpha = show;
    }

    public void SetTimerValue(float value)
    {
        sliderA.value = value;
        sliderB.value = value;
    }
}
