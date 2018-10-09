using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class TurretController : MonoBehaviour {

    public Gun TurretGun;
    private List<GameObject> enemies;
    private GameObject target;
    private Vector2 targetVec;
    private float targetAngle;

    public TurretController()
    {
        enemies = new List<GameObject>();
    }

    void FixedUpdate()
    {
        for (int i = 0, found = 0; i < enemies.Count && found == 0; i++)
        {
            if (enemies[i] != null)
            {
                found = 1;
                target = enemies[i];
            }
        }
        if (target != null)
        {
			
            targetVec = target.transform.position - TurretGun.transform.position;
            targetAngle = Mathf.Atan2(targetVec.y, targetVec.x) * Mathf.Rad2Deg;
            TurretGun.transform.rotation = Quaternion.Euler(0.0f, 0.0f, targetAngle);
            TurretGun.Use();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy added to turret list.");
            enemies.Add(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy removed from list.");
            enemies.RemoveAll(x => x == collision.gameObject);
        }
    }
}
