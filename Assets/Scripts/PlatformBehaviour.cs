using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlatformBehaviour : MonoBehaviour
{
    public bool isRotating;
    public bool isShuffling;

    public Sprite rotate;
    public Sprite shuffle;

    public ParticleSystem destroyEvent;

    public SpriteRenderer bonusMalus1;
    public SpriteRenderer bonusMalus2;

    public GameObject whereToPlace;
    public GameObject whereToLand;
    public PlatformController.PlatformColors color;

    public float refttl = 5f;
    public float ttl = 5f;

    private void Update()
    {
        if (!PlatformController.hasStarted)
            return;

        if (ttl < 0)
        {
            StartCoroutine(disablePlatform());
        }

        else
            ttl -= Time.deltaTime;
    }

    private IEnumerator disablePlatform()
    {
        gameObject.GetComponentInChildren<ParticleSystemRenderer>().material = GetComponent<MeshRenderer>().material;
        destroyEvent.Play();
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }

    public void SetUp(
                      bool isRotating,
                      bool isShuffling,
                      Material mat,
                      PlatformController.PlatformColors color)
    {
        this.isRotating = isRotating;
        this.isShuffling = isShuffling;
        GetComponent<MeshRenderer>().material = mat;
        this.color = color;

        if (isRotating)
        {
            bonusMalus1.sprite = rotate;
            bonusMalus1.gameObject.SetActive(true);
        }
        if (isShuffling)
        {
            bonusMalus2.sprite = shuffle;
            bonusMalus2.gameObject.SetActive(true);
        }
    }
}
