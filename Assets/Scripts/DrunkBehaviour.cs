using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkBehaviour : MonoBehaviour
{
    public float drunkDirectionRandomizer = 2f;
    public int randomizeChancePercent = 50;

    public Vector3 GetNoisyMovement()
    {
        int chance = Random.Range(0, 101);
        if (chance >= randomizeChancePercent) 
            return Vector3.zero;

        float dir = Random.Range(0, 11) / 10f;
        Vector3 noisyMovement = new Vector3(dir, 0, dir);
        return noisyMovement;
    }
}
