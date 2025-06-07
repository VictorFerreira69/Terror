using UnityEngine;

public class PlayerPerto : MonoBehaviour
{
    [Tooltip("Player")]
  [SerializeField] Transform player;

   [Header("Distancia pra ativar a animaçao")]
   [SerializeField]float activationDistance = 4f;

    private IAtivar activatable;
    private bool hasActivated = false;

    void Start()
    {
        activatable = GetComponent<IAtivar>();

        
    }

    void Update()
    {
        if (hasActivated || player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= activationDistance)
        {
            activatable.Activate();
            hasActivated = true;
        }
    }
}