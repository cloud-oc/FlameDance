using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using DG.Tweening;

public class CameraEffects1 : CameraEffects
{
    Camera m_Camera;
    public float startSize = 10;
    public float Timer = 1;
    float ToSize;
    static bool sta = false;
    // Start is called before the first frame update
    void Start()
    {
        if (sta)
        {
            m_Camera = GetComponent<Camera>();
            ToSize = m_Camera.orthographicSize;
            m_Camera.DOOrthoSize(ToSize, Timer);
            m_Camera.orthographicSize = startSize;
        }
        sta = true;
    }
}
