using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class StormEvent : GameEvent
{
    [SerializeField] private CanvasGroup cg;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reset());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SpawnEvent(BottleEvent eventTrigger)
    {
        Debug.Log(eventTrigger.gameObject.name);
        base.SpawnEvent(eventTrigger);
        Setup();
    }

    private void Setup()
    {
        cg.alpha = Mathf.Lerp(0, 1, 1f);
        cg.blocksRaycasts = true;
        cg.interactable = true;
    }

    private IEnumerator Reset(float wait = 0f)
    {
        yield return new WaitForSeconds(wait);
        cg.alpha = Mathf.Lerp(1, 0, 1f);
        cg.blocksRaycasts = false;
        cg.interactable = false;
        transform.position = new Vector3(0, -10, 0);
    }

    public void Pass()
    {
        trigger.Pass();
        StartCoroutine(Reset());
    }

    public void Fail()
    {
        Debug.Log(trigger.gameObject.name);
        trigger.Fail();
        
        StartCoroutine(Reset());
    }
}