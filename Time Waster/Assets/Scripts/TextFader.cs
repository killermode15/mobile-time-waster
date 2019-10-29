using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextFader : MonoBehaviour
{
    [SerializeField] private TextMeshPro text = null;
    [SerializeField] private float fadeDuration = 2;

    private void Start()
    {
        StartCoroutine(Fade_CR(fadeDuration));
    }

    private IEnumerator Fade_CR(float duration)
    {
        float currTime = 0;
        float perc = 0;

        Color currColor = text.color;

        while (perc < 1)
        {

            currTime += Time.deltaTime;
            perc = currTime / duration;

            currColor.a = Mathf.Lerp(1, 0, perc);

            text.color = currColor;

            yield return new WaitForEndOfFrame();
        }
    }
}
