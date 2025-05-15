using DG.Tweening;
using UnityEngine;

public class Fmove : MonoBehaviour
{
    RectTransform RectTransform;
    void Start()
    {
        RectTransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        RectTransform.position = Vector3.Lerp (RectTransform.position,Camera.main.WorldToScreenPoint(GameManager.instant.getPlayer().transform.position - (Vector3.left*10)),Time.deltaTime*10);
    }
}
