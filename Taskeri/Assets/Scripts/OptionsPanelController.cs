using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsPanelController : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject taskPanelPrefab;
    public GameObject cursorClicks;
    public Canvas canvas;
    public float offsetX = 10f;

    private RectTransform optionsPanelRectTransform;

    private void Start()
    {
        optionsPanel.SetActive(false);
        optionsPanelRectTransform = optionsPanel.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right mouse button click
        {
            Vector3 cursorPos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(cursorPos);

            // Check if the mouse is over a UI element using EventSystem
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                optionsPanel.transform.position = cursorPos;
                optionsPanel.transform.SetAsLastSibling();
                optionsPanel.SetActive(true);
            }
        }
        else if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            // Check if the mouse is over a UI element using EventSystem
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                optionsPanel.SetActive(false);
            }
        }
    }

    public void SpawnTaskPanel()
    {
        optionsPanel.SetActive(false);
        Vector3 cursorPos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(cursorPos);
        GameObject taskPanelInstance = Instantiate(taskPanelPrefab, cursorClicks.transform);
        RectTransform taskPanelRectTransform = taskPanelInstance.GetComponent<RectTransform>();
        Vector2 anchoredPos = new Vector2(worldPos.x, worldPos.y) - canvas.GetComponent<RectTransform>().anchoredPosition;
        taskPanelInstance.transform.SetAsLastSibling();
        taskPanelRectTransform.anchoredPosition = anchoredPos;
        worldPos.z = 0f;
        taskPanelInstance.transform.position = worldPos;
    }
}
