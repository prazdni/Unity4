using System;

namespace Unity4.Lesson8
{
    public class KeyViewModel : IKeyViewModel
    {
        public event Action OnKeyTake = () => { };
        
        private IKeyModel _key;
        
        public KeyViewModel(IKeyModel key)
        {
            _key = key;
        }

        public void OnTake()
        {
            OnKeyTake.Invoke();
        }
    }
}