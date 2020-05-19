using UnityEngine;
using System;
using Scripts.Screen;

namespace Scripts.Collectables
{
    public class CollectablesController : CollectablesControllerBase
    {
        private ScreenDataBase screenData;
        private int collCount;

        private Animator animator;
        private Vector3 startScale = new Vector3(1, 1, 1);
        private Vector3 endScale = new Vector3(1.2f, 1.2f, 1.2f);
        private bool canScaleUp = false;
        private bool canScaleDown = false;

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
            animator = screenData.CoinsValueText.GetComponent<Animator>();
        }

        public override void Disable()
        {
            PlayerPrefs.SetInt("CollCount", collCount);
        }

        public override void OnCollected()
        {
            collCount++;
            screenData.CoinsValueText.text = collCount.ToString();
            animator.SetTrigger("OnCoinCollected");
        }
    }
}
