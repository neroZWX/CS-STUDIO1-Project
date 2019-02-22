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
    protected override void InitWnd() {
        base.InitWnd();
        //get local date ,account information.
        if (PlayerPrefs.HasKey("Account") && PlayerPrefs.HasKey("password"))
        {
            InputAcc.text = PlayerPrefs.GetString("Account");
            InputPassword.text = PlayerPrefs.GetString("password");
        }
        else {
            InputAcc.text = null;
            InputPassword.text = null;
        }
    }
}