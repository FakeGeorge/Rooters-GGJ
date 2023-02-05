using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public Text healthText;

    public float health, maxHealth;
    float lerpSpeed;

    [SerializeField] Settings settings;
    [SerializeField] AudioClip Da�o;

    private void Start()
    {
        health = maxHealth;

        settings = GameObject.Find("Settings").GetComponent<Settings>();

    }

    private void Update()
    {
        HealthBarFiller();
        ColorChanger();

        healthText.text = health + "%";

        if (health > maxHealth) health = maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        if (Input.GetKey(KeyCode.F)) TakeDamage(5);
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
            settings.PlaySFX(Da�o);
            health -= damageValue;

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
