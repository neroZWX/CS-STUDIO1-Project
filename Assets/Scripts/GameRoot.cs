/****************************************************
    File    ：GameRoot.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/2/13 22:2:0
	function: Nothing
*****************************************************/

using UnityEngine;

public class GameRoot : MonoBehaviour 
{
    public static GameRoot instance= null;
    public LoadingWnd loadingWnd;
    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(this);
        Debug.Log("Game Starting...");
        init();
    }
    private void init()
    {    // initalized service
        ResSvc res = GetComponent<ResSvc>();
        res.InitSvc();
        //init audio service
        AudioSvc audio = GetComponent<AudioSvc>();
        audio.InitSvc();
        // init login
        LoginSys log = GetComponent<LoginSys>();
        log.InitSys();
        // enter login interface
        log.EnterLogin();
    }
}