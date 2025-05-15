using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaojuUI : MonoBehaviour
{
    public Daoju daoju;
    //static int num = 0;
    DaojuUI() { }
    public void use()
    {
        if(daoju)Bag.it.useAndRemove(daoju.id);
        //print(id);
    }
}
