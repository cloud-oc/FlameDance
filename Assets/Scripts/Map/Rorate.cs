using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rorate : MonoBehaviour
{
    void Update()
    {
        if(!SetRo.on)transform.Rotate(0, 0, -Time.deltaTime*60);
    }
}
