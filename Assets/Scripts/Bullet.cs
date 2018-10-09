using UnityEngine;

public class Bullet : Projectile {

	public float DamageValue;

	protected override void OnHit(Damageable damageable) {
        damageable.Damage(DamageValue);
    }

	protected override void OnCollide(Collision2D coll) {
		Destroy(gameObject);
	}
}
