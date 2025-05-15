using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameObjectVars", order = 1)]
public class Vars : ScriptableObject
{
    [Header("on")]
    public GameObject[] UIGameObjects;
    [Header("off")]
    public GameObject[] UIGameObjects0;
    [Header("ÎÄ±¾ÏÔÊ¾")]
    public GameObject tip;
    public void loadScense(string name)
    {
        GameManager.instant.LoadScene(name);
    }
    public static bool istip = false;
    public void settip()
    {
        istip = !istip;
    }
}
