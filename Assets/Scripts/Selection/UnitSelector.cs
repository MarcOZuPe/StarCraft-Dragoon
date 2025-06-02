using UnityEngine;
using UnityEngine.AI;

public class UnitSelector : MonoBehaviour
{
    [SerializeField] private Camera cam; // arrastra Main Camera aquí
    [SerializeField] private UnitSelectionBox selectionBox; // arrástralo desde GameManager
    /*
    void Update() 
        
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<Targetable>(out var target))
                {
                    foreach (var unit in selectionBox.SelectedUnits)
                    {
                        unit.SetTarget(target);
                    }
                }
                else
                {
                    foreach (var unit in selectionBox.SelectedUnits)
                    {
                        unit.MoveTo(hit.point);
                    }
                }
            }
        }
    }*/
}
