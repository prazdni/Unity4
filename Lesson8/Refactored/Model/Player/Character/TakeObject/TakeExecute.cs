using UnityEngine;

namespace Unity4.Lesson8
{
    public class TakeExecute : ITakeExecute
    {
        public ITakeObject TakeObject => _takeObject;
        private ITakeObject _takeObject;
        private IExecute _takeInput;

        public TakeExecute(CharacterModel character, Transform takePoint)
        {
            _takeObject = new TakeObject(takePoint, character.TakeRange);
            _takeInput = new TakeObjectInput(_takeObject);
        }

        public void Execute(float deltaTime)
        {
            _takeInput.Execute(deltaTime);
            _takeObject.Execute(deltaTime);
        }
    }
}