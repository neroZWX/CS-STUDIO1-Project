/****************************************************
    File    ：Login.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/2/13 22:6:35
	function: Nothing
*****************************************************/

using UnityEngine;
using System;

public class LoginSys: MonoBehaviour 
{
    public static LoginSys instance = null;
    public LoginWnd loginWnd;
    public void InitSys() {
        instance = this;
        Debug.Log("Init login System");
    }
    public void EnterLogin() {
       //display loading progress
        ResSvc.instance.AsyncLoadScene(Constants.SceneLogin,OpenLoginWnd);
    }
    public void OpenLoginWnd() {
        //after loading then open login interface
        loginWnd.SetWndState();
        AudioSvc.Instace.PlayBGMusic(Constants.BGlogin);
    }
}