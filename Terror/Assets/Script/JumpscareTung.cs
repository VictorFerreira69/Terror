using UnityEngine;
using UnityEngine.UI;
public class JumpscareSlappy : MonoBehaviour,IInteractable
{
    [Header("Câmeras")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera jumpscareCamera;

    [Header("Animatronic e Som")]
    [SerializeField] private GameObject animatronicModel;
    [SerializeField] private Animator jumpscareAnimator;
    [SerializeField] private string animationTrigger = "StartJumpscare";
    [SerializeField] private AudioSource jumpscareSound;

    [Header("Duraçao da animaçao")]
    [SerializeField] private float displayTime = 2f;

    [Header("Fundo preto")]
    [SerializeField] GameObject fundoPreto;

    private bool triggered = false;

  public void Trigger()
{
    if (triggered) return;
    triggered = true;

    if (mainCamera != null) mainCamera.gameObject.SetActive(false);
    if (jumpscareCamera != null) jumpscareCamera.gameObject.SetActive(true);

    if (animatronicModel != null)
        animatronicModel.SetActive(true);

        if(fundoPreto != null)
        fundoPreto.SetActive(true);

    if (jumpscareAnimator != null)
        jumpscareAnimator.SetTrigger(animationTrigger);

    if (jumpscareSound != null)
        jumpscareSound.Play();

    Invoke(nameof(EndJumpscare), displayTime);
}

private void EndJumpscare()
{
    if (animatronicModel != null)
        animatronicModel.SetActive(false);

           if(fundoPreto != null)
        fundoPreto.SetActive(false);

    if (mainCamera != null) mainCamera.gameObject.SetActive(true);
    if (jumpscareCamera != null) jumpscareCamera.gameObject.SetActive(false);
}
}
