/****************************************************
    File    ：PlayerController.cs
	Author  ：Nero
    E-mail  : 18050816@studentmail.ul.ie
    date    ：2019/4/4 22:9:15
	function: Nothing
*****************************************************/

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator ani;
    public CharacterController ctrl;
    private Transform CamTrans;
    private Vector3 camOffset;
    private int playerSpeed =2;

    private Vector2 dir = Vector2.zero;
    private bool isMove = false;
    public Vector2 Dir {
        get {
            return dir;
        }
        set {
            if (value == Vector2.zero)
            {
                isMove = false;
            }
            else {
                isMove = true;
            }
            dir = value;
        }
    }

    private float targetBlend;
    private float currentBlend;
    public void Init()
    {
        CamTrans = Camera.main.transform;
        camOffset = transform.position - CamTrans.position;
    }

    private void Update()
    {
        #region Input
        /*
         float h = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        Vector2 _dir = new Vector2(h, V).normalized;
        if (_dir != Vector2.zero)
        {
            Dir = _dir;
            SetBlend(1);
            
        }
        else {
            Dir = Vector2.zero;
            SetBlend(0);
            
        }
        */
        #endregion
        if (currentBlend!=targetBlend) {
            UpdateMixBlend();
        }
        

        if (isMove)
        {
            SetDir();
            SetMove();
            SetCam();
        }
    }
    private void SetDir() {
        float angle = Vector2.SignedAngle(Dir, new Vector2(0, 1));
        Vector3 eulerAngles = new Vector3(0, angle, 0);
        transform.localEulerAngles = eulerAngles;
    }
    private void SetMove() {
        ctrl.Move(transform.forward * Time.deltaTime * playerSpeed);
    }
    private void SetCam() {
        if (CamTrans != null) {
            CamTrans.position = transform.position - camOffset;
        }
    }

    public void SetBlend(float blend) {
        targetBlend = blend;

    }
    private void UpdateMixBlend() {
        if (Mathf.Abs(currentBlend - targetBlend) < 5 * Time.deltaTime)
        {
            currentBlend = targetBlend;
        }
        else if (currentBlend > targetBlend)
        {
            currentBlend -= 5 * Time.deltaTime;
        }
        else {
            currentBlend += 5 * Time.deltaTime;
        }
        ani.SetFloat("Blend", currentBlend);
    }
}