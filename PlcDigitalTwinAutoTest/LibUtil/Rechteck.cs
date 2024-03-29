﻿namespace LibUtil;

public class Rechteck
{
    public enum RichtungX { NachLinks, Steht, NachRechts }
    public enum RichtungY { NachOben, Steht, NachUnten }

    private Punkt _linksOben;
    private readonly double _breite;
    private readonly double _hoehe;

    public Rechteck(Punkt linksOben, double b, double h)
    {
        _linksOben = linksOben;
        _breite = b;
        _hoehe = h;
    }

    public void SetPosition(Punkt linksOben) => _linksOben = linksOben.Clone();
    public void SetWaagrechtSchieben(double x) => _linksOben.X += x;
    public void SetSenkrechtSchieben(double y) => _linksOben.Y += y;
    public Punkt GetPosition() => _linksOben;
    public double GetLinks() => _linksOben.X;
    public double GetRechts() => _linksOben.X + _breite;
    public double GetOben() => _linksOben.Y;
    public double GetUnten() => _linksOben.Y + _hoehe;

    public static bool Kollision(Rechteck r1, Rechteck r2)
    {
        return r1.GetLinks() < r2.GetRechts() &&
               r2.GetLinks() < r1.GetRechts() &&
               r1.GetOben() < r2.GetUnten() &&
               r2.GetOben() < r1.GetUnten();
    }

    // ReSharper disable once UnusedMember.Global
    public static bool Ausgebremst(Rechteck bewegt, Rechteck hinderniss, RichtungX richtungX, RichtungY richtungY)
    {
        if (Kollision(bewegt, hinderniss)) return true;

        var bewegungStoppen = false;

        switch (richtungX)
        {
            case RichtungX.NachRechts: bewegungStoppen |= hinderniss.GetLinks() > bewegt.GetLinks(); break;
            case RichtungX.NachLinks: bewegungStoppen |= hinderniss.GetLinks() < bewegt.GetLinks(); break;
            case RichtungX.Steht: break;
            default: throw new ArgumentOutOfRangeException(nameof(richtungX), richtungX, null);
        }

        switch (richtungY)
        {
            case RichtungY.NachOben: bewegungStoppen |= hinderniss.GetOben() < bewegt._hoehe; break;
            case RichtungY.NachUnten: bewegungStoppen |= hinderniss.GetOben() > bewegt.GetOben(); break;
            case RichtungY.Steht: break;
            default: throw new ArgumentOutOfRangeException(nameof(richtungY), richtungY, null);
        }

        return bewegungStoppen;
    }
}