/****************************************************
    File    ：NewBehaviourScript.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/2/13 22:5:34
	function: Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResSvc : MonoBehaviour 
{   // can be called by others class
    public static ResSvc instance = null;
    public void InitSvc() {
        instance = this;
        InitRdNameCfg();
        Debug.Log("Init Svc.... ");
       
    }//for loading 
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
    public AudioClip LoadAudio(string path, bool cache = false)
    {
        AudioClip au = null;
        if (!adDic.TryGetValue(path, out au))
        {
            au = Resources.Load<AudioClip>(path);

            if (cache)
            {
                adDic.Add(path, au);
            }
        }
        return au;
    }
     
    #region InitCfgs
    private List<string> surnameLst = new List<string>();
    private List<string> firstnameLst = new List<string>();
    private void InitRdNameCfg()
    {
        // get xml file
        TextAsset xml = Resources.Load<TextAsset>(PathDefine.RdNameCfgs);
        if (!xml)
        {
            Debug.LogError("xml file:" + PathDefine.RdNameCfgs + "not exist");
        }
        else
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml.text);
            XmlNodeList nodeList = doc.SelectSingleNode("root").ChildNodes;
            for (int i = 0; i < nodeList.Count; i++)
            {
                XmlElement ele = nodeList[i] as XmlElement;
                if (ele.GetAttributeNode("ID") == null)
                {
                    continue;

                }
                //ele.GetAttributeNode("ID");
                int ID = Convert.ToInt32(ele.GetAttributeNode("ID").InnerText);

                foreach (XmlElement e in nodeList[i].ChildNodes)
                {
                    switch (e.Name)
                    {
                        case "surname":
                            surnameLst.Add(e.InnerText);
                            break;
                        case "firstname":
                            firstnameLst.Add(e.InnerText);
                            break;
                    }
                }
            }

        }
    }
    public string GetRdNameData(bool fullname = true) {
        System.Random rd = new System.Random();
        string rdName = surnameLst[Tools.RDInt(0,surnameLst.Count-1)];
       
        rdName += firstnameLst[Tools.RDInt(0, firstnameLst.Count - 1)];
        
        return rdName;
    }
  #endregion

}