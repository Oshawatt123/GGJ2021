using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class SeagullEvent : GameEvent
{
    [SerializeField] private CanvasGroup cg;

    private Animator anim;

    [SerializeField] private List<Animator> seagulls;
    
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
        if(anim)  anim.SetTrigger("BlowAway");
        
        trigger.Pass();
        StartCoroutine(Reset(1f));
    }

    public void Fail()
    {
        foreach (Animator seagull in seagulls)
        {
            seagull.SetTrigger("Die");
        }
        trigger.Fail();

        StartCoroutine(Reset(1.16f));
    }
}
