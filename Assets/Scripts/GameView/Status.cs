namespace Game.View
{
    public struct GameStatus
    {
        public enum Section
        {
            Battle,
            SkillChoose,
            WeaponChoose
        }
        public int Stage;
        public Section CurrentSection;
    }
}
