using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class SeagullEvent : GameEvent
{
    [SerializeField] private CanvasGroup cg;
    
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SpawnEvent(BottleEvent eventTrigger)
    {
        base.SpawnEvent(eventTrigger);
        Setup();
    }

    private void Setup()
    {
        cg.alpha = Mathf.Lerp(0, 1, 1f);
        cg.blocksRaycasts = true;
        cg.interactable = true;
    }

    private void Reset()
    {
        cg.alpha = Mathf.Lerp(1, 0, 1f);
        cg.blocksRaycasts = false;
        cg.interactable = false;
        transform.position = new Vector3(0, -10, 0);
    }

    public void Pass()
    {
        trigger.Pass();

        Reset();
    }

    public void Fail()
    {
        trigger.Fail();
        
        Reset();
    }
}
