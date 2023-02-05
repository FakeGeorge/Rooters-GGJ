using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public SpriteRenderer PlayerFuturista, PlayerActual, PlayerEdadMedia, PlayerPrehistoria;
    //public Animator animatorFuturista, animatorActual, animatorMedieval, animatorPrehistoria;
    //public Animator animatorFuturista, animatorActual, animatorMedieval, animatorPrehistoria;

    public static float dmgAdded;

    [Header("Futurista")]
    public bool Futurista = true;
    public Sprite futuristaSprite;
    public RuntimeAnimatorController futuristaAnimator;
    public Sprite pistolaLaserSprite;

    public float damageFuturo = 50 / 2f + dmgAdded;
    [Header("Actual")]
    public bool Actual = false;
    public Sprite actualSprite;
    public RuntimeAnimatorController actualAnimator;
    public Sprite pistolaSprite;

    public float damageActual = 50 / 3f + dmgAdded;
    [Header("Medieval")]
    public bool Medieval = false;
    public Sprite medievalSprite;
    public RuntimeAnimatorController medievalAnimator;
    public Sprite arcoSprite;

    public float damageMedieval = 50 / 4f + dmgAdded;
    [Header("Prehistoria")]
    public bool Prehistoria = false;
    public Sprite prehistoriaSprite;
    public RuntimeAnimatorController prehistoriaAnimator;
    public Sprite lanzaSprite;

    public float damagePrehistoria = 50 / 5f + dmgAdded;

    [Header("Player")]
    public SpriteRenderer playerSprite;
    public Animator playerAnimator;
    public SpriteRenderer armaDistanciaSprite, armaMeleeRend;

    public float speed = 5;
    Vector2 movimiento;

    bool mouseLeft, mouseRigth, canShoot;
    public float timeBetweenShots = 0.25f;
    float lastShot = 0;
    Vector3 mousePos, mouseVector;
    public Transform gunSprite, gunTip, armaMeleeSprite;
    int playerSortingOrder = 20;
    public GameObject bulletPrefab;
    CameraController Cam;

    private Rigidbody2D rb;

    [SerializeField] Settings settings;
    [SerializeField] AudioClip Futuro, Actualidad, Medievo, Pasado;

    void Start()
    {
        Futurista = true;

        GetMouseInput();
        Cam = FindObjectOfType<CameraController>();

        rb = GetComponent<Rigidbody2D>();

        settings = GameObject.Find("Settings").GetComponent<Settings>();
    }

    private void FixedUpdate()
    {
        GetInput(); //capture wasd and mouse
        Movement(); //move the player
        Animation(); //rotate the gun
        Shooting(); //handle shooting
                    //Melee();
    }
    private void Update()
    {
        if (Futurista == true)
        {
            playerSprite.sprite = futuristaSprite;
            playerAnimator.runtimeAnimatorController = futuristaAnimator;
            armaDistanciaSprite.sprite = pistolaLaserSprite;
        }
        if (Actual == true)
        {
            playerSprite.sprite = actualSprite;
            playerAnimator.runtimeAnimatorController = actualAnimator;
            armaDistanciaSprite.sprite = pistolaSprite;
        }
        if (Medieval == true)
        {
            playerSprite.sprite = medievalSprite;
            playerAnimator.runtimeAnimatorController = medievalAnimator;
            armaDistanciaSprite.sprite = arcoSprite;
            armaDistanciaSprite.flipX = true;
        }
        if (Prehistoria == true)
        {
            playerSprite.sprite = prehistoriaSprite;
            playerAnimator.runtimeAnimatorController = prehistoriaAnimator;
            armaDistanciaSprite.sprite = lanzaSprite;
            armaDistanciaSprite.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerAnimator.SetBool("moveIzq", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnimator.SetBool("moveIzq", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            playerAnimator.SetBool("moveDer", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnimator.SetBool("moveDer", false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnimator.SetBool("moveUp", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnimator.SetBool("moveUp", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnimator.SetBool("moveDown", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnimator.SetBool("moveDown", false);
        }
    }

    void GetInput()
    {
        movimiento.x = Input.GetAxis("Horizontal");
        movimiento.y = Input.GetAxis("Vertical"); //capture wasd and arrow controls
        movimiento.Normalize();

        GetMouseInput();
    }

    void GetMouseInput()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //position of cursor in world
        mousePos.z = transform.position.z; //keep the z position consistant, since we're in 2d
        mouseVector = (mousePos - transform.position).normalized; //normalized vector from player pointing to cursor
        mouseLeft = Input.GetMouseButton(0); //check left mouse button
        mouseRigth = Input.GetMouseButton(1);
    }

    void Movement()
    {
        rb.MovePosition(rb.position + movimiento * speed * Time.fixedDeltaTime);
    }

    void Animation()
    {
        float gunAngle = -1 * Mathf.Atan2(mouseVector.y, mouseVector.x) * Mathf.Rad2Deg; //find angle in degrees from player to cursor
        gunSprite.rotation = Quaternion.AngleAxis(gunAngle, Vector3.back); //rotate gun sprite around that angle
        armaDistanciaSprite.sortingOrder = playerSortingOrder - 1; //put the gun sprite bellow the player sprite

        armaMeleeSprite.rotation = Quaternion.AngleAxis(gunAngle, Vector3.back);
        armaMeleeRend.sortingOrder = playerSortingOrder - 1;

        if (gunAngle > 0)
        { //put the gun on top of player if it's at the correct angle
            armaDistanciaSprite.sortingOrder = playerSortingOrder + 1;
            armaMeleeRend.sortingOrder = playerSortingOrder + 1;
        }
    }

    void Shooting()
    {
        canShoot = (lastShot + timeBetweenShots < Time.time);
        if (mouseLeft && canShoot)
        { //shoot if the mouse button is held and its been enough time since last shot

            Vector3 spawnPos = gunTip.position; //position of the tip of the gun, a transform that is a child of rotating gun
            Quaternion spawnRot = Quaternion.identity; //no rotation, bullets here are round

            if (Futurista == true)
            {
                settings.PlaySFX(Futuro);
            }

            if (Actual == true)
            {
                settings.PlaySFX(Actualidad);
            }

            if (Medieval == true)
            {
                settings.PlaySFX(Medievo);
            }

            if (Prehistoria == true)
            {
                settings.PlaySFX(Pasado);
            }

            Bullet bul = Instantiate(bulletPrefab, spawnPos, spawnRot).GetComponent<Bullet>();//spawn bullet and capture it's script

            //SONIDO DISPARO
            //SWITCH CASE SONIDO EN FUNCION DEL ARMA

            bul.Setup(mouseVector); //give the bullet a direction to fly
            lastShot = Time.time; //used to check next time this is called
            Cam.Shake((transform.position - gunTip.position).normalized, 1.5f, 0.05f); //call camera shake for recoil
        }
    }
}