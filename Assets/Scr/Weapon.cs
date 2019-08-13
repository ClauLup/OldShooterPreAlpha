using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public int dmg;
	
	// Update is called once per frame
	public int getDmg()
    {
        return dmg;
    }
}
