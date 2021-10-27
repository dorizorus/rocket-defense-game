using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    public int HP;

    public void Damage(int amount)
    {
        this.HP -= amount;
        if (this.HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(string.Format("{0} Died ! Sorry", gameObject.name));
    }
}
