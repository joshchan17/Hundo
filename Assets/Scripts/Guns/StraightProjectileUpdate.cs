using UnityEngine;

[CreateAssetMenu(fileName = "StraightProjectileUpdate", menuName = "ProjectileUpdate/Straight")]
public class StraightProjectileUpdate : ProjectileUpdate {

	public float Speed;

	public override void OnFixedUpdate(Projectile projectile) {
		projectile.rb.velocity = projectile.transform.right * Speed;
	}

	public override ProjectileUpdate Clone() {
		var retVal = CreateInstance<StraightProjectileUpdate>();
		retVal.Speed = Speed;
		return retVal;
	}
}
