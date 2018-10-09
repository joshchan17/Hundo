using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour {

	public string ID;
	public float Cooldown;
	public bool isReady { get; private set; }

	public Item() {
		isReady = true;
	}

	protected abstract void OnUse();

	protected virtual void OnCooldownEnd() {}

	public bool TryUse() {
		if (isReady) {
			StartCoroutine(Use());
			return true;
		} else {
			return false;
		}
	}

	private IEnumerator Use() {
		isReady = false;
		OnUse();
		yield return new WaitForSeconds(Cooldown);
		OnCooldownEnd();
		isReady = true;
	}
}
