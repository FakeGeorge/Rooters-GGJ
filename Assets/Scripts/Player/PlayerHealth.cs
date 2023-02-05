using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public Text healthText;

    public float health, maxHealth;
    float lerpSpeed;

    [SerializeField] Settings settings;
    [SerializeField] AudioClip Daño;

    private void Start()
    {
        health = maxHealth;

        settings = GameObject.Find("Settings").GetComponent<Settings>();

        //healthBar.fillAmount.
    }

    private void Update()
    {
        HealthBarFiller();
        ColorChanger();

        healthText.text = health.ToString("F0") + "%";

        if (health > maxHealth) health = maxHealth;

        lerpSpeed = 3f * Time.deltaTime;
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxHealth), lerpSpeed);

    }

    void ColorChanger()
    {
        Color heathColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthBar.color = heathColor;
    }

    public void TakeDamage(float damageValue)
    {
        if (health > 0)
        {
            settings.PlaySFX(Daño);
            health -= damageValue;
        }
        if (health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void Heal(float healValue)
    {
        if (health < maxHealth)
        {
            health += healValue;
        }
    }
}
