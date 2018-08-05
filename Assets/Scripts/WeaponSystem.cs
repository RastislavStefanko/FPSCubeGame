using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {

    private Animator animator;

    public bool weapon;
    public GameObject rifle;

    public FixedButton button;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
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
