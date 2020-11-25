using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    public float hidingTime = 1f;

    void OnEnable()
    {
        Invoke("hideBullet", hidingTime);
    }

    void hideBullet()
    {

        gameObject.SetActive(false);

    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
