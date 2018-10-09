using UnityEngine; 

public abstract class Movement : MonoBehaviour {

	protected abstract Vector3 OnMove(Vector2 direction);

	public void Move(Rigidbody2D rb, Vector2 direction) {
		rb.velocity = OnMove(direction);
	}
}
