using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    public float textStayTime;
    private float timer;
    private int index;

    private List<string> narratives = new List<string>();

    [SerializeField] private TextMeshProUGUI screenText;

    private float fadeTime = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            if (!(index > narratives.Count-1))
            {
                StartCoroutine(FadeNewText());
            }

            timer = textStayTime;
        }

        timer -= Time.deltaTime;
    }

    private IEnumerator FadeNewText()
    {
        float elapsedTime = 0;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            screenText.color = new Color(1, 1, 1, Mathf.Lerp(1, 0, (elapsedTime / fadeTime)));
            Debug.Log("Fading out " + (elapsedTime / fadeTime).ToString());
            yield return new WaitForEndOfFrame();
        }
        
        screenText.text = narratives[index];
        
        elapsedTime = 0;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            screenText.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, Mathf.Clamp01(elapsedTime / fadeTime)));
            Debug.Log("Fading in " + Mathf.Clamp01(elapsedTime / fadeTime).ToString());
            yield return new WaitForEndOfFrame();
        }

        index++;
        
    }

    public void StartNarrative(List<string> narrative)
    {
        index = 0;
        narratives = narrative;
    }
}
