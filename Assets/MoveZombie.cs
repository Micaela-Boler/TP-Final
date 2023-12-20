using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveZombie : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform target;

    public float rotateSpeed = 0.1f;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;   
    }

  
    void Update()
    {
            if (!target) GetTarget();
            else Rotation();

            agent.SetDestination(target.position);
    }

    
    private void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    
    private void Rotation()
    {
        //Enemigo rota hacia el jugador
        Vector2 targetDirection = target.position - transform.position;

        // Calcula el ángulo teniendo en cuenta la dirección y, y la dirección x que calculamos anteriormente
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;

        // Crea una rotación en forma de Quaternion a partir del ángulo calculado.
        Quaternion qua = Quaternion.Euler(new Vector3(0, 0, angle));

        // Suaviza la rotación actual hacia la nueva rotación usando Slerp.
        transform.localRotation = Quaternion.Slerp(transform.localRotation, qua, rotateSpeed);
    }
    
}
