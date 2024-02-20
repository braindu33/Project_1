using UnityEngine;

namespace Script
{
    public class AutoFarming : MonoBehaviour
    {
        [SerializeField] private float interval = 5f;

        [SerializeField] private int resourceNumber;

        [SerializeField] private int index;

        private int _value;

        private void Awake()
        {
            InvokeRepeating(nameof(PerformAutoFarmAction), 2f, interval);
        }

        private void PerformAutoFarmAction()
        {
            _value += resourceNumber;
            ResourceUIController.Instance.UpdateResourceUI(index, _value);
        }
    }
}