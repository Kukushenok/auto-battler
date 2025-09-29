using System;

namespace Game.View
{
    public class Choice
    {
        private Action OnChoosing;
        public Choice(Action onChoosing) => OnChoosing = onChoosing;
        public void Select() => OnChoosing?.Invoke();
    }
}
