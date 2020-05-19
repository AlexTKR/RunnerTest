using UnityEngine;
using TMPro;

namespace Scripts.Screen
{
    public class ScreenData : ScreenDataBase
    {
        [SerializeField] private TextMeshProUGUI distanceValueText;
        [SerializeField] private TextMeshProUGUI coinsValueText;

        public override TextMeshProUGUI DistanceValueText => distanceValueText;
        public override TextMeshProUGUI CoinsValueText => coinsValueText;
    }
}