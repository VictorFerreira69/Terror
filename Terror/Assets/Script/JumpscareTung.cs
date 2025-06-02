using UnityEngine;
using UnityEngine.UI;
public class JumpscareTung : MonoBehaviour,IInteractable
{
    [Header("Animação e Som")]
    [SerializeField] private Animator jumpscareAnimator;
    [SerializeField] private string animationTrigger = "StartJumpscare";
    [SerializeField] private AudioSource jumpscareSom;

    [Header("Imagem de Jumpscare")]
    [SerializeField] private Image jumpscareImage;
    [SerializeField] private float displayTime = 2f;

    private bool triggered = false;

    public void Trigger()
    {
        if (triggered) return;
        triggered = true;

       
        if (jumpscareAnimator != null)
            jumpscareAnimator.SetTrigger(animationTrigger);
    }

   
    public void ShowJumpscareImage()
    {
        if (jumpscareImage != null)
            jumpscareImage.gameObject.SetActive(true);

        if (jumpscareSom != null)
            jumpscareSom.Play();

        Invoke(nameof(HideJumpscareImage), displayTime);
    }

    private void HideJumpscareImage()
    {
        if (jumpscareImage != null)
            jumpscareImage.gameObject.SetActive(false);
    }
}