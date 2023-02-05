using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateDebuffs : MonoBehaviour
{

    [SerializeField] List<Debuffs> myDebuffs = new List<Debuffs>();
    List<Debuffs> canRemoveDebuffs = new List<Debuffs>();

    [SerializeField] GameObject card1, card2, card3, canvas;


    private void Start()
    {
        //RandomDebuffs();
    }
    public void RandomDebuffs()  //Ejecutar cuando haya que mostrar debuffs
    {
        foreach (Debuffs debuff in myDebuffs)
        {
            canRemoveDebuffs.Add(debuff);
        }
        int a = Random.Range(0, canRemoveDebuffs.Count);
        ChangeCardInfo(card1,canRemoveDebuffs[a]);
        canRemoveDebuffs.RemoveAt(a);

        int b = Random.Range(0, canRemoveDebuffs.Count);
        ChangeCardInfo(card2, canRemoveDebuffs[b]);
        canRemoveDebuffs.RemoveAt(b);

        int c = Random.Range(0, canRemoveDebuffs.Count);
        ChangeCardInfo(card3, canRemoveDebuffs[c]);
        canRemoveDebuffs.RemoveAt(c);

        ShowCards();
    }

    void ChangeCardInfo( GameObject card,Debuffs debuff)
    {
        card.transform.GetChild(2).GetComponent<Image>().sprite = debuff.mySprite;
        card.transform.GetChild(3).GetComponent<Text>().text = debuff.myName;
        card.transform.GetChild(4).GetComponent<Text>().text = debuff.myDescription;
        card.transform.GetChild(5).GetComponent<Text>().text = debuff.ID;
    }

    void ShowCards()
    {
        Time.timeScale = 0;
        canvas.SetActive(true);

    }

    public void ClickThis(Button thisButton)
    {
        ExecuteDebuff(thisButton.gameObject.transform.GetChild(5).GetComponent<Text>());
    }

    void ExecuteDebuff(Text IDDebuff)
    {
        Debug.Log(IDDebuff.text);

        if (IDDebuff.text == "-Speed")
        {
            //hacer efecto del debuff
        }
        if (IDDebuff.text == "SlowBullets")
        {
            //hacer efecto del debuff
        }
        if (IDDebuff.text == "Buff")
        {
            //hacer efecto del debuff
        }
        if (IDDebuff.text == "-Atk")
        {
            //hacer efecto del debuff
        }
        if (IDDebuff.text == "+CD")
        {
            //hacer efecto del debuff
        }
        if (IDDebuff.text == "-hp")
        {
            //hacer efecto del debuff
        }
        if (IDDebuff.text == "AllDebuffs")
        {
            //hacer efecto del debuff
        }

        //al final
        HideCards();
    }

    void HideCards()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
    }
}
