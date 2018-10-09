using UnityEngine;

public class Gun : Item {

	public Transform SpawnPoint;
	public Projectile ProjectilePrefab; // Has events for on collide
	public FiringPattern FiringPattern;
	public ProjectileUpdate ProjectileUpdate;

    public AudioSource gunShot;

	public override void Use() {
		FiringPattern.Fire(ProjectilePrefab, SpawnPoint, ProjectileUpdate);
        gunShot.Play();
	}
}
