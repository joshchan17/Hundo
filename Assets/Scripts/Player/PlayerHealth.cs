using System.Collections;
using UnityEngine;

public class PlayerHealth : Damageable {

	public float AttackBufferTime;
    public bool isInvincible;
    public AudioClip HurtSound;
	public HeartUI HeartUI;
    private AudioSource audioSource;

	public PlayerHealth() {
		isInvincible = false;
	}

    private void Awake() {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    protected override void OnDamaged(float damage) {
        if (!isInvincible) {
            audioSource.PlayOneShot(HurtSound);
            CurHP -= damage;                      
			HeartUI.UpdateHearts();
			StartCoroutine(setInvincibleAndWait());
		} else {
			Debug.Log("I'm invincible!");
		}
	}

	protected override void OnDestroyed() {
		Destroy(gameObject);
	}

    private IEnumerator setInvincibleAndWait() {
		isInvincible = true;
        yield return new WaitForSeconds(AttackBufferTime);
		isInvincible = false;
    }
}

