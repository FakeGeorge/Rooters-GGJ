using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TreeOfLife : MonoBehaviour
{
    private PlayerController _player;

    public FadeOut fadeOut_script;

    public Text textoTransicion;

    public Image HealthBar;
    float lerpSpeed;

    public float hp;
    public float hpMax;
    [SerializeField] List<Sprite> mySprites = new List<Sprite>();
    Sprite currentSprite;

    [SerializeField] ParticleSystem ps_treeHit;

    [SerializeField] GameManager gm;

    [SerializeField] ActivateDebuffs debuffs;
    private void Start()
    {
        hp = hpMax;
        gameObject.GetComponent<SpriteRenderer>().sprite = mySprites[0];
        textoTransicion.gameObject.SetActive(false);

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        debuffs = GameObject.Find("MenuDebuff").GetComponent<ActivateDebuffs>();
    }

    private void Update()
    {
        HealthBarFiller();
        ColorChanger();
        lerpSpeed = 3f * Time.deltaTime;
    }

    public void GetDamage(float damage)
    {
        hp -= damage;
        ps_treeHit.Play();
        //animación de ser golpeado/particulas/algo

        if (hp <= hpMax*.75f && GameManager.miEpoca == GameManager.Epocas.futuro)  //si está a 75% vida y en prehistoria, cambia a medievo
        {
            Debug.Log("Cambia ACTUAL");
            GameManager.miEpoca = GameManager.Epocas.actual;
            currentSprite = mySprites[1];
            StartCoroutine("Transicion");
        }
        if (hp <= hpMax* .5f && GameManager.miEpoca == GameManager.Epocas.actual)
        {
            Debug.Log("Cambia MEDIEVO");
            GameManager.miEpoca = GameManager.Epocas.medievo;
            currentSprite = mySprites[2];
            StartCoroutine("Transicion");
        }
        if (hp <= hpMax* .25f && GameManager.miEpoca == GameManager.Epocas.medievo)
        {
            GameManager.miEpoca = GameManager.Epocas.prehistoria;
            currentSprite = mySprites[3];
            StartCoroutine("Transicion");
        }

        if (hp <= 0f)
        {
            StartCoroutine("Dead");
        }
        
    }

    IEnumerator Transicion()
    {
        //FADE IN
        Time.timeScale = 0f;
        fadeOut_script.activarFade = true;
        yield return new WaitForSecondsRealtime(3);

        //ACTIVAMOS TEXTO, MOMENTO EN NEGRO
        textoTransicion.gameObject.SetActive(true);
        textoTransicion.text = "" + GameManager.miEpoca.ToString();
        gameObject.GetComponent<SpriteRenderer>().sprite = currentSprite;
        yield return new WaitForSecondsRealtime(3);

        if (GameManager.miEpoca == GameManager.Epocas.actual)
        {
            _player.Futurista = false;
            _player.Actual = true;
            _player.Medieval = false;
            _player.Prehistoria = false;
        }
        if (GameManager.miEpoca == GameManager.Epocas.medievo)
        {
            _player.Futurista = false;
            _player.Actual = false;
            _player.Medieval = true;
            _player.Prehistoria = false;
        }
        if (GameManager.miEpoca == GameManager.Epocas.prehistoria)
        {
            _player.Futurista = false;
            _player.Actual = false;
            _player.Medieval = false;
            _player.Prehistoria = true;
        }

        gm.KillAllInstancedEnemies();

        Debuffs();

        //FADE OUT, SE DESACTIVA TEXTO
        fadeOut_script.fadeIn = false;
        textoTransicion.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(2);

        //RESET DE TODO XD
        fadeOut_script.activarFade = false;
        fadeOut_script.fadeIn = true;
        fadeOut_script.myUI.alpha = 0f;
        fadeOut_script.alpha = 1f;
        FadeIn.alpha = 0f;
        //Time.timeScale = 1f;
    }

    void Debuffs()
    {
        debuffs.RandomDebuffs();
    }

    IEnumerator Dead()
    {
        Time.timeScale = 0f;
        fadeOut_script.activarFade = true;
        yield return new WaitForSecondsRealtime(3);
        textoTransicion.gameObject.SetActive(true);
        textoTransicion.color = Color.red;
        textoTransicion.text = "FIN DEL JUEGO";
        SceneManager.LoadScene("MainMenu");
    }

    void HealthBarFiller()
    {
        HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount, (hp / hpMax), lerpSpeed);

    }

    void ColorChanger()
    {
        Color heathColor = Color.Lerp(Color.red, Color.green, (hp / hpMax));
        HealthBar.color = heathColor;
    }
}
