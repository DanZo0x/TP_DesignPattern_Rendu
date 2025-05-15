public interface IStats
{
    int Str { get; protected set; }
    int Spe { get; protected set; }
    int Htl { get; protected set; }

    public void LvlUp(int NewStr, int NewHlt, int NewSpe);

    public int calculateStat(int baseStat, int stat);
}