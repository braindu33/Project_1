using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float attackRange = 3.0f; // The range for the player's attack

    [SerializeField]
    private int attackForce = 10;     // The attack force (life points per attack)

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, attackRange))
            {
                // Check if the object hit has a "LifeSystem" component
                LifeSystem lifeSystem = hit.collider.GetComponent<LifeSystem>();

                if (lifeSystem != null)
                {
                    // Perform an attack on the object with a "LifeSystem"
                    lifeSystem.TakeDamage(attackForce);
                }
            }
        }
    }
}
