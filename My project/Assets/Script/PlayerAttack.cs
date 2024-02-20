using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    /*[SerializeField] private float attackRange = 3.0f;

    [SerializeField] private int attackForce = 10;*/

    private LifeSystem _lifeSystem;
    
    void Awake()
    {
        _lifeSystem = GetComponent<LifeSystem>();
    }

    public void Attack()
    {
        _lifeSystem.Decrease(Inventory.Instance.GetPlayerAttackForce());
    }
}
