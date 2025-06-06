using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float range = 10f;

    private float nextFireTime;
    private Unit target;
    private Unit selfUnit; // referencia a este unit

    private void Awake()
    {
        selfUnit = GetComponent<Unit>(); // para saber la propia facción
    }

    public void StartAttack(Unit target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= range && Time.time >= nextFireTime)
        {
            // Verificar si es enemigo
            var myFaction = selfUnit.GetFaction();
            var targetFaction = target.GetFaction();
            var rel = FactionRelations.GetRelationship(myFaction, targetFaction);

            if (rel == RelationshipType.Enemy)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    
    
        void Shoot()
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.SetTarget(target.transform, selfUnit.GetFaction());
        }

    
}
