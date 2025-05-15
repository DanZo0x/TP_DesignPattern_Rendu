using System;

public interface IStats
{
    int Str { get; protected set; }
    int Spe { get; protected set; }
    int Htl { get; protected set; }

    public virtual int CalculateStat(int baseStat, int stat)
    {
        return (int)(baseStat + baseStat * (float)stat / 100f);
    }

}