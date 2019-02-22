/****************************************************
    File    ：NewBehaviourScript.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/2/13 22:5:34
	function: Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResSvc : MonoBehaviour 
{   // can be called by others class
    public static ResSvc instance = null;
    public void InitSvc() {
        Debug.Log("Init Svc.... ");
        instance = this;
    }
    private Action prgCB = null;
    public void AsyncLoadScene(string scenename,Action loaded) {
        GameRoot.instance.loadingWnd.SetWndState();
        
        AsyncOperation sceneAsync= SceneManager.LoadSceneAsync(scenename);
        prgCB = () =>
        {
            float val = sceneAsync.progress;
            GameRoot.instance.loadingWnd.setProgress(val);
            if (val == 1)
            {
                if (loaded != null) {
                    loaded();
                }
               // LoginSys.instance.OpenLoginWnd();
                prgCB = null;
                sceneAsync = null;
                GameRoot.instance.loadingWnd.SetWndState(false);
            }
       };
    }
    private void Update()
    {
        if (prgCB != null) {
            prgCB();
        }
    }
    // load and cache music
    private Dictionary<string, AudioClip> adDic = new Dictionary<string, AudioClip>();
    public AudioClip loadAudio(String path, bool cache = false) {
        AudioClip au = null;
        if (!adDic.TryGetValue(path, out au)) {
            au= Resources.Load<AudioClip>(path);
        }
        au = Resources.Load<AudioClip>(path);
        if (cache) {
            adDic.Add(path, au);

        }
        return au;
    }
}