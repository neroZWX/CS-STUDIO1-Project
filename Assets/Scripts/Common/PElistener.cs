/****************************************************
    File    ：PElistener.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/4/4 20:19:41
	function: Nothing
*****************************************************/

using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class PElistener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Action<PointerEventData>OnClickDown;
    public Action<PointerEventData> OnClickUp;
    public Action<PointerEventData> OnDrag;
    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnClickUp != null)
        {
            OnClickUp(eventData);
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (OnDrag != null)
        {
            OnDrag(eventData);
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (OnClickDown != null) {
            OnClickDown(eventData);
        }
    }
}