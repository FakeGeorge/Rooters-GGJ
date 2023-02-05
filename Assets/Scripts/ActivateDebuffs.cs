using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateDebuffs : MonoBehaviour
{

    [SerializeField] List<Debuffs> myDebuffs = new List<Debuffs>();
    List<Debuffs> canRemoveDebuffs = new List<Debuffs>();

    [SerializeField] GameObject card1, card2, card3, canvas;

    [SerializeField] Settings settings;
    [SerializeField] AudioClip Click;
    [SerializeField] PlayerController pc;
    [SerializeField] PlayerHealth ph;
    private void Start()
    {
        settings = GameObject.Find("Settings").GetComponent<Settings>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        ph = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        //RandomDebuffs();
    }

    public void PlaySound(AudioClip clip)
    {
        settings.PlaySFX(clip);
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
            pc.speed -= 2;
            //hacer efecto del debuff
        }
        if (IDDebuff.text == "SlowBullets")
        {
            Bullet.speed -= 4;
            //hacer efecto del debuff
        }
        if (IDDebuff.text == "Buff")
        {
            PlayerController.dmgAdded = +2;
            //hacer efecto del debuff
        }
        if (IDDebuff.text == "-Atk")
        {
            PlayerController.dmgAdded = -2;
            //hacer efecto del debuff
        }
        if (IDDebuff.text == "+CD")
        {
            pc.timeBetweenShots += 0.5f;
            //hacer efecto del debuff
        }
        if (IDDebuff.text == "-hp")
        {
            ph.health -= 2;
            //hacer efecto del debuff
        }
        if (IDDebuff.text == "AllDebuffs")
        {
            ph.health -= 2;
            PlayerController.dmgAdded = -2;
            pc.speed -= 2;
            Bullet.speed -= 4;
            pc.timeBetweenShots += 0.5f;
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
