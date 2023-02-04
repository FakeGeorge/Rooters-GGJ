using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateDebuffs : MonoBehaviour
{

    [SerializeField] List<Debuffs> myDebuffs = new List<Debuffs>();
    List<Debuffs> canRemoveDebuffs = new List<Debuffs>();

    [SerializeField] GameObject card1, card2, card3;

    private void Start()
    {
        RandomDebuffs();
    }

    public void RandomDebuffs()
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
    }

    void ChangeCardInfo( GameObject card,Debuffs debuff)
    {
        card.transform.GetChild(0).GetComponent<Image>().sprite = debuff.mySprite;
        card.transform.GetChild(1).GetComponent<Text>().text = debuff.myName;
        card.transform.GetChild(2).GetComponent<Text>().text = debuff.myDescription;
    }

    public void ClickThis(Button thisButton)
    {
        ExecuteDebuff(thisButton.gameObject.transform.GetChild(1).GetComponent<Text>());
    }

    void ExecuteDebuff(Text nombreDebuff)
    {
        Debug.Log(nombreDebuff.text);

        if (nombreDebuff.text == "loquesea")
        {
            //hacer efecto del debuff
        }
    }

}
