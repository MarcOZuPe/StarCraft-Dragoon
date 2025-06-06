using UnityEngine;

public class UnitCommandController : MonoBehaviour
{
    public LayerMask unitLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // clic derecho
        {
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("disparo");
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, unitLayer))
            {
                Unit targetUnit = hit.collider.GetComponent<Unit>();

                if (targetUnit != null)
                {
                    foreach (Unit selected in UnitSelectionBox.SelectedUnits)
                    {
                        if (selected == null || selected == targetUnit) continue;

                        var rel = FactionRelations.GetRelationship(
                            selected.GetFaction(), targetUnit.GetFaction());

                        if (rel == RelationshipType.Enemy)
                        {
                            UnitAttack attack = selected.GetComponent<UnitAttack>();
                            if (attack != null)
                                
                            attack.StartAttack(targetUnit);
                        }
                    }
                }
            }
        }
    }
}
