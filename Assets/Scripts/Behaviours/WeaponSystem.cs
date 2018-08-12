using UnityEngine;

public class WeaponSystem : MonoBehaviour {

    private Animator animator;

    [SerializeField] private bool weapon;
    [SerializeField] private GameObject rifle;
    [SerializeField] private FixedButton button;

	void Start () {
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        weapon = button.Pressed;
        animator.SetBool("Weapon", weapon);

        if (weapon)
        {
            rifle.SetActive(true);
        }
        else
        {
            rifle.SetActive(false);
        }
    }
}
