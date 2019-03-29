/****************************************************
    File    ：LoopDA.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/3/14 0:30:54
	function: Nothing
*****************************************************/

using UnityEngine;
using System;

public class LoopDA : MonoBehaviour 
{
   
    private Animation ani;
    private void Awake()
    {
        ani = transform.gameObject.GetComponent<Animation>();
    }
    private void Start()
    {
        if (ani!=null) {
            InvokeRepeating("PlayDragonAni",0,15);

        }
    }
    public void PlayDragonAni() {
        if (ani != null) {
            ani.Play();
        }
    }
}