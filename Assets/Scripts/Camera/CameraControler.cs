using DG.Tweening;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CameraControler : MonoBehaviour
{
    private AudioSource audioSource;
    public Transform Leftdown;
    public Transform Rightup;
    [Header("")]
    public UnityEvent UnityEvents;
    public GameObject focusGamObject;
    Camera m_Camera;
    float startSize;
    string directives="none";
    bool canClearDirectives = false;

    Rigidbody2D rigidbody2;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        m_Camera = GetComponent<Camera>();
        startSize = m_Camera.orthographicSize;
        transform.position = GameManager.instant.getPlayer().transform.position + new Vector3(0, 0, -100);
        rigidbody2 = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Directives();
        if (directives == "none") GsPlayer();
        //位置限制
        if (transform.position.y > Rightup.position.y && rigidbody2.linearVelocity.y > 0) rigidbody2.linearVelocity = new Vector2(rigidbody2.linearVelocity.x, 0);
        if (transform.position.y < Leftdown.position.y && rigidbody2.linearVelocity.y < 0) rigidbody2.linearVelocity = new Vector2(rigidbody2.linearVelocity.x, 0);
        if (transform.position.x < Leftdown.position.x && rigidbody2.linearVelocity.x < 0) rigidbody2.linearVelocity = new Vector2(0, rigidbody2.linearVelocity.y);
        if (transform.position.x > Rightup.position.x && rigidbody2.linearVelocity.x > 0) rigidbody2.linearVelocity = new Vector2(0, rigidbody2.linearVelocity.y);
    }
    //�������
    void GsPlayer()
    {
        Vector2 velocity = GameManager.instant.getPlayer().transform.position - transform.position;
        rigidbody2.linearVelocity = Vector2.Lerp(velocity, rigidbody2.linearVelocity, Time.deltaTime * 5);
    }
    //ָ��Ч��
    void Directives()
    {
        switch (directives)
        {
            case "focus":
                if (m_Camera.orthographicSize == startSize) m_Camera.DOOrthoSize(10, 1).OnKill(() => {canClearDirectives = true; });
                break;

        }
        if (canClearDirectives)
        {
            directives = "none";
            UnityEvents.Invoke();
            if (sceneName != "") GameManager.instant.LoadScene(sceneName);
            canClearDirectives = false;
        }
    }
    void setDirectives(string dir)
    {
        directives = dir;
    }
    //�۽�
    public void focus(Vector3 vector3)
    { 
        setDirectives("focus");
        GetComponent<Rigidbody2D>().DOMove(vector3, 1f).SetEase(Ease.InOutSine);
        //transform.position = new Vector3(vector3.x, vector3.y, transform.position.z);
    }

    public void focus(GameObject gameObject)
    {
        focus(gameObject.transform.position);
    }
    public void focus()
    {
        focus(GameManager.instant.getPlayer());
    }
    string sceneName = "";
    public void focusLoadScene(string sceneName)
    {
        SoundManager.instance.PlaySound(SoundConst.SE_WHOOSH);
        focus(focusGamObject);
        this.sceneName = sceneName;
    }
    public void setFocusGamObject(GameObject gameObject)
    {
        focusGamObject = gameObject;
    }
}
