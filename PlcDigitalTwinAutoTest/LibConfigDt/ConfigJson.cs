﻿using Contracts;

namespace LibConfigDt;

public class DtConfig
{
    public DtEaConfig AnalogeAusgaenge { get; set; }
    public DtEaConfig AnalogeEingaenge { get; set; }
    public DtEaConfig DigitaleAusgaenge { get; set; }
    public DtEaConfig DigitaleEingaenge { get; set; }
    public Textbausteine[] Textbausteine { get; set; }
    public Alarm[] Alarm { get; set; }
}
public class DtEaConfig
{
    public EaConfig[] EaConfig { get; set; }
    public bool ConfigOk { get; set; }
    public int AnzByte { get; set; }
}
public class EaConfig
{
    public int StartByte { get; set; }
    public int StartBit { get; set; }
    public EaTypen Type { get; set; }
    public string Bezeichnung { get; set; }
    public string Kommentar { get; set; }
    public EaConfigError EaConfigError { get; set; }
}
public class Textbausteine
{
    public int BausteinId { get; set; }
    public string PrefixH1 { get; set; }
    public string PrefixH2 { get; set; }
    // ReSharper disable once UnusedMember.Global
    public int VorbereitungId { get; set; }
    public string Test { get; set; }
    public string Kommentar { get; set; }
    public TextbausteineAnzeigen WasAnzeigen { get; set; }
}
public class Alarm
{
    public int Id { get; set; }
    public string Bezeichnung { get; set; }
    public string Kommentar { get; set; }
    public short ByteAlarm { get; set; }
    public short BitAlarm { get; set; }
    public short BitQuittiert { get; set; }
    public EaConfigError EaConfigError { get; set; }
    public DateTime AlarmKommt { get; set; }
    public DateTime AlarmGeht { get; set; }
    public bool BitmusterAlarmAlt { get; set; }
    public bool BitmusterAlarm { get; set; }
    public bool BitmusterQuittiert { get; set; }
    public bool BitmusterQuittiertAlt { get; set; }
    public StatusAlarm Status { get; set; } = StatusAlarm.AlarmKeiner;
}