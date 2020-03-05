using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSizer : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Gradient MyGradient;

    Vector3 originalScale;
    Vector3 targetScale;
    float duration;
    float colorDuration;

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(Grow());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine((Color()));
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine((Decolor()));
    }

    private IEnumerator Grow()
    {
        for(float t = 0; t < duration; t+=Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, t/duration);
            yield return null; //esto ayuda a no hacerlo todo en el mismo frame;
        }

        yield return new WaitForSeconds(1);
        transform.localScale /= 1.5f;
    }

    private IEnumerator Color()
    {
        for (float t = 0; t < colorDuration; t += Time.deltaTime)
        {
            var color = MyGradient.Evaluate(t/colorDuration);
            GetComponent<Image>().color = color;
            yield return null; //esto ayuda a no hacerlo todo en el mismo frame;
        }
    }
    private IEnumerator Decolor()
    {
        for (float t = 0; t < colorDuration; t += Time.deltaTime)
        {
            var color =  MyGradient.Evaluate((1-t)/colorDuration);
            GetComponent<Image>().color = color;
            yield return null; //esto ayuda a no hacerlo todo en el mismo frame;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale * 1.5f;
        duration = 1;
        colorDuration = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
