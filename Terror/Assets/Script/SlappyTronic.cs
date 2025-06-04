using UnityEngine;

public class SlappyTronic : MonoBehaviour
{
    [Header("Detectar o player")]
    [SerializeField] private float detectionRange = 3f;

    [Header("Referência player")]
    [SerializeField] private Transform player;

    [Header("Componente  Jumpscare")]
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
