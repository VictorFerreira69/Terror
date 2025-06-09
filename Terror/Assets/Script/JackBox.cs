using UnityEngine;

public class JackBox : MonoBehaviour,IInteractable
{
    [Header("Animação")]
    private Animator animator;

    [Header("Som")]
    private AudioSource audioSource;

    [Header("Ativar a animação")]
    private bool isActivated = false;

    [Header("Audio clip")]
    [SerializeField] AudioClip clip;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Trigger()
    {
        if (isActivated) return;

        isActivated = true;
        animator.SetTrigger("PopOut");
        audioSource.Play();

        float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
        Invoke(nameof(StopSound), animLength);
    }
    public void AtivarSom()
    {
        audioSource.PlayOneShot(clip);
    }

    private void StopSound()
    {
        audioSource.Stop();
    }
}