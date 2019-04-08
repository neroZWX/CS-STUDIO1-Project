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
    private PlayerController playerCtrl;
    public override void InitSys()
    {
        base.InitSys();
        Instance = this;
        
    }
    
    public void EnterMainCity()
    {
        MapCfg mapData = resSvc.GetMapCfgData(Constants.MainCityMapID);
        resSvc.AsyncLoadScene(mapData.sceneName, () =>
        {
           

            // load player
            LoadPlayer(mapData);

            //open main city
            maincityWnd.SetWndState();

            //Play BG of main city
            audioSvc.PlayBGMusic(Constants.BGMainCity);

            //TODO --
        });
    }
    private void LoadPlayer(MapCfg mapData)
    {
        GameObject player = resSvc.LoadPrefab(PathDefine.AssissnCityPlayerPrefab, true);
        player.transform.position = mapData.playerBornPos;
        player.transform.localEulerAngles = mapData.playerBornRote;
        player.transform.localScale = new Vector3(1.5F, 1.5F, 1.5F);

        //init camera
        Camera.main.transform.position = mapData.mainCamPos;
        Camera.main.transform.localEulerAngles = mapData.mainCamRote;

        playerCtrl = player.GetComponent<PlayerController>();
        playerCtrl.Init();
    }


    public void SetMoveDir(Vector2 Con2)
    {
        if (Con2 == Vector2.zero)
        {
            playerCtrl.SetBlend(Constants.BlendIdle);
        }
        else
        {
            playerCtrl.SetBlend(Constants.BlendWalk);
        }
        playerCtrl.Dir = Con2;
    }
}
