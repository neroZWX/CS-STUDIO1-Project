/****************************************************
    File    ：WindowRoot.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/2/22 0:31:44
	function: Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class WindowRoot : MonoBehaviour 
{
    public ResSvc resSvc = null;
    public void SetWndState(bool isActive = true) {
        if (gameObject.activeSelf != isActive) {
            SetActive(gameObject, isActive);
        }
        if (isActive)
        {
            InitWnd();
        }
        else {
            ClearWnd();
        }
    }
    protected virtual void InitWnd() {
        resSvc = ResSvc.instance;

    }
    protected virtual void ClearWnd() {
        resSvc = null;
    }


    #region Display  tool functions
    protected void SetActive(GameObject GO, bool IsActive = true) {
        GO.SetActive(IsActive);
    }
    protected void SetActive(Transform trans, bool state = true) {
        trans.gameObject.SetActive(state);
    }
    protected void SetActive(RectTransform rectTrans, bool state = true) {
        rectTrans.gameObject.SetActive(state);
    }
    protected void SetActive(Image image, bool state = true) {
        image.gameObject.SetActive(state);
    }
    protected void SetActive(Text text, bool state = true) {
        text.gameObject.SetActive(state);
    }


    protected void SetText(Text txt, string context = "") {
        txt.text = context;
    }
    protected void SetText(Transform trans, int num = 0) {
        SetText(trans.GetComponent<Text>(),num);
    }
    protected void SetText(Transform trans, string context = "") {
        SetText(trans.GetComponent<Text>(),context);
    }
    protected void SetText(Text txt, int num = 0) {
        SetText(txt, num.ToString());
    }
#endregion
}