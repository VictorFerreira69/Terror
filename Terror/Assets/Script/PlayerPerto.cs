using UnityEngine;

public class PlayerPerto : MonoBehaviour
{
    [Tooltip("Player")]
  [SerializeField] Transform player;

   [Header("Distancia pra ativar a animaçao")]
   [SerializeField]float activationDistance = 4f;

    private IInteractable trigger;
    private bool hasActivated = false;

    void Start()
    {
       trigger = GetComponent<IInteractable>();

        
    }

    void Update()
    {
        if (hasActivated || player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= activationDistance)
        {
            trigger.Trigger();
            hasActivated = true;
        }
    }
}