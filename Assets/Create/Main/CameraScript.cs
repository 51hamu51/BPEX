using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraScript : MonoBehaviourPunCallbacks
{
    private GameObject me;

    /// <summary>
    /// 移動感度
    /// </summary>
    public float cameraSensitivity = 3f;

    /// <summary>
    /// 現在の上下角度
    /// </summary>
    private float pitch = 20f;

    /// <summary>
    /// 下限
    /// </summary>
    public float minPitch = -50f;

    /// <summary>
    /// 上限
    /// </summary>
    public float maxPitch = 60f;

    private float distance = -5f;
    private float height = 2f;

    private Transform cameraTransform;

    void Start()
    {

    }

    void LateUpdate()
    {
        if (me == null)
        {
            me = GameObject.FindWithTag("Me");
            if (me == null)
            {
                return;
            }
        }

        // マウスY入力を受け取る
        float my = Input.GetAxis("Mouse Y") * cameraSensitivity;

        if (PauseTextScript.Pause == 1)
        {
            // 入力で仮の角度を計算
            float nextPitch = Mathf.Clamp(pitch - my, minPitch, maxPitch);

            // 角度が範囲内のときだけ RotateAround を実行
            if (Mathf.Abs(nextPitch - pitch) > 0.001f)
            {
                transform.RotateAround(me.transform.position, transform.right, -my);
                pitch = nextPitch; // 実際の角度を更新
            }
        }

        //カメラの位置を調整
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent<Camera>().transform;
        }
        cameraTransform.parent = me.transform;
        cameraTransform.position = me.transform.position;
        transform.position += transform.forward * distance;
        transform.position += transform.up * height;
    }
}
