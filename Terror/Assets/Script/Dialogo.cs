using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogo : MonoBehaviour
{
    [Header("Começo")]
    [TextArea] [SerializeField] string dialogoIntro; 
  [SerializeField] float tempoPorLinha = 5f;

    [Header("Depois da  luz acabar")]
    [TextArea]  [SerializeField] string dialogoPosLuz;
    [SerializeField] TextMeshProUGUI dialogText;

    private bool dialogoPosLuzAtivo = false;

    [Header("Player")]
    [SerializeField] FirstPersonController move;

    private bool esperandoInput = false;

    void Start()
    {
        if (dialogText != null)
            dialogText.gameObject.SetActive(false);

        if (move == null)
            move = FindObjectOfType<FirstPersonController>();

        StartCoroutine(FluxoInicial());
    }

    IEnumerator FluxoInicial()
    {
        
        if (move != null)
            move.playerCanMove = false;

        
        if (dialogText != null)
        {
            dialogText.text = dialogoIntro;
            dialogText.gameObject.SetActive(true);
        }

        esperandoInput = true;

        
        while (esperandoInput)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                esperandoInput = false;
            }
            yield return null;
        }

        
        if (dialogText != null)
            dialogText.gameObject.SetActive(false);

        
        if (move != null)
            move.playerCanMove = true;
    }

    public void IniciarDialogoPosLuz()
    {
        if (!dialogoPosLuzAtivo)
        {
            dialogoPosLuzAtivo = true;
            StartCoroutine(DialogoDepoisDaLuz());
        }
    }

    IEnumerator DialogoDepoisDaLuz()
    {
        if (dialogText != null)
        {
            dialogText.text = dialogoPosLuz;
            dialogText.gameObject.SetActive(true);
            yield return new WaitForSeconds(tempoPorLinha);
            dialogText.gameObject.SetActive(false);
        }
    }
}