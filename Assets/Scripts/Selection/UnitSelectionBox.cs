using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UnitSelectionBox : MonoBehaviour
{
    [SerializeField] private RectTransform selectionBox; // arrástralo desde la UI  
    private Vector2 startPos;
    private Vector2 endPos;

    public List<Unit> SelectedUnits { get; private set; } = new List<Unit>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            selectionBox.gameObject.SetActive(true);
        }

        if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            Vector2 size = endPos - startPos;
            selectionBox.anchoredPosition = startPos;
            selectionBox.sizeDelta = new Vector2(Mathf.Abs(size.x), Mathf.Abs(size.y));
        }

        if (Input.GetMouseButtonUp(0))
        {
            SelectUnitsInRectangle();
            selectionBox.gameObject.SetActive(false);
        }
    }

    private void SelectUnitsInRectangle()
    {
        SelectedUnits.Clear();
        Unit[] allUnits = Object.FindObjectsByType<Unit>(FindObjectsSortMode.None); // Reemplazo de método obsoleto  

        Vector2 min = Vector2.Min(startPos, endPos);
        Vector2 max = Vector2.Max(startPos, endPos);

        foreach (var unit in allUnits)
        {
            Vector2 screenPos = Camera.main.WorldToScreenPoint(unit.transform.position);
            if (screenPos.x > min.x && screenPos.x < max.x && screenPos.y > min.y && screenPos.y < max.y)
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
