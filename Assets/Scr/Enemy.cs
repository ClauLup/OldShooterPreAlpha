using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int hp=20;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "bullet")
        {
            TakeDamage(col.gameObject.GetComponent<Bullet>().GetDamage());
        }
    }

    void TakeDamage(int dmg)
    {
        Debug.Log("Took " + dmg + " Damage");
        hp -= dmg;
        if (hp <= 0)
            Die();
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
