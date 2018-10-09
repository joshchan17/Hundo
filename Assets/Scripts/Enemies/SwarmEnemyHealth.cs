public class SwarmEnemyHealth : Damageable {

	protected override void OnDamaged(float damage) {
		CurHP -= damage;
	}

	protected override void OnDestroyed() {
		Destroy(gameObject);
	}
}
