using UnityEngine;

public class UnitCommandController : MonoBehaviour
{
    public LayerMask unitLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // clic derecho
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mouseWorldPos.x, mouseWorldPos.y); // UNT0034 fix: Explicitly convert Vector3 to Vector2
            Debug.Log(mousePos2D);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, unitLayer);
            Debug.Log("disparo");
            if (hit.collider != null)
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
