/****************************************************
    File    ：MainCityWnd.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/4/3 21:12:39
	function: Nothing
*****************************************************/

using UnityEngine;
using System;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using UnityEngine.EventSystems;

public class MainCityWnd : WindowRoot
{
    public Image ImageControllerTough;
    public Image Controller1;
    public Image Controller2;
    private Vector2 StartPos = Vector2.zero;
    private Vector2 DefaultPos = Vector2.zero;
    protected override void InitWnd()
    {
        base.InitWnd();
        DefaultPos = Controller1.transform.position;
        RegisterTouchEvts();

    }
    public void RegisterTouchEvts()
    {
        OnClickDown(ImageControllerTough.gameObject, (PointerEventData evt) =>
         {
             StartPos = evt.position;
             SetActive(Controller1);
             Controller1.transform.position = evt.position;
         });

        OnClickUp(ImageControllerTough.gameObject, (PointerEventData evt) =>
        {
            Controller1.transform.position = DefaultPos;
            SetActive(Controller1, false);
            Controller2.transform.localPosition = Vector2.zero;
        });
        OnDrag(ImageControllerTough.gameObject, (PointerEventData evt) => {
            Vector2 Con2 = evt.position - StartPos;
            float len = Con2.magnitude;
            if (len > 240)
            {
                Vector2 clampCon2 = Vector2.ClampMagnitude(Con2, 240);
                Controller2.transform.position = StartPos + clampCon2;
            }
            else {
                Controller2.transform.position = evt.position;
            }
        });

}
}