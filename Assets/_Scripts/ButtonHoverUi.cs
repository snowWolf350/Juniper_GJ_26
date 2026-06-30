using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonHoverUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    float _scaleTime = 0.15f;
    Vector3 _startScale;

    private void Start()
    {
        _startScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleButton(transform.localScale,(_startScale + new Vector3(0.1f,0.1f,0.1f))));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleButton(transform.localScale, _startScale));
    }

    IEnumerator ScaleButton(Vector3 _start, Vector3 _end)
    {
        float t = 0;
        float e = 0;
        RectTransform rectTransform = GetComponent<RectTransform>();
        while (e < _scaleTime)
        {
            t = e / _scaleTime;
            rectTransform.localScale = Vector3.Lerp(_start, _end, t);
            e += Time.unscaledDeltaTime;
            yield return null;
        }
        rectTransform.localScale = _end;
    }
}
