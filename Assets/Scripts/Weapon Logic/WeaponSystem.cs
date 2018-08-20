using UnityEngine;

public class WeaponSystem : MonoBehaviour {

    private Animator animator;
    private bool weapon;
    private bool aim;
    private float cooldown;
    private ThirdPersonInput playerInput;
    private Ray ray;

    [SerializeField] private ParticleSystem shootingParticle;
    [SerializeField] private GameObject rifle;

    //public PlayerAim playerAim;
    public Transform fireFrom;
    public float shootCooldown;
    
	void Start () {
        playerInput = GetComponent<ThirdPersonInput>();
        animator = GetComponent<Animator>();

        cooldown = shootCooldown;
	}
	
	void Update () {
        // ray from camera
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        /* TO DO
        playerAim.SetRotation(Camera.main.transform.position.y/5, Camera.main.transform.position.x);

        if (aim)
        {
            animator.SetFloat("AimAngleZ", playerAim.GetAngleX());
            animator.SetFloat("AimAngleX", playerAim.GetAngleZ());
        }*/

        animator.SetBool("Aim", aim);
        animator.SetBool("Weapon", weapon);
        animator.SetBool("Fire", playerInput.FireButton.Pressed);

        cooldown -= Time.deltaTime;
        if (playerInput.FireButton.Pressed && weapon)
        {
            aim = true;

            if(cooldown <= 0)
            {
                cooldown = shootCooldown;
                
                // ray cast for shooting
                RaycastHit hitInfo;
                if(Physics.Raycast(ray, out hitInfo))
                {
                    var other = hitInfo.collider.GetComponent<Shootable>();

                    // if hit shootable apply force
                    if(other != null)
                    {
                        other.GetComponent<Rigidbody>().AddForceAtPosition((hitInfo.point - shootingParticle.transform.position).normalized * 500, hitInfo.point);
                    }

                    shootingParticle.transform.LookAt(hitInfo.point);
                }
                else
                {
                    shootingParticle.transform.LookAt(ray.origin + 100 * ray.direction);
                }

                // transform particles to the gun position
                shootingParticle.transform.position = fireFrom.position;
                
                shootingParticle.Play();
            }

        }
        else
        {
            aim = false;
        }

        EquipWeapon();
    }

    private void EquipWeapon()
    {
        if (playerInput.WeaponButton.Clicked)
        {
            weapon = true;
            rifle.SetActive(true);
        }
        else
        {
            weapon = false;
            rifle.SetActive(false);
        }
    }
}
