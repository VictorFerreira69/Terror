using UnityEngine;

public class TungShaur : MonoBehaviour
{
    [Header("Detecção do Jogador")]
    [SerializeField] private float detectionRange = 3f;

    [Tooltip("Referência ao jogador (arraste via Inspector)")]
    [SerializeField] private Transform player;

    [Header("Componente de Jumpscare")]
    [SerializeField] private MonoBehaviour jumpscareComponent;

    private IInteractable jumpscare;
    private bool activated = false;

    private void Start()
    {
        jumpscare = jumpscareComponent as IInteractable;

     
    }

    private void Update()
    {
        if (activated || player == null || jumpscare == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            jumpscare.Trigger();
            activated = true;
        }
    }
}