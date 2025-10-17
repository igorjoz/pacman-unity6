using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacman : MonoBehaviour
{
    public Movement movement { get; private set; }

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            movement.SetDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            movement.SetDirection(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            movement.SetDirection(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            movement.SetDirection(Vector2.right);
        }

        RotatePacman(movement.direction);
    }

    private void RotatePacman(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }
}
