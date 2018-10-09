using UnityEngine;

public abstract class FiringPattern : ScriptableObject {
	public abstract void Fire(Projectile prefab, Transform spawnPoint, ProjectileUpdate projUpdate);
}
