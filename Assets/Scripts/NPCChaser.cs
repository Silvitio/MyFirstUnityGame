using UnityEngine;
using UnityEngine.AI;

public class NPCChaser : MonoBehaviour
{
    public Transform player;        // Игрок, за которым будет следовать NPC
    private NavMeshAgent agent;     // NavMeshAgent для движения NPC

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }
}
