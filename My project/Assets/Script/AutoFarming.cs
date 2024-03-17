using UnityEngine;

namespace Script
{
    public class AutoFarming : MonoBehaviour
    {
        [SerializeField] private float interval = 2f;
        [SerializeField] private int resourceNumber; 
        [SerializeField] private int index;
        [SerializeField] private int xpIndex;
        [SerializeField] private int xpValue;

        private int value;

        private void Awake()
        {
            InvokeRepeating(nameof(PerformAutoFarmAction), 2f, interval);
            InvokeRepeating(nameof(PerformAutoXpFarmAction), 2f, interval);
        }

        private void PerformAutoFarmAction()
        {
            value += resourceNumber;
            ResourceUIController.Instance.UpdateResourceUI(index, value);
        }

        private void PerformAutoXpFarmAction()
        {
            value += xpValue;
            ResourceUIController.Instance.UpdateXpUI(xpIndex, value);
        }
    }
}