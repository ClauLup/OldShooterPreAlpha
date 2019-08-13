using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    // Use this for initialization
    void Start()
    {
        //dmg = player.GetComponent<Controller>().currentWeapon.getDmg
        Destroy(this, 3.0f);
    }

    public void SetDamage(int newDmg)
    {
        damage = newDmg;
    }

    public int GetDamage()
    {
        return damage;
    }

    private void OnCollisionEnter(Collision col)
    {
        Destroy(this.gameObject);
    }
}
