using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class TransformMover : MonoBehaviour
{
    [SerializeField] private Vector3 positionOffset = Vector3.zero;
    [SerializeField] private float moveDuration = 1;
    [SerializeField] private AnimationCurve moveCurve = AnimationCurve.Constant(0, 1, 1);

    private void Start()
    {
        StartCoroutine(Move_CR(moveDuration));
    }

    private IEnumerator Move_CR(float duration)
    {
        float currTime = 0;
        float perc = 0;

        Vector3 pos = transform.position;
        Vector3 targetPos = pos + positionOffset;

        while (perc < 1)
        {

            currTime += Time.deltaTime;
            perc = currTime / duration;
            float curvePerc = moveCurve.Evaluate(perc);

            transform.position = Vector3.Lerp(pos, targetPos, 1-curvePerc);

            yield return new WaitForEndOfFrame();
        }
    }
}
