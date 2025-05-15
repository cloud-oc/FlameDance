using UnityEngine;
using UnityEngine.UI;

public class SliderInit : MonoBehaviour
{
    public int index = 0;
    void Start()
    {
        GetComponent<Slider>().value = ReValue(index);
    }
    float ReValue(int index)
    {
        switch (index)
        {
            case 0:return UIContrlerVar.MasterValue;
            case 1:return UIContrlerVar.MusicValue;
            case 2:return UIContrlerVar.SoundeffectValue;
        }
        return 0;
    }
}
