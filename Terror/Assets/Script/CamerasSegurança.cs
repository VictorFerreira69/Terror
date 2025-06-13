using UnityEngine;
using UnityEngine.UI;

public class CamerasSegurança : MonoBehaviour
{
    [Header("Painel das Câmeras")]
    [SerializeField] private GameObject cameraUI;

    [Header("Câmeras de Segurança")]
    [SerializeField] private Camera[] securityCameras;

    [Header("Botões das Câmeras")]
    [SerializeField] private Button[] cameraButtons; 

    [Header("Player")]
    [SerializeField] private FirstPersonController move;

    [Header("Sistema de Bateria")]
    [SerializeField] private BateriaController bateriaController;

 [Header("Consumo por segundo quando as câmeras estão ativas")]
  [SerializeField] private float consumoCamerasPorSegundo = 5f;


    private int currentCamIndex = 0;
    private bool isCameraActive = false;

    void Start()
    {
        cameraUI.SetActive(false);
        SetAllCameras(false);

      
        for (int i = 0; i < cameraButtons.Length; i++)
        {
            int index = i; 
            
            cameraButtons[i].onClick.AddListener(() => SwitchToCamera(index));
             
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleCameraSystem(true);
            move.playerCanMove = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isCameraActive)
        {
            ToggleCameraSystem(false);
            move.playerCanMove = true;
        }

       if (isCameraActive)
{
    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
        SwitchCamera(1);
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
        SwitchCamera(-1);
    }

    if (bateriaController != null)
    {
        bateriaController.energiaAtual -= consumoCamerasPorSegundo * Time.deltaTime;
    }
}
    }

    void ToggleCameraSystem(bool state)
    {
        isCameraActive = state;
        cameraUI.SetActive(state);

        if (state)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SetAllCameras(false);
            securityCameras[currentCamIndex].gameObject.SetActive(true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            SetAllCameras(false);
        }
    }

    void SwitchCamera(int direction)
    {
        securityCameras[currentCamIndex].gameObject.SetActive(false);
        currentCamIndex += direction;

        if (currentCamIndex >= securityCameras.Length) currentCamIndex = 0;
        if (currentCamIndex < 0) currentCamIndex = securityCameras.Length - 1;

        securityCameras[currentCamIndex].gameObject.SetActive(true);
    }

    public void SwitchToCamera(int index)
    {
        if (index >= 0 && index < securityCameras.Length)
        {
            SetAllCameras(false);
            currentCamIndex = index;
            securityCameras[currentCamIndex].gameObject.SetActive(true);
        }
    }

    void SetAllCameras(bool state)
    {
        foreach (Camera cam in securityCameras)
        {
            cam.gameObject.SetActive(state);
        }
    }
}