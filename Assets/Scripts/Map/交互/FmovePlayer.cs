using DG.Tweening;
using UnityEngine;

public class FmovePlayer : MonoBehaviour
{
    bool P_down = false;
    bool P_enter=false;
    bool dd = false;
    public Transform ToPosition;
    public Transform lastToPosition;
    Vector3 staPosition;
    public GameObject text;
    private void Start()
    {
        staPosition = transform.position;
        text.SetActive(false);
    }
    void Update()
    {
        if (P_down && !P_enter && !dd)
        {
            text.SetActive(false);
            transform.position = Vector3.Lerp(transform.position, GameManager.instant.getPlayer().transform.position, Time.deltaTime * 10);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (P_enter && P_down && !dd)
        {
            dd = true;
            GameManager.instant.getPlayer().transform.DOMove(ToPosition.position, 2).OnKill(() => 
                { 
                    GameManager.instant.getPlayer().transform.DOMove(lastToPosition.position, 1);
          
                }
                );
            transform.DOMove(ToPosition.position, 2).OnKill(() =>
            {
                transform.DOMove(lastToPosition.position, 1).OnKill(() =>
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    transform.DOMove(staPosition, 2).OnKill(() => { transform.rotation = Quaternion.Euler(0, 0, 0); });
                    P_down = false;
                    P_enter = false;
                    dd = false;
                    text.SetActive(true);
                }
                );
            }
            );
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player"&&P_down)P_enter = true;
    }
    public void SetPdown()
    {
        P_down = true;
    }
}
