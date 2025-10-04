using Cysharp.Threading.Tasks;
using UnityEngine;
namespace Game.View
{
    public interface IMainMenu
    {
        public enum Move { Quit, PlayGame }
        public UniTask<Move> Show(bool disableQuit);
    }
    public class MainMenu : MonoBehaviour, IMainMenu
    {
        [SerializeField] private MonoBehaviorSection section;
        [SerializeField] private MonoBehaviourView<Choice> startButton;
        [SerializeField] private MonoBehaviourView<Choice> endButton;
        public async UniTask<IMainMenu.Move> Show(bool disableQuit)
        {
            await section.TryShow();
            IMainMenu.Move result = IMainMenu.Move.PlayGame;
            if (disableQuit)
            {
                await startButton.WaitForSelection();
            }
            else
            {
                int idx = await ChoiceExtensions.WaitForSelection(startButton, endButton);
                if (idx == 1) result = IMainMenu.Move.Quit;
            }
            await section.TryHide();
            return result;
        }
    }
}
