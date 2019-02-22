/****************************************************
    File    ：LoadingWid.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/2/13 23:3:43
	function: Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;


public class LoadingWnd : WindowRoot
{
    public Text txtTips;
    public Image imgFG;
    public Image imgPoint;
    public Text txtPrg;
    private float FGWidth;
    protected  override void InitWnd() {
        base.InitWnd();
        FGWidth = imgFG.GetComponent<RectTransform>().sizeDelta.x;
        SetText (txtTips,"TIPS:chicken head soup  can recover your 100% HP");
        SetText (txtPrg, "0%");
        imgFG.fillAmount = 0;
        imgPoint.transform.localPosition = new Vector3(-604F, 0, 0);
    }
    public void setProgress(float prg) {
        SetText (txtPrg, (int)(prg * 100) + "%");
        imgFG.fillAmount = prg;
        float posX=prg*FGWidth-604;
        imgPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, 0);

    }

}