using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField] private GameObject selectionCircle;
    private NavMeshAgent agent;
   

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        SetSelected(false);
    }

    public void SetSelected(bool selected)
    {
        if (selectionCircle != null)
            selectionCircle.SetActive(selected);
    }


}

