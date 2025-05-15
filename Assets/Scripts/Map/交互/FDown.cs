using Unity.VisualScripting;
using UnityEngine;

public class FDown : MonoBehaviour
{
    [Header("爬绳设置")]
    [Tooltip("爬绳速度，数值越大移动越快")]
    [SerializeField] private float climbSpeed = 2000f;  // 默认值设为2000

    [Header("位置设置")]
    [Tooltip("玩家攀爬时的位置偏移量")]
    [SerializeField] private Vector2 climbOffset = Vector2.zero;

    bool onPlayer = false;
    AudioSource audioSource;
    GameObject plyer;
    private void Start()
    {
        plyer = GameManager.instant.getPlayer();
        audioSource = GetComponent<AudioSource>();
    }
    private void LateUpdate()
    {
        if (onPlayer)
        {
            plyer.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            plyer.transform.rotation = Quaternion.Euler(0, 0, 0);
            plyer.GetComponent<Rigidbody2D>().linearVelocityY = climbSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!onPlayer && collision.tag == "Player")
        {
            onPlayer = true;
            collision.GetComponent<Animator>().SetBool("Down", true);
            SoundManager.instance.PlaySound(audioSource, SoundConst.SE_ROPE);
            collision.transform.position = new Vector3(transform.position.x + climbOffset.x, plyer.transform.position.y + climbOffset.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.audioSource.Stop();
            onPlayer = false;
            collision.GetComponent<Animator>().SetBool("Down", false);
        }
    }

    private void OnDrawGizmos()
    {
        // 绘制攀爬点位置
        Gizmos.color = Color.white;
        Vector3 climbPosition = transform.position + new Vector3(climbOffset.x, climbOffset.y, 0);
        Gizmos.DrawWireSphere(climbPosition, 0.2f);
        Gizmos.DrawLine(transform.position, climbPosition);
    }
}
