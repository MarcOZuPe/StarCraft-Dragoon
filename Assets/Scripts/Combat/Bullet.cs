using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    private Transform target;
    private FactionType sourceFaction;

    public void SetTarget(Transform target, FactionType faction)
    {
        this.target = target;
        this.sourceFaction = faction;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            Unit unit = target.GetComponent<Unit>();
            if (unit != null)
            {
                var rel = FactionRelations.GetRelationship(sourceFaction, unit.GetFaction());
                if (rel == RelationshipType.Enemy)
                {
                    Debug.Log($"{unit.name} recibió daño de {damage}");
                    
                }
            }

            Destroy(gameObject);
        }
    }
}
