using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{

    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 5.0f;
    public float jumpSpeed = 20.0f;

    float verticalRotation = 0;
    public float upDownRange = 60.0f;

    float verticalVelocity = 0;

    public GameObject[] weaponList;
    public GameObject currentWeapon;
    int damage;

    CharacterController characterController;
    Shooting shooting;

    // Use this for initialization
    void Start()
    {
        Screen.lockCursor = true;
        characterController = GetComponent<CharacterController>();
        shooting = GetComponent<Shooting>();
        currentWeapon = weaponList[2];

        Init();
    }
    void Init()
    {
        SetDamage(currentWeapon.GetComponent<Weapon>().getDmg());
    }

    public void SetDamage(int newDmg)
    {
        shooting.SetDamage(newDmg);
        Debug.Log("Damage is now " + newDmg);
    }

    public int GetDamage()
    {
        return damage;
    }

    void WeaponSelect(int key)
    {
        if (currentWeapon.name == weaponList[key - 1].name)
        {
            print("Cannot change to same weapon");
            return;
        }
        switch (key)
        {
            case 3:
                currentWeapon = weaponList[key - 1];
                print("Standard Weapon");
                break;
            case 2:
                currentWeapon = weaponList[key - 1];
                print("Pistol");
                break;
            case 1:
                currentWeapon = weaponList[key - 1];
                print("Knife");
                break;
        }

        SetDamage(currentWeapon.GetComponent<Weapon>().getDmg());
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation

        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);


        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);


        // Movement

        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded && Input.GetButton("Jump"))
        {
            verticalVelocity = jumpSpeed;
        }

        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        speed = transform.rotation * speed;


        characterController.Move(speed * Time.deltaTime);

        // Weapon Selection
        for (int i = 0; i <= 3; ++i)
        {
            if (Input.GetKeyDown("" + i))
            {
                WeaponSelect(i);
            }
        }
    }
}
