using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Follow : MonoBehaviour {

	public float Speed;
	public Transform Target;
	private Rigidbody2D rb;
	private Vector2 distance;

	private void Awake() {
		rb = GetComponent<Rigidbody2D>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void FixedUpdate() {
		distance = Target.transform.position - transform.position;
		distance.x = Mathf.Clamp(distance.x, -1.0f, 1.0f);
		distance.y = Mathf.Clamp(distance.y, -1.0f, 1.0f);
		rb.velocity = distance * Speed;
	}
}
