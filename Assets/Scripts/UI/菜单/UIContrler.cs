using UnityEngine;
using UnityEngine.UI;

public class UIContrler : MonoBehaviour
{
    private void Update() => GetComponent<Selectable>().Select();
}
