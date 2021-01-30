using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacionEvent : GameEvent
{
    [SerializeField] private float timeToKill;

    private bool startTimer;

    private float timer;

    private List<Tentacle> tentacles;
    private int completed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                trigger.Fail();
                startTimer = false;
            }
        }
    }

    public override void SpawnEvent(BottleEvent eventTrigger)
    {
        startTimer = true;
        timer = timeToKill;
        base.SpawnEvent(eventTrigger);
    }

    public void Subscribe(Tentacle tentacle)
    {
        tentacles.Add(tentacle);
    }

    public void CompleteTent()
    {
        completed += 1;

        if (completed >= tentacles.Count)
        {
            trigger.Pass();
            startTimer = false;
        }
    }
}
