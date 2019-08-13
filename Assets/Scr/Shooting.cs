using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{

    public GameObject bullet_prefab;
    int damage;
    float bulletImpulse = 20f;
    Controller playerController;

    private void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<Controller>();
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    // Use this for initialization
    void Fire()
    {
        Camera cam = Camera.main;
        GameObject theBullet = (GameObject)Instantiate(bullet_prefab, cam.transform.position + cam.transform.forward, cam.transform.rotation);
        theBullet.GetComponent<Bullet>().SetDamage(damage);
        theBullet.GetComponent<Rigidbody>().AddForce(cam.transform.forward * bulletImpulse, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
}
