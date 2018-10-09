using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Damageable {

    //HP = float
    public bool isInvincible;  //Buffer for when player is hit
    public int numOfHearts;
    public int maxNumHearts;

    public AudioSource audioSource;
    public AudioClip hurtSound;
    private BoxCollider2D myCollider;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    private void Start() {
        audioSource = gameObject.GetComponent<AudioSource>();
        isInvincible = false;
    }

    protected override void OnDamaged(float damage) {
        //Debug.Log("Player hit");
        if (!isInvincible) {
            audioSource.PlayOneShot(hurtSound);
            isInvincible = true;
            HP -= damage;                      
        }		       
	}

	protected override void OnDestroyed() {
        StartCoroutine(DisplayHealth()); //Waits until all hearts are gone
        if (this.gameObject.gameObject.tag.Equals("Player")) {            
            this.gameObject.SetActive(false);
        }
        else {
            Destroy(this.gameObject);
        }
	}

    public void Update() {               
        if (isInvincible) {
            StartCoroutine(AttackedBuffer());            
        }
        StartCoroutine(DisplayHealth());
    }

    private IEnumerator DisplayHealth() {
        numOfHearts = (int)HP;
        for (int i = 0; i < hearts.Length; i++) {
            
            if (HP < 1.0f) {
                hearts[i].sprite = emptyHeart;
            } else if (i < numOfHearts) {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }                       

            if (i < maxNumHearts) {
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            }
        }
        yield return null;
    }                    

    private IEnumerator AttackedBuffer() {
        //Debug.Log("Attacked Buffer");      
        //Debug.Log("isInvincible = " + isInvincible);
        yield return new WaitForSeconds(1);    //Invincible for 1 sec
        isInvincible = false;
        yield return null;
    }
}

