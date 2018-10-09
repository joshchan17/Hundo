using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Collider2D))]
public class TouchWeapon : MeleeWeapon {

	public float Damage;

	protected override void onAttack() {
		target.Damage(Damage);
	}

    /*
	public void OnTriggerStay2D(Collider2D col) {
        
	}
    */

    public void OnCollisionStay2D(Collision2D col) {
        //Debug.Log("Collided");
        Damageable damageable = col.gameObject.GetComponent<Damageable>();
        if (damageable != null) {
            Attack(damageable);
        }
    }
}