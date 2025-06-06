using UnityEngine;
using UnityEngine.UI;

public class CamerasSegurança : MonoBehaviour
{
    [Header(" Painel das Camera")]
    [SerializeField] private GameObject cameraUI;

    [Header("Cameras de Segurança")]
    [SerializeField] private Camera[] securityCameras;
    
    [Header("Player")]
   [SerializeField] private FirstPersonController move;

    private int currentCamIndex = 0;
    private bool isCameraActive = false;

    void Start()
    {
        cameraUI.SetActive(false);
        SetAllCameras(false);
       
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

    void SetAllCameras(bool state)
    {
        foreach (Camera cam in securityCameras)
        {
            cam.gameObject.SetActive(state);
        }
    }
}

