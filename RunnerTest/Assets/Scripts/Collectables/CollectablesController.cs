using UnityEngine;
using Scripts.Screen;

namespace Scripts.Collectables
{
    public class CollectablesController : CollectablesControllerBase
    {
        private ScreenDataBase screenData;
        private int collCount;

        public CollectablesController(ScreenDataBase _screenData)
        {
            screenData = _screenData;
        }

        public override void Enable()
        {
            if (PlayerPrefs.HasKey("CollCount"))
            {
                collCount = PlayerPrefs.GetInt("CollCount");
            }
            else
            {
                collCount = 0;
            }

            screenData.CoinsValueText.text = collCount.ToString();

        }

        public override void Disable()
        {
            PlayerPrefs.SetInt("CollCount", collCount); 
        }

        public override void OnCollected()
        {
            collCount++;
            screenData.CoinsValueText.text = collCount.ToString();
        }
    }
}