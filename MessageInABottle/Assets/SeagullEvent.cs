using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class SeagullEvent : GameEvent
{
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private CanvasGroup cg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SpawnEvent(BottleEvent eventTrigger)
    {
        base.SpawnEvent(eventTrigger);
        cg.alpha = Mathf.Lerp(0, 1, 1f);
        transform.position = spawnPoint.position;
    }

    public void Pass()
    {
        trigger.Pass();
        
        cg.alpha = Mathf.Lerp(1, 0, 1f);
        transform.position = new Vector3(0, -10, 0);
    }

    public void Fail()
    {
        trigger.Fail();
        
        cg.alpha = Mathf.Lerp(1, 0, 1f);
        transform.position = new Vector3(0, -10, 0);
    }
}
