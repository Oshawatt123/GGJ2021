using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTilt : MonoBehaviour
{
    [SerializeField] private Transform origin;
    [SerializeField] private LayerMask waterLayer;

    [SerializeField] private float followWaterDistance;

    [SerializeField] private MeshFilter meshFilter;

    private bool hittingWater;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(origin.position, -transform.up, out hit, followWaterDistance, waterLayer))
        {
            transform.up = hit.normal;
            hittingWater = true;
            Debug.Log(hit.transform.name);
            
            // get normal from face of mesh
            Debug.DrawRay(hit.transform.position, hit.normal, Color.cyan);
        }
        else hittingWater = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (hittingWater) Gizmos.color = Color.green;
        else Gizmos.color = Color.magenta;
        
        Gizmos.DrawRay(origin.position, -transform.up * followWaterDistance);
    } 
}
