using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using System.Collections;
public class Dialogo : MonoBehaviour
{
    [Header("Animação do player no inicio")]
    [SerializeField] private Animator introAnimator;
    [SerializeField] private string animationName = "Comeco";

    [Header("Diálogo Começo")]
    [SerializeField] private string[] dialogoIntro;

    [Header("Diálogo quando a luz se apagar")]
    [SerializeField] private string[] dialogoPosLuz;
    [SerializeField] private float tempoPorLinha = 6f;

    [Header("Player nao se mover")]
    [SerializeField] private FirstPersonController move;
    

    [Header("Text")]
    [SerializeField] private TMP_Text dialogText;

    private bool isDialogActive = false;
    private int currentLine = 0;
    private Coroutine dialogCoroutine;

    void Start()
    {
        dialogText.gameObject.SetActive(false);
        move.playerCanMove = true; 

        StartCoroutine(EsperarAnimacaoAcabar());
    }

    IEnumerator EsperarAnimacaoAcabar()
    {
        yield return new WaitUntil(() =>
            !introAnimator.GetCurrentAnimatorStateInfo(0).IsName(animationName) ||
            introAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 10f);

        IniciarDialogoIntro();
    }

    void IniciarDialogoIntro()
    {
        isDialogActive = true;
        move.playerCanMove = false; 
        currentLine = 0;
        dialogText.gameObject.SetActive(true);
        dialogText.text = dialogoIntro[currentLine];
    }

    void Update()
    {
        if (isDialogActive && Input.GetButtonDown("Fire1"))
        {
            currentLine++;

            if (currentLine >= dialogoIntro.Length)
            {
                FinalizarDialogoIntro();
            }
            else
            {
                dialogText.text = dialogoIntro[currentLine];
            }
        }
    }

    void FinalizarDialogoIntro()
    {
        dialogText.gameObject.SetActive(false);
        isDialogActive = false;
        move.playerCanMove = true; 
    }

    
    public void IniciarDialogoPosLuz()
    {
        if (dialogCoroutine != null)
            StopCoroutine(dialogCoroutine);

        dialogCoroutine = StartCoroutine(DialogoAutomaticoPosLuz());
    }

    private IEnumerator DialogoAutomaticoPosLuz()
    {
        dialogText.gameObject.SetActive(true);

        foreach (string linha in dialogoPosLuz)
        {
            dialogText.text = linha;
            yield return new WaitForSeconds(tempoPorLinha);
        }

        dialogText.gameObject.SetActive(false);
        dialogCoroutine = null;
    }
}