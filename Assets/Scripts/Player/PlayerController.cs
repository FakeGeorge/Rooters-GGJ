using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	float speed = 5;
	Vector2 movimiento;

	public GameObject armaDistancia, armaMelee;

	public Animator animator;

	bool mouseLeft, mouseRigth, canShoot;
	float lastShot = 0, timeBetweenShots = 0.25f;
	Vector3 mousePos, mouseVector;
	public Transform gunSprite, gunTip, armaMeleeSprite;
	public SpriteRenderer gunRend, armaMeleeRend;
	int playerSortingOrder = 20;
	public GameObject bulletPrefab;
	CameraController Cam;

	private Rigidbody2D rb;

	void Start () 
	{
		GetMouseInput();
		Cam = FindObjectOfType<CameraController>();

		rb = GetComponent<Rigidbody2D>();

		armaDistancia.SetActive(false);
		armaMelee.SetActive(false);
	}

    private void FixedUpdate()
    {
		GetInput(); //capture wasd and mouse
		Movement(); //move the player
		Animation(); //rotate the gun
		Shooting(); //handle shooting
		Melee();


	}
    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.A))
		{
			animator.SetBool("moveIzq", true);
		}
		else if (Input.GetKeyUp(KeyCode.A))
		{
			animator.SetBool("moveIzq", false);
		}

        if (Input.GetKeyDown(KeyCode.D))
        {
			animator.SetBool("moveDer", true);
		}
        else if (Input.GetKeyUp(KeyCode.D))
        {
			animator.SetBool("moveDer", false);
		}
	}

    void GetInput()
	{
		movimiento.x = Input.GetAxis("Horizontal"); 
		movimiento.y = Input.GetAxis("Vertical"); //capture wasd and arrow controls
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
		gunRend.sortingOrder = playerSortingOrder - 1; //put the gun sprite bellow the player sprite

		armaMeleeSprite.rotation = Quaternion.AngleAxis(gunAngle, Vector3.back);
		armaMeleeRend.sortingOrder = playerSortingOrder - 1;

		if (gunAngle > 0)
		{ //put the gun on top of player if it's at the correct angle
			gunRend.sortingOrder = playerSortingOrder + 1;
			armaMeleeRend.sortingOrder = playerSortingOrder + 1;
		} 
	}

	void Shooting()
	{
		canShoot = (lastShot + timeBetweenShots < Time.time);
		if (mouseLeft && canShoot)
		{ //shoot if the mouse button is held and its been enough time since last shot
			
			armaDistancia.SetActive(true);
			armaMelee.SetActive(false);

			Vector3 spawnPos = gunTip.position; //position of the tip of the gun, a transform that is a child of rotating gun
			Quaternion spawnRot = Quaternion.identity; //no rotation, bullets here are round
			Bullet bul = Instantiate(bulletPrefab, spawnPos, spawnRot).GetComponent<Bullet>();//spawn bullet and capture it's script
			bul.Setup(mouseVector); //give the bullet a direction to fly
			lastShot = Time.time; //used to check next time this is called
			Cam.Shake((transform.position - gunTip.position).normalized, 1.5f, 0.05f); //call camera shake for recoil
		}
	}
	void Melee()
    {
        if (mouseRigth)
        {
			armaDistancia.SetActive(false);
			armaMelee.SetActive(true);
		}
	}
}