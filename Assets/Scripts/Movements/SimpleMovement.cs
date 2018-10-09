using UnityEngine;

public class SimpleMovement : Movement {

	public float Speed;

	protected override Vector3 OnMove(Vector2 direction) {
		return direction * Speed;
	}
}
