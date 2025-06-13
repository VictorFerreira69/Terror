using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
public enum AnimatronicsStatus
{
    Wait,Patrol,Chase,Search
}

public class Animatronics : MonoBehaviour,IAnimatronic
{
    [Header("NavMesh")]
    NavMeshAgent agent;

    [Header("Player")]
    [SerializeField] Transform player;

    [Header("Patrulha")]
    [SerializeField] Transform[] patrolPoints;

    [Header("Animator")]
    [SerializeField] Animator animator;

    [Header("GameOver")]
    [SerializeField] string cenaGameOver = "GameOver";

    [Header("WaitTime")]
    [SerializeField] float waitTime = 2f;

    [Header("Jumpscare")]
    [SerializeField] float distanciaJumpscare = 3f;

    [Header("Timeline")]
    [SerializeField] PlayableDirector jumpscareTimeline;

    [Header("Câmeras")]
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject jumpscareCamera;

    [Header("Jumpscare Audio")]
   [SerializeField] AudioClip jumpscareSom;
  [SerializeField] AudioSource audioSource;

    private AnimatronicsStatus state;
    private bool emJumpscare = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        animator.SetTrigger("Dancar");

        if (ControladorAnimatronic.instancia != null)
            ControladorAnimatronic.instancia.Registrar(this);

        
        if (mainCamera != null) mainCamera.SetActive(true);
        if (jumpscareCamera != null) jumpscareCamera.SetActive(false);
    }

    void Update()
    {
        if (emJumpscare || !agent.enabled)
            return;

        float distancia = Vector3.Distance(transform.position, player.position);

        if (distancia <= distanciaJumpscare)
        {
            IniciarJumpscare();
            return;
        }

        Looking();

        switch (state)
        {
            case AnimatronicsStatus.Wait:
                break;

            case AnimatronicsStatus.Patrol:
                if (agent.remainingDistance <= agent.stoppingDistance)
                    SetState(AnimatronicsStatus.Wait);
                break;

            case AnimatronicsStatus.Chase:
                agent.SetDestination(player.position);
                break;

            case AnimatronicsStatus.Search:
                if (agent.remainingDistance <= agent.stoppingDistance)
                    SetState(AnimatronicsStatus.Wait);
                break;
        }
    }

    public void SetState(AnimatronicsStatus newState)
    {
        switch (newState)
        {
            case AnimatronicsStatus.Wait:
                animator.SetTrigger("Parar");
                StartCoroutine(Waiting());
                break;
            case AnimatronicsStatus.Patrol:
                animator.SetTrigger("Andar");
                agent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length)].position);
                break;
            case AnimatronicsStatus.Chase:
                animator.SetTrigger("Correr");
                break;
            case AnimatronicsStatus.Search:
                animator.SetTrigger("Andar");
                agent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length)].position);
                break;
        }

        state = newState;
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime);
        SetState(AnimatronicsStatus.Patrol);
    }

  public void Looking()
{
    Vector3 directionToPlayer = (player.position - transform.position).normalized;
    float distanceToPlayer = Vector3.Distance(transform.position, player.position);
    Vector3 eyePosition = transform.position + Vector3.up * 1.8f; 

    if (Physics.Raycast(eyePosition, directionToPlayer, out RaycastHit hit, distanceToPlayer))
    {
        if (hit.transform == player)
        {
            
            
            if (state != AnimatronicsStatus.Chase)
                SetState(AnimatronicsStatus.Chase);
        }
        else
        {
           
            if (state == AnimatronicsStatus.Chase)
                SetState(AnimatronicsStatus.Search);
        }
    }
    else
    {
       
        if (state == AnimatronicsStatus.Chase)
            SetState(AnimatronicsStatus.Search);
    }
}
   public void IniciarJumpscare()
   {
    if (emJumpscare) return;

    emJumpscare = true;
    agent.isStopped = true;
    animator.SetTrigger("Jumpscare");

   
    if (audioSource != null && jumpscareSom != null)
    {
        audioSource.clip = jumpscareSom;
        audioSource.Play();
    }

    
    if (mainCamera != null) mainCamera.SetActive(false);
    if (jumpscareCamera != null) jumpscareCamera.SetActive(true);

    
    if (jumpscareTimeline != null)
    {
        jumpscareTimeline.Play();
        StartCoroutine(EsperarTimeline(jumpscareTimeline.duration));
    }
    else
    {
        Invoke(nameof(CarregarCenaGameOver), 3f);
    }
}


    IEnumerator EsperarTimeline(double duracao)
    {
        yield return new WaitForSeconds((float)duracao);
        CarregarCenaGameOver();
    }

    void CarregarCenaGameOver()
    {
        SceneManager.LoadScene(cenaGameOver);
    }

    public void AtivarPatrulha()
    {
        agent.enabled = true;
        agent.isStopped = false;
        animator.SetTrigger("Andar");
        SetState(AnimatronicsStatus.Patrol);
    }
}