using UnityEngine;
using UnityEngine.AI;

public class UnitSelector : MonoBehaviour
{
    [SerializeField] private Camera cam; // arrastra Main Camera aqu�
    [SerializeField] private UnitSelectionBox selectionBox; // arr�stralo desde GameManager
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
