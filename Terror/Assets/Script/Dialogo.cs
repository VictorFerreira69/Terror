using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using System.Collections;
public class Dialogo : MonoBehaviour
{
    [Header(" Animação")]
    [SerializeField] private Animator introAnimator;
    [SerializeField] private string animationName = "Comeco";

    [Header("Diálogo")]
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private string[] playerLines;

      [Header("Player")]
     [SerializeField] private FirstPersonController move;

    private bool isDialogActive = false;
    private int currentLine = 0;

    void Start()
    {
       dialogText.gameObject.SetActive(false);
        StartCoroutine(EsperarAnimacaoAcabar());
    }

    IEnumerator EsperarAnimacaoAcabar()
    {
        
        yield return new WaitUntil(() =>
        !introAnimator.GetCurrentAnimatorStateInfo(0).IsName(animationName) ||
        introAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

        IniciarDialogo();
    }

    void IniciarDialogo()
    {
        isDialogActive = true;
        dialogText.gameObject.SetActive(true);
        move.playerCanMove = false;
        currentLine = 0;
        dialogText.text = playerLines[currentLine];
    }

    void Update()
    {
        if (isDialogActive && Input.GetButtonDown("Fire1"))
        {
            currentLine++;

            if (currentLine >= playerLines.Length)
            {
                FinalizarDialogo();
            }
            else
            {
                dialogText.text = playerLines[currentLine];
            }
        }
    }

    void FinalizarDialogo()
    {
        dialogText.gameObject.SetActive(false);
        isDialogActive = false;
         move.playerCanMove = true;
    }
}