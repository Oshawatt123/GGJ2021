using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class SeagullEvent : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnSeagulls()
    {
        transform.position = spawnPoint.position;
    }
}
