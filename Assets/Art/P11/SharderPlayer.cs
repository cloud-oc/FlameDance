using UnityEngine;

[ExecuteInEditMode]
public class SharderPlayer : MonoBehaviour
{
    public GameObject over;
    [Range(0.0f, 1.0f)]
    float luminosity = 0.0f;
    Color color = Color.white;
    Material grayscaleMaterial;

    private void Start()
    {
        grayscaleMaterial = GetComponent<Renderer>().sharedMaterial;
    }
    void FixedUpdate()
    {
        // 注释掉淡出效果
        /*
        if (luminosity < 1)
        {
            luminosity += Time.deltaTime/2;
            color-= Color.white * Time.deltaTime/2;
            grayscaleMaterial.SetFloat("_GrayscaleAmount", luminosity);
            grayscaleMaterial.SetColor("_LightColor", color);
        }
        else
        {
            GameManager.instant.Over();
            over.SetActive(true);
            gameObject.SetActive(false);
        }
        */

        // 加载开始界面
        //GameManager.instant.LoadScene("StartScene");
        over.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        GameManager.instant.Player.GetComponent<PlayerMove>().enabled = false;
    }
}