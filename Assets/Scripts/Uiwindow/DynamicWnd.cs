/****************************************************
    File    ：Dynamatic.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/3/14 0:50:57
	function: Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicWnd : WindowRoot
{
    public Animation TipsAni;
    public Text TextTips;
    private Queue<String> TipsQue = new Queue<String>();
    private bool isTipsShow = false;
    protected override void InitWnd() {
        base.InitWnd();
        SetActive(TextTips, false);
    }
    public void AddTips(string tips) {
        lock (TipsQue) {
            TipsQue.Enqueue(tips);
        }
    }
    private void Update()
    {
        if (TipsQue.Count > 0 && isTipsShow == false) {
            lock (TipsQue) {
               string tips= TipsQue.Dequeue();
                isTipsShow = true;
                SetTips(tips);
            }
        }
    }
    private void SetTips(string tips)
    {
        SetActive(TextTips);
        SetText(TextTips, tips);
        AnimationClip clip = TipsAni.GetClip("TipsShowAnimation");
        TipsAni.Play();
        StartCoroutine(AniPlayDone(clip.length,() =>
        {
            SetActive(TextTips, false);
            isTipsShow = false;
        }));
    }
    private IEnumerator AniPlayDone(float sec, Action cb) {
        yield return new WaitForSeconds(sec);
        if (cb != null) {
            cb();
        }

    }
}