using UnityEngine;

[CreateAssetMenu(fileName = "SingleFiringPattern", menuName = "FiringPatterns/Single")]
public class SingleFiringPattern : FiringPattern {
	public override void Fire(Projectile prefab, Transform spawnPoint, ProjectileUpdate projUpdate) {
		prefab.ProjectileUpdate = projUpdate;
		Instantiate<Projectile>(prefab, spawnPoint.position, spawnPoint.rotation);
	}
}
