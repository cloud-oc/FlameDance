using UnityEngine;

abstract public class DaojuUsePorint : MonoBehaviour
{
    public string[] needDaojus;
    public string needDaoju;
    public bool OnPlayer = false;
    private void Start()
    {
       if(getused1())used1Eff();
    }
    void Update()
    {
        if (OnPlayer && Input.GetKeyDown(KeyCode.F) && !getused1())
        {
            ff();
        }
    }
    public void ff()
    {
        if (!Bag.it.useAndRemove(needDaoju))
        {
            if (!Bag.it.useAndRemove(needDaojus)) print("»±…Ÿµ¿æﬂ:"+needDaoju + needDaojus);
            else { setused1(); used1Eff(); }
        }
        else { setused1(); used1Eff(); }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnPlayer = false;
        }
    }
    abstract public void setused1();
    abstract public bool getused1();
    abstract public void used1Eff();

}
