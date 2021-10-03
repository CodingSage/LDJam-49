using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{

    public int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        Destructible destructible = collision.gameObject.GetComponent<Destructible>();
        if (destructible != null)
        {
            destructible.TakeDamage(damage);
        }
    }
}
