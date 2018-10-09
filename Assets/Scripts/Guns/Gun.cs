using System.Collections;
using UnityEngine;

public abstract class Gun : Item {

	public Transform SpawnPoint;
	public Projectile ProjectilePrefab; // Has events for on collide
	public ProjectileUpdate ProjectileUpdate;
    public AudioSource FireSound;
	public float FireRate;
	private bool canFire;

	public Gun() {
		canFire = true;
	}

	protected abstract void Fire();

	public override void Use() {
		if (canFire) {
			StartCoroutine(fireAndWait());
		}
	}

	private IEnumerator fireAndWait() {
		canFire = false;
		Fire();
		FireSound.Play();
		yield return new WaitForSeconds(FireRate);
		canFire = true;
	}
}
