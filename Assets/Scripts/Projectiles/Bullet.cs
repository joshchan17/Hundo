using UnityEngine;

public class Bullet : Projectile {

	public float Damage;

	private void OnCollisionEnter2D(Collision2D coll) {
		Damageable damageable;
		if (coll.gameObject.tag == "Enemy"
			&& (damageable = coll.gameObject.GetComponent<Damageable>()) != null)
		{
			damageable.Damage(Damage);
		}

		Destroy(gameObject);
	}
}
