using UnityEngine;

public class Cozinha : MonoBehaviour
{
    [Header("Marcelline")]
    [SerializeField] private GameObject marcelline;

    [Header("Som")]
    [SerializeField] private AudioSource somAssustador;

    [Header(" Tempo que vai durar")]
    [SerializeField] private float tempoVisivel = 5f;

   public  bool jaAtivado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !jaAtivado)
        {
            jaAtivado = true;
            AtivarMarcelline();
        }
    }

    private void AtivarMarcelline()
    {
        if (marcelline != null)
        {
            marcelline.SetActive(true);

            IAjustar ajuste = marcelline.GetComponent<IAjustar>();
            if (ajuste != null)
                ajuste.Ajustar();
        }

        if (somAssustador != null)
            somAssustador.Play();

        Invoke(nameof(DesativarMarcelline), tempoVisivel);
    }

    private void DesativarMarcelline()
    {
        if (marcelline != null)
            marcelline.SetActive(false);
    }
}
