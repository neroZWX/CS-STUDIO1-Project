/****************************************************
    File    ：MainCitySys.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/4/3 21:17:5
	function: Nothing
*****************************************************/

using UnityEngine;

public class MainCitySys : SystemRoot 
{
    public static MainCitySys Instance = null;
    public MainCityWnd maincityWnd;
    public override void InitSys()
    {
        base.InitSys();
        Instance = this;
        
    }
    public void EnterMainCity() {
        resSvc.AsyncLoadScene(Constants.SceneMainCity, () =>
        {
            //TODO Loading main character

            //Open the UI of main city
            maincityWnd.SetWndState();

            // play BG of main city
            audioSvc.PlayBGMusic(Constants.BGMainCity);
        });
    }
}