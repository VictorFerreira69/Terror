using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class ConfigurarLuz : MonoBehaviour
{
    public static ConfigurarLuz instancia;

    private List<ILuz> luzes = new List<ILuz>();

    [Header("Quando a luz desliga vai ativar isso")]
    [SerializeField] private Dialogo dialogo;
    [SerializeField] private GameObject[] fusiveisParaAtivar;

    [Header("Áudio")]
    [SerializeField] private AudioSource audioSourceAtual;
    [SerializeField] private AudioClip musicaPosLuz;

    private void Awake()
    {
        instancia = this;

        foreach (GameObject fusivel in fusiveisParaAtivar)
        {
            fusivel.SetActive(false);
        }
    }

    public void Registrar(ILuz luz)
    {
        if (!luzes.Contains(luz))
            luzes.Add(luz);
    }

    public void DesligarTudo()
    {
        foreach (ILuz luz in luzes)
        {
            luz.Desligar();
        }

        if (ControladorAnimatronic.instancia != null)
        {
            ControladorAnimatronic.instancia.AtivarTodos();
        }

        if (dialogo != null)
        {
            dialogo.IniciarDialogoPosLuz();
        }

        foreach (GameObject fusivel in fusiveisParaAtivar)
        {
            fusivel.SetActive(true);
        }

        
        if (audioSourceAtual != null && musicaPosLuz != null)
        {
            audioSourceAtual.Stop();
            audioSourceAtual.clip = musicaPosLuz;
            audioSourceAtual.Play();
        }
    }

    public void LigarTudo()
    {
        foreach (ILuz luz in luzes)
        {
            luz.Ligar();
        }

        SceneManager.LoadScene("Fim");
    }
}