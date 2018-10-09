public class SwarmEnemyHealth : Damageable {

	protected override void OnDamaged(float damage) {
		HP -= damage;
	}

	protected override void OnDestroyed() {
		Destroy(gameObject);
	}
}
