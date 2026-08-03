using UnityEngine;
using UnityEngine.InputSystem;

public class MuseumUI : MonoBehaviour
{

    [SerializeField] private GameObject MüzePanel;
    private Camera mainCam;
    void Start()
    {
        mainCam= Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
         if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = mainCam.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                MüzePanel.SetActive(true);;
                }
            }
        }
    }
}
