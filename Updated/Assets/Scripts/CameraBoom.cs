using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoom : MonoBehaviour
{
    private Vector3 boom;

    [SerializeField] private Transform follow;
    // Start is called before the first frame update
    void Start()
    {
        boom = transform.position - follow.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = follow.position + boom;
    }
}
