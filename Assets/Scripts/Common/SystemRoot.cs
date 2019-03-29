/****************************************************
    File    ：SystemRoot.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/3/13 21:21:30
	function: Nothing
*****************************************************/

using UnityEngine;

public class SystemRoot : MonoBehaviour 
{
    protected ResSvc resSvc;
    protected AudioSvc audioSvc;
    public virtual void InitSys() {
        resSvc = ResSvc.instance;
        audioSvc = AudioSvc.Instace;
    }
}