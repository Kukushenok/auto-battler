namespace Game.View
{
    public struct DexterityCheck
    {
        public int Got;
        public int Wanted;
        public bool IsPlayer;
        public DexterityCheck(int got, int wanted, bool isPlayer)
        {
            Got = got;
            Wanted = wanted;
            IsPlayer = isPlayer;
        }
        public bool IsSuccessful => Got > Wanted;
    }
}
