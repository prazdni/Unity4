using System;

namespace Asteroids
{
    public class MenuInterface : BaseUI
    {
        public override void ExecuteUI()
        {
            gameObject.SetActive(true);
        }

        public override void HideUI()
        {
            gameObject.SetActive(false);
        }
    }
}