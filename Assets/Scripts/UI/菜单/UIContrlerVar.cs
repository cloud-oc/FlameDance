using UnityEngine;
using UnityEngine.UI;

/*
   此脚本包含ui控制的函数和参数
 */
[CreateAssetMenu(fileName = "UIContrlerVar", menuName = "ScriptableObjects/UIContrlerVar", order = 2)]
public class UIContrlerVar : ScriptableObject
{
    public static float MasterValue = 1;//主音量
    public static float MusicValue = 1;//音乐
    public static float SoundeffectValue = 1;//音效
    public void QuitGame()
    {
        SoundManager.instance.PlaySound(SoundConst.SE_CLICK);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public float SetValue(GameObject gameObject)
    {
        return gameObject.GetComponent<Slider>().value;
    }
    //主音量
    public void setMasterValue(GameObject Slider)
    {
        MasterValue = SetValue(Slider);
    }
    //音乐
    public void setMusicValue(GameObject Slider)
    {
        MusicValue = SetValue(Slider);
    }
    //音效
    public void setSoundeffectValue(GameObject Slider)
    {
        SoundeffectValue = SetValue(Slider);
    }

    //按钮
    public void OpenUI(string name)
    {
        SoundManager.instance.PlaySound(SoundConst.SE_CLICK);
        GameManager.instant.OpenUI(name);
    }
    public void CloseBackUI()
    {
        SoundManager.instance.PlaySound(SoundConst.SE_CLICK);
        GameManager.instant.CloseBackUI();
    }
}
