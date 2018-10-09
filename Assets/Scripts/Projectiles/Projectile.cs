using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(BoxCollider2D))]
public abstract class Projectile : MonoBehaviour {

	public ProjectileUpdate ProjectileUpdate;
	public Rigidbody2D rb { get; set; }

	private void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	protected abstract void OnHit(Damageable damageable);

	protected abstract void OnCollide(Collision2D coll);

	private void FixedUpdate() {
		if (ProjectileUpdate != null) {
			ProjectileUpdate.OnFixedUpdate(this);
		}
	}

	private void OnCollisionEnter2D(Collision2D coll) {
		Damageable damageable = coll.gameObject.GetComponent<Damageable>();
		if (damageable != null) {
			OnHit(damageable);
		}

		OnCollide(coll);
	}
}
