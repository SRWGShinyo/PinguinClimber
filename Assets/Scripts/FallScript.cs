using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    public AudioSource fall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Incarnate")
        {
            fall.Play();
            PlatformController.platformContr.GameOver("TOO LONG", "You waited too much !");
        }

    }
}
