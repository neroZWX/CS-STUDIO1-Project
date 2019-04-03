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
    public DynamicWnd dynamicWnd;
    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(this);
        Debug.Log("Game Starting...");
        CleanUI();
        init();
      
    }
    private void CleanUI() {
        Transform canvas = transform.Find("Canvas");
        for (int i = 0; i < canvas.childCount; i++) {
            canvas.GetChild(i).gameObject.SetActive(false);
        }
        dynamicWnd.SetWndState();
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
        MainCitySys mainCitySys = GetComponent<MainCitySys>();
        mainCitySys.InitSys();

        // enter login interface
        log.EnterLogin();

       // dynamicWnd.AddTips("Chicken head soup");
        //dynamicWnd.AddTips("Chicken foot");

    }
    public static void AddTips(string tips) {
        instance.dynamicWnd.AddTips(tips);
    }
}