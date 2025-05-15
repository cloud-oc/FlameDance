using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instant;
    public Vars Vars;
    public Transform[] frames;
    List<GameObject> uiList;
    public GameObject Player;
    public GameObject Tip;
    GameObject Canvas;
    static int uiLevel = 0;
    List<GameObject> OPuiList = new List<GameObject>();
    float uiloadtime = 0.3f;
    void Awake()
    {
        uiList = new List<GameObject>();
        if (instant == null) instant = this;
        if (!Player) Player = GameObject.Find("Player");
        Canvas = GameObject.Find("Canvas");
        UIload();
        Player.transform.position = PlayerScenesPositionVar.instance.getPosition();
        int temp = SceneManager.GetActiveScene().buildIndex;
        if (Jingdu.levelP + 1 < temp) Jingdu.levelP = temp - 1;
        Jingdu.levelN = temp - 1;
        color1 = GameManager.instant.Tip.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color;
        color2 = GameManager.instant.Tip.GetComponent<Image>().color;
    }
    private void Update()
    {
        KeyControle();
    }
    public void LoadScene(string sceneName)
    {

        //��¼��ǰ����Player��λ��
        PlayerScenesPositionVar.instance.load(getPlayer().transform.position);
        LastSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
        if (SceneManager.GetSceneByName(sceneName).buildIndex != 1) PlayerMove.isIn = true;
        uiLevel = 0;
    }
    public GameObject getPlayer() { return Player; }
    //ui����
    private void UIload()
    { 
        GameObject ob;
        Tip = Instantiate(Vars.tip, Canvas.transform);
        Tip.SetActive(false);
        for (int i = 0; i < Vars.UIGameObjects.Length; i++)
        {
            ob = Instantiate(Vars.UIGameObjects[i], Canvas.transform);
            ob.SetActive(true);
            uiList.Add(ob);
        }
       
        for (int i = 0; i < Vars.UIGameObjects0.Length; i++)
        {
            ob = Instantiate(Vars.UIGameObjects0[i], Canvas.transform);
            ob.SetActive(false);
            uiList.Add(ob);
        }
       
        //Tip=Tip.transform.GetChild(0).gameObject;
    }
    //ui��������
    void KeyControle()
    {

        if (!over && Input.GetKeyDown(KeyCode.Escape))
        {
            if (uiLevel == 0)
            {
                OpenUI("菜单");
            }
            else CloseBackUI();
        }

    }

    //ui����
    public void OpenUI(string name)
    {
        Time.timeScale = 0;
        for (int i = 0; i < uiList.Count; i++)
        {
            if (uiList[i].name == name + "(Clone)")
            {
                if (!uiList[i].activeSelf)
                {
                    if (uiLevel >= 1) OPuiList[uiLevel - 1].SetActive(false);
                    uiList[i].SetActive(true);

                    Vector3 vector3 = uiList[i].transform.position;
                    if (uiLevel == 0)
                    {
                        uiList[i].transform.position = vector3 - new Vector3(0, 500, 0);
                        uiList[i].transform.DOMove(vector3, uiloadtime).SetUpdate(true);
                    }
                    OPuiList.Add(uiList[i]);
                    uiLevel++;
                    break;
                }
            }
        }
    }

    public void NojlOpenUI(string name)
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            if (uiList[i].name == name + "(Clone)")
            {
                uiList[i].SetActive(true);
                break;
            }
        }
    }
    public void NojlCloseUI(string name)
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            if (uiList[i].name == name + "(Clone)")
            {
                uiList[i].SetActive(false);
                break;
            }
        }
    }
    public void CloseBackUI()
    {
        if (uiLevel <= 0) return; // 添加边界检查

        OPuiList[--uiLevel].SetActive(false);
        OPuiList.RemoveAt(uiLevel);
        if (uiLevel >= 1)
        {

            OPuiList[uiLevel - 1].SetActive(true);
            
            //Vector3 vector3 = OPuiList[uiLevel - 1].transform.position;
            //OPuiList[uiLevel - 1].transform.position = vector3 - new Vector3(0, 500, 0);
            //OPuiList[uiLevel - 1].transform.DOMove(vector3, uiloadtime).SetUpdate(true);

        }
        if (uiLevel == 0) Time.timeScale = 1;
    }

    //����λ��
    static int LastSceneIndex;
    public Vector2 Scene0framePosition()
    {

        if (LastSceneIndex - 2 >= 0 && LastSceneIndex - 2 < frames.Length) return frames[LastSceneIndex - 2].position;
        return new Vector2(0,-3);
    }
    public bool over = false;
    public void Over()
    {
        Player.SetActive(false);
        NojlCloseUI("提示");
        over = true;
    }
    Color color1;
    Color color2;
    bool ki=false;
    public void setTipText(string str)
    {
        if(!Vars.istip)return;//取消提示
        Tip.SetActive(true);
        TextMeshProUGUI i = Tip.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Image t = Tip.GetComponent<Image>();
        i.text = str;
        i.color = Color.clear;
        t.color = Color.clear;
        i.DOKill(); i.DOKill(); i.DOKill();
        t.DOKill(); t.DOKill(); t.DOKill();
        CancelInvoke();
        if (!ki) {
            ki = true;
            i.DOColor(color1, 1).SetUpdate(true).OnKill(() => { i.DOColor(color1, 3).SetUpdate(true).OnKill(() => { i.DOColor(Color.clear, 1).SetUpdate(true); }); });
            t.DOColor(color2, 1).SetUpdate(true).OnKill(() => { t.DOColor(color2, 3).SetUpdate(true).OnKill(() => { t.DOColor(Color.clear, 1).SetUpdate(true); }); });
            Invoke("closeTip", 5);
        }
        else 
        {
            i.color = color1;
            t.color = color2;
            i.DOColor(color1, 3).SetUpdate(true).OnKill(() => { i.DOColor(Color.clear, 1).SetUpdate(true); });
            t.DOColor(color2, 3).SetUpdate(true).OnKill(() => { t.DOColor(Color.clear, 1).SetUpdate(true); });
            Invoke("closeTip", 4);
        }
    } 
    void closeTip() { Tip.SetActive(false); ki = false;}
}
