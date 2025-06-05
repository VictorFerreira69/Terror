using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LusPosProcessamento : MonoBehaviour,ILuz
{
    [Header("Pos Processamento")]
    [SerializeField] private Volume volume;

    [Header("Bloom aumento")]
    [SerializeField] private float bloomAumentado = 1.2f;
    private float bloomOriginal;
    private Bloom bloom;

    [Header("Exposure")]
    [SerializeField] private float exposureAumentado = 1.5f;
    private float exposureOriginal;
    private ColorAdjustments colorAdjustments;

    private void Start()
    {
        if (volume.profile.TryGet(out bloom))
        {
            bloomOriginal = bloom.intensity.value;
            bloom.intensity.value = bloomAumentado;
        }

        if (volume.profile.TryGet(out colorAdjustments))
        {
            exposureOriginal = colorAdjustments.postExposure.value;
            colorAdjustments.postExposure.value = exposureAumentado;
        }
    }

    public void AtivarEfeito()
    {
        if (bloom != null)
            bloom.intensity.value = bloomAumentado;

        if (colorAdjustments != null)
            colorAdjustments.postExposure.value = exposureAumentado;
    }

    public void RestaurarEfeito()
    {
        if (bloom != null)
            bloom.intensity.value = bloomOriginal;

        if (colorAdjustments != null)
            colorAdjustments.postExposure.value = exposureOriginal;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lixo"))
        {
            RestaurarEfeito(); 
            
        }
    }
}