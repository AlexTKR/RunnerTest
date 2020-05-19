using UnityEngine;
using TMPro;

namespace Scripts.Screen
{
    public abstract class ScreenDataBase : MonoBehaviour
    {
        public abstract TextMeshProUGUI DistanceValueText { get; }
        public abstract TextMeshProUGUI CoinsValueText { get; }
    }
}