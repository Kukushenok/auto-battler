namespace AutoBattler
{
    public interface IGameConfigRepository
    {
        
        public void GetCharacters();
        public void GetEnemies();
        public AutoBattler.Settings GetSettings();
    }
}
