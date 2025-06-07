using UnityEngine;

public class JackBox : MonoBehaviour,IAtivar
{
    [Header("Animaçao")]
    private Animator animator;

    [Header("Som")]
    private AudioSource audioSource;

    [Header("Ativar a animaçao")]
    private bool isActivated = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Activate()
    {
        if (isActivated) return;

        isActivated = true;
        animator.SetTrigger("PopOut");
        audioSource.Play();

        
        float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
        Invoke(nameof(StopSound), animLength);
    }

    private void StopSound()
    {
        audioSource.Stop();
    }
}