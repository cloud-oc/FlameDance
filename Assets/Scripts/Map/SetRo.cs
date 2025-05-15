using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class SetRo : MonoBehaviour
{
    public GameObject key;
    private AudioSource audioSource;
    static Quaternion Ro;
    public static float time = 0;
    public static bool on = false;
    private void Awake()
    {
        if (Door.on) key.SetActive(true);
        else key.SetActive(false);
    }
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (Ro == null) { Ro = new(); }
        transform.rotation = Ro;
    }
    private void OnMouseDrag()
    {
        float z;
        Vector3 vector3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vector3 -= transform.position;
        z = math.atan2(vector3.y, vector3.x) * 360 / (2 * math.PI);
        transform.rotation = Quaternion.Euler(0, 0, z - 90);
        Ro = transform.rotation;

        if (z - 90 < 0) time = (90 - z) / 30f;
        else time = 12 - ((z - 90) / 30f);
        on = true; 
    }
    private void OnMouseUp()
    {
        if (time > 4 && time < 6) { Door.on = true; SoundManager.instance.PlaySound(audioSource,SoundConst.SE_CLOCK); key.SetActive(true); }
        else { Door.on = false; }
    }
}
