using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    public bool isGrounded;

    public AudioSource hop;
    public AudioSource aoutch;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    public void jumpTo(Transform transformToGo)
    {
        if (!isGrounded)
            return;
        StartCoroutine(startJumpTo(transformToGo));
    }

    private IEnumerator startJumpTo(Transform transformToGo)
    {
        Animator characterAnim = GetComponentInChildren<Animator>();
        characterAnim.SetTrigger("jump");
        if (Random.Range(0, 4) == 1)
            hop.Play();
        yield return new WaitForSeconds(0.05f);
        transform.DOMove(transformToGo.position, 0.5f);
    }

    public void stun()
    {
        Animator characterAnim = GetComponentInChildren<Animator>();
        aoutch.Play();
        characterAnim.SetTrigger("stun");
    }
}
