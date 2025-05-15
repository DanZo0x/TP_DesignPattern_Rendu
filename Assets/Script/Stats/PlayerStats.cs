using NaughtyAttributes;
using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IStats
{
    [InfoBox("percentage added to the actual Stat \n Base + Base%Stat \n So if Base = 100 and Str = 1 then final is 101")]
    [SerializeField] private int Str;
    [SerializeField] private int Spe;
    [SerializeField] private int Hlt;

    int IStats.Str { get => Str; set => Str = value; }
    int IStats.Spe { get => Spe; set => Spe = value; }
    int IStats.Htl { get => Hlt; set => Hlt = value; }

}
