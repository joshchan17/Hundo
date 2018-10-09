using UnityEngine;

public abstract class Gun : Item {

	public Transform SpawnPoint;
	public Projectile ProjectilePrefab; // Has events for on collide
	public ProjectileUpdate ProjectileUpdate;

    public AudioSource gunShot;

	protected abstract void Fire();

	public override void Use() {
		Fire();
		//FiringPattern.Fire(ProjectilePrefab, SpawnPoint, ProjectileUpdate);
        gunShot.Play();
	}
}
