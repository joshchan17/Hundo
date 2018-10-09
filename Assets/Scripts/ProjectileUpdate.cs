using UnityEngine;

public abstract class ProjectileUpdate : ScriptableObject {

	public abstract void OnFixedUpdate(Projectile projectile);

	public abstract ProjectileUpdate Clone();
}
