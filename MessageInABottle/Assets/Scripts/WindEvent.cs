using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class WindEvent : GameEvent
{
    [SerializeField] private CanvasGroup cg;

    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reset());
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SpawnEvent(BottleEvent eventTrigger)
    {
        if (anim) anim.SetTrigger("Float");
        Debug.Log(eventTrigger.gameObject.name);
        base.SpawnEvent(eventTrigger);
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
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
        if (anim) anim.SetTrigger("Sink");
        trigger.Pass();
        StartCoroutine(Reset(1f));
    }

    public void Fail()
    {
        if (anim) anim.SetTrigger("BlowAway");
        Debug.Log(trigger.gameObject.name);
        trigger.Fail();
        
        StartCoroutine(Reset(2.4f));
    }
}