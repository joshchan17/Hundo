using UnityEngine;

public class EnemyHealth : Damageable {

	protected override void OnDamaged(float damage) {
		HP -= damage;
	}

	protected override void OnDestroyed() {
		Destroy(gameObject);
	}
}
