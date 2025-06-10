using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Animatronics : MonoBehaviour,IAnimatronic
{
    [Header("Animaçao")]
    [SerializeField] private Animator animator;

    [Header("NavMesh")]
    [SerializeField] private NavMeshAgent agente;

    [Header("Player")]
    [SerializeField] private Transform jogador;

    [Header("Patrulha")]
    [SerializeField] private Transform[] pontosPatrulha;

    [Header("Jumpscare")]
    [SerializeField] private float distanciaJumpscare = 3f;
    [SerializeField] private float tempoJumpscare = 2f;

    [Header("Cena Game Over")]
    [SerializeField] private string cenaGameOver = "GameOver";
   

    private int indexPontoAtual = 0;
    private bool patrulhando = false;
    private bool emJumpscare = false;


  private void Start()
  {
    agente.enabled = false;
    animator.SetTrigger("Dancar");

   
    if (ControladorAnimatronic.instancia != null)
    {
        ControladorAnimatronic.instancia.Registrar(this);
    }
  }

    private void Update()
    {
        
        if (!patrulhando || emJumpscare) return;
         

        float distancia = Vector3.Distance(transform.position, jogador.position);
        if (distancia <= distanciaJumpscare)
        {
            IniciarJumpscare();
            return;
        }

        if (!agente.pathPending && agente.remainingDistance < 0.5f)
        {
            indexPontoAtual = (indexPontoAtual + 1) % pontosPatrulha.Length;
            agente.SetDestination(pontosPatrulha[indexPontoAtual].position);
        }
    }

    public void AtivarPatrulha()
    {
       
        patrulhando = true;
        animator.SetTrigger("Andar");
        agente.enabled = true;
        agente.SetDestination(pontosPatrulha[indexPontoAtual].position);
    }

    private void IniciarJumpscare()
    {
        emJumpscare = true;
        agente.isStopped = true;
        animator.SetTrigger("Jumpscare");

        
        Invoke(nameof(CarregarGameOver), 2f);
    }

    private void CarregarGameOver()
    {
        SceneManager.LoadScene(cenaGameOver);
    }
}