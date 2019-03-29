/****************************************************
    File    ：CreateWnd.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/3/16 23:7:12
	function: Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class CreateWnd :WindowRoot 
{
    public InputField iptName;
    protected override void InitWnd()
    {
        base.InitWnd();
        //TODO Display a name romdonly
        iptName.text = resSvc.GetRdNameData(true);
    }
    public void ClickRdBtn() {
        audioSvc.PlayUIAudio(Constants.UiClickBtn);
        string rdName = resSvc.GetRdNameData();
        iptName.text = rdName;
    }
}