/****************************************************
    File    ：LoginWnd.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/2/21 1:41:22
	function: Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class LoginWnd : WindowRoot 
{
    public InputField InputAcc;
    public InputField InputPassword;
    public Button BtnEnter;
    public Button BtnShop;
    public Button Bbtncoins;
    protected override void InitWnd() {
        base.InitWnd();
        //get local date ,account information.
        if (PlayerPrefs.HasKey("Account") && PlayerPrefs.HasKey("Password"))
        {
            InputAcc.text = PlayerPrefs.GetString("Account");
            InputPassword.text = PlayerPrefs.GetString("password");
        }
        else {
            InputAcc.text = null;
            InputPassword.text = null;
        }
    }
    
    public void ClickEnter() {
        audioSvc.PlayUIAudio(Constants.UiLoginBtn);
        string account = InputAcc.text;
        string password = InputPassword.text;
        if (account != "" && password != "") {
            //UPDATE LOCAL ACCOUNT AND PASSWORD
            PlayerPrefs.SetString("Account", account);
            PlayerPrefs.SetString("Password", password);
            LoginSys.instance.RsLogin();
        }
        else if (account == ""||password==""){
            GameRoot.AddTips("Please enter Account and Password!");
        }
    }
    public void ClickNoticeBtn() {
        audioSvc.PlayUIAudio(Constants.UiClickBtn);
        GameRoot.AddTips("this fuction is developing...");
    }
}