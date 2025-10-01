using System.Threading.Tasks;

namespace AutoBattler.Looped
{
    public interface ILoopHandler
    {
        public Task<bool> DecideToContinuePlaying();
        public AutoBattler.Settings GetSettings();
    }
    public class AutoBattlerLoop : IPlayable
    {
        private ILoopHandler loopHandler;
        public AutoBattlerLoop(ILoopHandler loopHandler)
        {
            this.loopHandler = loopHandler;
        }

        public async Task Play()
        {
            bool want = await loopHandler.DecideToContinuePlaying();
            while (want)
            {
                await new AutoBattler(loopHandler.GetSettings()).Play();
                want = await loopHandler.DecideToContinuePlaying();
            }
        }
    }
}
