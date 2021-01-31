using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayNoiseRandom : MonoBehaviour
{
    private float timer;

    [SerializeField] private float timeBetweenNoise;
    [SerializeField] private float variation;
    [Range(0, 1)] [SerializeField] private float chanceToSpawn;

    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            float rando = Random.Range(0f, 1f);
            if (rando < chanceToSpawn)
            {
                audio.Play();
            }

            timer = timeBetweenNoise + Random.Range(-variation, variation);
        }

        timer -= Time.deltaTime;
    }
}
