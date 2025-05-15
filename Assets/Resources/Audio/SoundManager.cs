using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//音频管理类
public class SoundManager : MonoBehaviour
{
    //SoundManager的实例
    public static SoundManager instance;
    //音源
    private AudioSource audioSource;
    //音频缓存字典
    private Dictionary<string, AudioClip> dictAudio;

    //配乐音量
    private float musicVolume = 1;
    //音效音量
    private float SFXVolume = 1;

    void Awake()
    {
        if(!instance) instance = this;
        audioSource = gameObject.GetComponent<AudioSource>();
        dictAudio = new Dictionary<string, AudioClip>();
    }

    private void Update()
    {
        // 从UIContrlerVar获取音量值
        musicVolume = UIContrlerVar.MusicValue * UIContrlerVar.MasterValue;
        SFXVolume = UIContrlerVar.SoundeffectValue * UIContrlerVar.MasterValue;

        // 实时应用音乐音量到音频源
        audioSource.volume = musicVolume;
    }

    // 辅助函数：加载音频，需要确保音频文件的路径在Resources文件夹下
    private AudioClip LoadAudio(string path)
    {
        return (AudioClip)Resources.Load(path);
    }

    //辅助函数：获取音频，并且将其缓存在dictAudio中，避免重复加载
    private AudioClip GetAudio(string path)
    {
        if (!dictAudio.ContainsKey(path))
        {
            dictAudio[path] = LoadAudio(path);
        }

        return dictAudio[path];
    }

    //播放音乐（默认循环）
    public void PlayBGM(string path, bool IsLoop = true)
    {
        this.audioSource.Stop(); // 停止当前播放的音频
        this.audioSource.clip = GetAudio(path); // 设置要播放的音频剪辑
        this.audioSource.volume = musicVolume; // 设置音量为musicVolume的值
        Debug.Log(musicVolume);
        audioSource.Play(); // 开始播放
        this.audioSource.loop = IsLoop; // 设置是否循环播放
    }
    //暂停音乐
    public void StopBGM()
    {
        this.audioSource.Stop();
    }
    //播放音效（音频管理类的挂载对象的AudioSource）
    public void PlaySound(string path)
    {
        this.audioSource.PlayOneShot(GetAudio(path), SFXVolume);
        // this.audioSource.volume = volume;
    }
    //播放音效（物体自身的AudioSource组件）
    public void PlaySound(AudioSource selfAudioSource, string path)
    {
        selfAudioSource.PlayOneShot(GetAudio(path), SFXVolume);
        // audioSource.volume = volume;
    }
}