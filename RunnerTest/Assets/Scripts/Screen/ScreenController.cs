using UnityEngine;

namespace Scripts.Screen
{
    public class ScreenController : ScreenBase
    {
        private ScreenDataBase screenData;

        public ScreenController(ScreenDataBase _screenData)
        {
            screenData = _screenData;
        }

        public override void ResetDistance()
        {
            screenData.DistanceValueText.text = "0";
        }

        public override void SetDistance(float distance)
        {
            int d = (int)distance;
            screenData.DistanceValueText.text = d.ToString();
        }
    }
}