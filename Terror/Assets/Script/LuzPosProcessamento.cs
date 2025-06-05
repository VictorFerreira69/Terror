using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LuzPosProcessamento : MonoBehaviour,ILuz
{
    [Header("Pos Processamento")]
    [SerializeField] private Volume volume;

    [Header("Bloom aumento")]
    [SerializeField] private float bloomAumentado = 1.2f;
    private float bloomOriginal;
    private Bloom bloom;

    [Header("Exposure aumento")]
    [SerializeField] private float exposureAumentado = 1.5f;
    private float exposureOriginal;
    private ColorAdjustments colorAdjustments;

    [Header(" Shadows Midtones Highlights aumento")]
    [SerializeField] private Vector4 shadowsAumentado = new Vector4(1.1f, 1.1f, 1.1f, 0f);
    [SerializeField] private Vector4 midtonesAumentado = new Vector4(1.2f, 1.2f, 1.2f, 0f);
    private Vector4 shadowsOriginal;
    private Vector4 midtonesOriginal;
    private ShadowsMidtonesHighlights smh;

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

        if (volume.profile.TryGet(out smh))
        {
            shadowsOriginal = smh.shadows.value;
             midtonesOriginal = smh.midtones.value;

            smh.shadows.value = shadowsAumentado;
            smh.midtones.value = midtonesAumentado;
            
        }
    }

    public void AtivarEfeito()
    {
        if (bloom != null)
            bloom.intensity.value = bloomAumentado;

        if (colorAdjustments != null)
            colorAdjustments.postExposure.value = exposureAumentado;

        if (smh != null)
        {
            smh.shadows.value = shadowsAumentado;
            smh.midtones.value = midtonesAumentado;
         
        }
    }

    public void RestaurarEfeito()
    {
        if (bloom != null)
            bloom.intensity.value = bloomOriginal;

        if (colorAdjustments != null)
            colorAdjustments.postExposure.value = exposureOriginal;

        if (smh != null)
        {
            smh.shadows.value = shadowsOriginal;
            smh.midtones.value = midtonesOriginal;
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lixo"))
        {
            RestaurarEfeito();
           
        }
    }
}