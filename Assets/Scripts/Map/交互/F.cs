using DG.Tweening;
using UnityEngine;

public class F : MonoBehaviour
{
    static bool ON = true;
    void Start()
    {
        ON = !Flight.on;
        if (!ON) gameObject.SetActive(false);
        else
        {
            //transform.DOBlendableLocalMoveBy(transform.position + Vector3.right * 50, 3).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
            //transform.DOBlendableLocalMoveBy(transform.position + Vector3.up * 10, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
        
    }
}
