using System.Collections;
using System.Collections.Generic;
using DigitalRuby.LightningBolt;
using UnityEngine;

[RequireComponent(typeof(LightningBoltScript))]
[RequireComponent(typeof(AudioSource))]
public class LightningControl : MonoBehaviour
{
    private LightningBoltScript lightning;
    private AudioSource audio;

    [SerializeField] public List<AudioClip> lightningNoise;
    [SerializeField] private float chanceToSpawn = 0.1f;

    private float timer;

    private float strikeTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        lightning = GetComponent<LightningBoltScript>();
        audio = GetComponent<AudioSource>();
        lightning.ManualMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            float rando = Random.Range(0f, 1f);
            if (rando < chanceToSpawn)
            {
                Debug.Log(rando);
                StartCoroutine(EpicLightning());
            }

            timer = strikeTime + Random.Range(0f, 1.5f);
        }

        timer -= Time.deltaTime;
    }

    private IEnumerator EpicLightning()
    {
        lightning.ManualMode = false;
        
        audio.volume = Random.Range(0.5f, 0.7f);
        audio.PlayOneShot(lightningNoise[Random.Range(0, lightningNoise.Count)]);
        
        yield return new WaitForSeconds(0.3f);
        lightning.ManualMode = true;
    }
}
