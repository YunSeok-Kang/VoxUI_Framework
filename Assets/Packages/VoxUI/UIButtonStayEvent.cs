using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 
public class UIButtonStayEvent : EventTrigger
{
    private Coroutine _routine = null;

    public override void OnPointerDown(PointerEventData data)
    {
        _routine = StartCoroutine(Routine());
    }

    public IEnumerator Routine()
    {
        while (this.enabled)
        {
            GetComponent<Button>().onClick.Invoke();
            yield return null;
        }
    }

    public override void OnPointerUp(PointerEventData data)
    {
        StopCoroutine(_routine);
    }
}
