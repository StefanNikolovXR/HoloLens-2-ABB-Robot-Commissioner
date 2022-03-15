using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalScaleronHover : MonoBehaviour
{
    public float timer;
    public float growTime;
    public float shrinkTime;
    public float maxSize;
    public float minSize;

    private IEnumerator Grow ()
    {
        Vector3 startScale = transform.localScale;
        Vector3 maxScale = new Vector3(maxSize, maxSize, maxSize);

        do
        {
            transform.localScale = Vector3.Lerp(startScale, maxScale, timer / growTime);
            timer += Time.deltaTime;
            yield return null;
        }
        while (timer < growTime);
    }

    private IEnumerator Shrink()
    {
        Vector3 endScale = transform.localScale;
        Vector3 minScale = new Vector3(minSize, minSize, minSize);

        do
        {
            transform.localScale = Vector3.Lerp(endScale, minScale, timer / growTime);
            timer += Time.deltaTime;
            yield return null;
        }
        while (timer < shrinkTime);
    }

    public void UpscaleonHover () 

    {
        if (transform.localScale.y <= maxSize)
        {
            timer = 0.1f;
            StartCoroutine(Grow());
        }
    }

    public void DownscaleonHover()
    {
        if (transform.localScale.y >= minSize)
        {
            timer = 0.1f;
            StartCoroutine(Shrink());
        }
    }

}
