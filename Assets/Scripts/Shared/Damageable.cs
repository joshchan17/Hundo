using UnityEngine;

public abstract class Damageable : MonoBehaviour {

	public enum Status { ACTIVE, DESTROYED };

	public float HP;
	public Status status;

	protected abstract void OnDamaged(float damage);

	protected abstract void OnDestroyed();

	public void Damage(float damage) {
		if (status != Status.DESTROYED) {
			OnDamaged(damage);
			
			if (HP <= 0.0f) {
				OnDestroyed();
				status = Status.DESTROYED;
			}
		}
	}
}
