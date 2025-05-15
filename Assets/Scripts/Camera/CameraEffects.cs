using DG.Tweening;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    public void returnToScene0() 
    {
        GetComponent<Camera>().DOOrthoSize(10, 1).OnKill(() => {  PlayerMove.isIn = false; GameManager.instant.LoadScene("FrameWorld"); });
    }
}
