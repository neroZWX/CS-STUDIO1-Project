/****************************************************
    File    ：Login.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/2/13 22:6:35
	function: Nothing
*****************************************************/

using UnityEngine;
using System;

public class LoginSys:SystemRoot 
{
    public static LoginSys instance = null;
    public LoginWnd loginWnd;
    public CreateWnd createWnd;
    public override  void InitSys() {
        base.InitSys();
        instance = this;
        Debug.Log("Init login System");
    }
    public void EnterLogin() {
       //display loading progress
        resSvc.AsyncLoadScene(Constants.SceneLogin,OpenLoginWnd);
    }
    public void OpenLoginWnd() {
        //after loading then open login interface
        loginWnd.SetWndState();
        audioSvc.PlayBGMusic(Constants.BGlogin);
    }
    public void RsLogin() {
        GameRoot.AddTips("Login Successfully");
        //open creation character UI
        createWnd.SetWndState();
        //close login UI
        loginWnd.SetWndState(false);
    }
}