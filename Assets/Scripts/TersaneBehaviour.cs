using UnityEngine;
using UnityEngine.InputSystem;

public class TersaneBehaviour : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] private GameObject TersanePanel;
    public bool TersaneUnlocked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam= Camera.main;
        TersaneUnlocked = false;
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
                    OpenMenu();
                }
            }
        }
    }
    public void OpenMenu()
        {
            TersanePanel.SetActive(true);
        }
}
