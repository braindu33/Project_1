using System;
using UnityEngine;
using UnityEngine.UI;

//[Serializable]
public class Levels : MonoBehaviour
{
    [SerializeField] public int xpIndex;
    [SerializeField] public int xpToRemove;
    
    [SerializeField] public Button nexLevelButton;
    [SerializeField] public Vector3 positionToSpawn;
    
    public Spawner spawner;
    
    public Action close;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void LevelUp()
    {
        gameObject.SetActive(true);
        Debug.Log("One");
        if (Inventory.Instance.RemoveXp(xpIndex, xpToRemove))
        {
            Debug.Log("Two");
            spawner.Spawn(positionToSpawn);
            Debug.Log("Xp removed" + "Level unlocked");
        }
        close.Invoke();
    }
    
    
}