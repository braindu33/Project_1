using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class CraftFonction : MonoBehaviour
{
    //public List<CraftFonction> ItemCraft = new ();
    [SerializeField] private int woodIndex, rockIndex;
    [SerializeField] private int woodCount = 1;
    [SerializeField] private int brickCount = 3;

    //[SerializeField] private TextMeshProUGUI textWood, textRock;

    [SerializeField] private Vector3 positionSpawn;

    [SerializeField] private Button craftButton;
    
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        craftButton.onClick.AddListener(Craft);
    }

    private void Start()
    {
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            gameObject.SetActive(true);
        }
    }

    #region Input

    private void Craft()
    {
        if (Inventory.Instance.RemoveResource(woodIndex & rockIndex, woodCount & brickCount))
        {
            _spawner.Spawn(positionSpawn);
        }
        Close();
    }

    private void Close()
    {
        gameObject.SetActive(false);
    }

    #endregion
}
