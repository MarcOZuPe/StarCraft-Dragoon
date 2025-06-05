using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UnitSelectionBox : MonoBehaviour
{
    [SerializeField] private RectTransform selectionBox;

    private Vector2 mouseStartPos;
    private bool isMouseDown = false;
    private bool isDragging = false;

    public List<Unit> SelectedUnits { get; private set; } = new List<Unit>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPos = Input.mousePosition;
            isMouseDown = true;
            isDragging = false;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Unit unit = hit.collider.GetComponent<Unit>();
                if (unit != null)
                {
                    // Deselecciona todo lo que estaba seleccionado
                    foreach (var u in SelectedUnits)
                        u.SetSelected(false);
                    SelectedUnits.Clear();

                    // Selecciona la unidad clickeada
                    SelectedUnits.Add(unit);
                    unit.SetSelected(true);
                }
                else
                {
                    // Clic en vacío, deselecciona todo
                    foreach (var u in SelectedUnits)
                        u.SetSelected(false);
                    SelectedUnits.Clear();
                }
            }
            else
            {
                
                foreach (var u in SelectedUnits)
                    u.SetSelected(false);
                SelectedUnits.Clear();
            }
        }

        if (isMouseDown)
        {
            if (Vector2.Distance(Input.mousePosition, mouseStartPos) > 10 && !isDragging)
            {
                isDragging = true;
                selectionBox.gameObject.SetActive(true);
            }

            if (isDragging)
            {
                float boxWidth = Input.mousePosition.x - mouseStartPos.x;
                float boxHeight = Input.mousePosition.y - mouseStartPos.y;

                selectionBox.sizeDelta = new Vector2(Mathf.Abs(boxWidth), Mathf.Abs(boxHeight));
                selectionBox.anchoredPosition = (mouseStartPos + (Vector2)Input.mousePosition) / 2;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                SelectUnits();
            }

            isMouseDown = false;
            isDragging = false;
            selectionBox.gameObject.SetActive(false);
        }
    }

    private void SelectUnits()
    {
        SelectedUnits.Clear();

        Vector2 min = Vector2.Min(mouseStartPos, Input.mousePosition);
        Vector2 max = Vector2.Max(mouseStartPos, Input.mousePosition);

        Unit[] allUnits = Object.FindObjectsByType<Unit>(FindObjectsSortMode.None);

        foreach (var unit in allUnits)
        {
            Vector2 screenPos = Camera.main.WorldToScreenPoint(unit.transform.position);

            if (screenPos.x >= min.x && screenPos.x <= max.x &&
                screenPos.y >= min.y && screenPos.y <= max.y)
            {
                SelectedUnits.Add(unit);
                unit.SetSelected(true);
            }
            else
            {
                unit.SetSelected(false);
            }
        }
    }
}
