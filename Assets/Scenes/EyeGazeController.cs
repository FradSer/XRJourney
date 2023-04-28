using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGazeController : MonoBehaviour
{
    public GameObject cube;
    OVREyeGaze _eyeGaze;
    private bool _isEyeGazeNull;

    // スタート時に呼ばれる
    void Start()
    {
        _eyeGaze = GetComponent<OVREyeGaze>();
        _isEyeGazeNull = _eyeGaze == null;
    }

    // フレーム更新毎に呼ばれる
    void Update()
    {
        if (_isEyeGazeNull) return;

        // アイトラッキングの有効時
        if (!_eyeGaze.EyeTrackingEnabled) return;
        
        // 視線の同期
        cube.transform.rotation = _eyeGaze.transform.rotation;
    }
}