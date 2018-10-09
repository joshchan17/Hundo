using UnityEngine;

public class RotateFromMouse : MonoBehaviour {

	public Camera Camera;
	private Vector3 mouseVec;
	private float angle;

	private void Update() {
		mouseVec = Input.mousePosition - Camera.WorldToScreenPoint(transform.position);
		angle = Mathf.Atan2(mouseVec.y, mouseVec.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
