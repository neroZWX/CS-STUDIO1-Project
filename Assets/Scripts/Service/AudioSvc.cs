/****************************************************
    File    ：AudioSvc.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/2/22 1:20:40
	function: Nothing
*****************************************************/

using UnityEngine;

public class AudioSvc : MonoBehaviour 
{
    public static AudioSvc Instace = null;
    public AudioSource BGAudio;
    public AudioSource UIAudio;

    public void InitSvc() {
        Instace = this;
        Debug.Log("Init AudioSvc....");
    }
    public void PlayBGMusic(string name, bool isLoop = true) {
        AudioClip audio = ResSvc.instance.LoadAudio("ResAudio/"+name,true);
        if (BGAudio.clip ==null|| BGAudio.clip.name!= audio.name) {
            BGAudio.clip = audio;
            BGAudio.loop = isLoop;
            BGAudio.Play();
        }
    }
    public void PlayUIAudio(string name) {
        AudioClip audio = ResSvc.instance.LoadAudio("ResAudio/" +name,true);
            UIAudio.clip = audio;
            UIAudio.Play();
        }
    }
