using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script should have the turret face/track to enemy position. Will fire
 at enemy until that enemy is dead. Make sure to make animator references , animations
 are already set up for the turret (they should be working).
 
 For now, have the turret track the player to test out functionality.*/


public class TurretController : MonoBehaviour {

    public Gun TurretGun;
    public Transform BulletSpawn;
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
            targetVec = target.transform.position - BulletSpawn.position;
            targetAngle = Mathf.Atan2(targetVec.y, targetVec.x) * Mathf.Rad2Deg;
            BulletSpawn.rotation = Quaternion.Euler(0.0f, 0.0f, targetAngle);
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
