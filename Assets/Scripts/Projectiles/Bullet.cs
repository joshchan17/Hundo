using UnityEngine;

public class Bullet : Projectile {

	public float Damage;

	private void OnCollisionEnter2D(Collision2D coll) {
		Destroy(gameObject);
	}
}
