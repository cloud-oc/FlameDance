using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag
{
    static int Maxnum = 4;
    public Daoju[] Daojus = new Daoju[Maxnum];
    public static Bag it { get; private set; }= new Bag();

    public bool add(Daoju daoju)
    {
        DaojuInit.objects.Add(daoju.name);
        int i = 0;
        for (; i < Daojus.Length; i++)
            if (Daojus[i] == null) break;
        if (i < Daojus.Length) 
        {
            Daojus.SetValue(daoju, i);
            return true;
        }
        else return false;
    }
    public bool remove(Daoju daoju)
    {
        for(int i = 0; i < Daojus.Length;i++)
        {
            if (Daojus[i].name == daoju.name)
            {
                Daojus[i] = null;
                return true;
            }
        }
        return false;
    }
    public bool useAndRemove(Daoju daoju)
    {
        if (daoju != null)
            for (int i = 0; i < Daojus.Length; i++)
            {
                if (Daojus[i] &&Daojus[i].name == daoju.name)
                {
                    Daojus[i].Use();
                    if (daoju.isOneUse)Daojus[i] = null;
                    return true;
                }
            }
        return false;
    }
    public bool useAndRemove(int id)
    {
            for (int i = 0; i < Daojus.Length; i++)
            {
                if (Daojus[i] && Daojus[i].id == id)
                {
                    Daojus[i].Use();
                    if (Daojus[i].isOneUse) Daojus[i] = null;
                    return true;
                }
            }
        return false;
    }
    public bool useAndRemove(string name)
    {
        for (int i = 0; i < Daojus.Length; i++)
        {
            if (Daojus[i] && (Daojus[i].name == name|| Daojus[i].name == name+"(Clone)"))
            {
                Daojus[i].Use();
                if (Daojus[i].isOneUse) Daojus[i] = null;
                return true;
            }
        }
        return false;
    }
    public bool useAndRemove(string[] name)
    {
        if (name==null || name.Length == 0) return false;
        string[] key = new string[name.Length] ;
        int index = 0;
        bool s = false;
        foreach(var it in name) 
        {
            for (int i = 0; i < Daojus.Length; i++)
            {
                if (Daojus[i] && (Daojus[i].name == it || Daojus[i].name == it + "(Clone)")){
                    if (index >= key.Length) break;
                    s = false;
                    foreach (var ob in key) if (ob == it) s = true;
                    if(!s)key[index++] = it;
                }
            }
        }
        if (index < name.Length) return false;
        foreach (var it in key)useAndRemove(it); 
        return true;
    }
}
