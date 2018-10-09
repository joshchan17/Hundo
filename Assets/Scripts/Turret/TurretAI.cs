using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class TurretAI : MonoBehaviour {

    public Gun TurretGun;
    private List<GameObject> enemies;
    private Vector2 targetVec;
    private float targetAngle;
	private bool isSearchingAndDestroying;

    public TurretAI() {
        enemies = new List<GameObject>();
		isSearchingAndDestroying = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
			trackEnemy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
			untrackEnemy(collision.gameObject);
        }
    }

	private void trackEnemy(GameObject enemy) {
		enemies.Add(enemy);
		if (!isSearchingAndDestroying) {
			isSearchingAndDestroying = true;
			StartCoroutine(searchAndDestroy(enemy));
		}
	}

	private void untrackEnemy(GameObject enemy) {
		enemies.RemoveAll(x => x == enemy);
	}

	// Change later
	private IEnumerator searchAndDestroy(GameObject enemy) {
		if (enemy != null) { // Aim, shoot, wait for gun cooldown, and try again
			targetVec = enemy.transform.position - TurretGun.transform.position;
            targetAngle = Mathf.Atan2(targetVec.y, targetVec.x) * Mathf.Rad2Deg;
            TurretGun.transform.rotation = Quaternion.Euler(0.0f, 0.0f, targetAngle);
            TurretGun.Use();
			yield return new WaitForSeconds(TurretGun.FireRate);
			StartCoroutine(searchAndDestroy(enemy));
		} else { 
			enemy = enemies.Take(1).FirstOrDefault();

			if (enemy == null) {
				isSearchingAndDestroying = false;
				yield break;
			} else {
				StartCoroutine(searchAndDestroy(enemy));
			}
		}
	}
}
