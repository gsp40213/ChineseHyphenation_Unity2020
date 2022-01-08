using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Symbol : SegmentationSymbol
{
    public override string grammarCombinationModule(string speech1, string speech2)
    {
        string grmmar = "";

        if (speech1.Equals("A") && speech2.Equals("T") || speech1.Equals("A") && speech2.Equals("N") || speech1.Equals("A") && speech2.Equals("Nv") || speech1.Equals("A") && speech2.Equals("P")) grmmar = "A";
        else if (speech1.Equals("C") && speech2.Equals("A") || speech1.Equals("C") && speech2.Equals("N") || speech1.Equals("C") && speech2.Equals("DET") || speech1.Equals("C") && speech2.Equals("Nv") || speech1.Equals("C") && speech2.Equals("Vi") || speech1.Equals("C") && speech2.Equals("Vt")) grmmar = "C";
        else if (speech1.Equals("ADV") && speech2.Equals("A") || speech1.Equals("ADV") && speech2.Equals("ADV") || speech1.Equals("ADV") && speech2.Equals("Nv") || speech1.Equals("ADV") && speech2.Equals("Vi") || speech1.Equals("ADV") && speech2.Equals("Vt")) grmmar = "ADV";
        else if (speech1.Equals("ASP") && speech2.Equals("Nv") || speech1.Equals("ASP") && speech2.Equals("Vi") || speech1.Equals("ASP") && speech2.Equals("Vt")) grmmar = "ASP";
        else if (speech1.Equals("N") && speech2.Equals("Vi") || speech1.Equals("N") && speech2.Equals("Vt") || speech1.Equals("N") && speech2.Equals("T") || speech1.Equals("N") && speech2.Equals("C") || speech1.Equals("N") && speech2.Equals("POST") || speech1.Equals("N") && speech2.Equals("A") || speech1.Equals("N") && speech2.Equals("N") || speech1.Equals("N") && speech2.Equals("M") || speech1.Equals("N") && speech2.Equals("Nv")) grmmar = "N";
        else if (speech1.Equals("DET") && speech2.Equals("N") || speech1.Equals("DET") && speech2.Equals("Nv") || speech1.Equals("DET") && speech2.Equals("Vi") || speech1.Equals("DET") && speech2.Equals("Vt")) grmmar = "DET";
        else if (speech1.Equals("M") && speech2.Equals("T") || speech1.Equals("M") && speech2.Equals("N") || speech1.Equals("M") && speech2.Equals("Nv")) grmmar = "M";
        else if (speech1.Equals("P") && speech2.Equals("N") || speech1.Equals("P") && speech2.Equals("Nv") && speech1.Equals("P") && speech2.Equals("Vi") && speech1.Equals("P") && speech2.Equals("Vt")) grmmar = "P";
        else if (speech1.Equals("Vi") && speech2.Equals("Vt") || speech1.Equals("Vi") && speech2.Equals("N") && speech1.Equals("Vi") && speech2.Equals("ADV")) grmmar = "Vi";
        else if (speech1.Equals("Vt") && speech2.Equals("N") || speech1.Equals("Vt") && speech2.Equals("Vi") || speech1.Equals("Vt") && speech2.Equals("Adv") || speech1.Equals("Vt") && speech2.Equals("Vt")) grmmar = "Vt";
        else if (speech1.Equals("POST") && speech2.Equals("N") || speech1.Equals("POST") && speech2.Equals("A") || speech1.Equals("POST") && speech2.Equals("POST") || speech1.Equals("POST") && speech2.Equals("DET") || speech1.Equals("POST") && speech2.Equals("Nv") || speech1.Equals("POST") && speech2.Equals("Vi") || speech1.Equals("POST") && speech2.Equals("Vt")) grmmar = "POST";
        else if (speech1.Equals("A") && speech2.Equals("A")) grmmar = "A";
        else if (speech1.Equals("C") && speech2.Equals("C")) grmmar = "C";
        else if (speech1.Equals("ADV") && speech2.Equals("ADV")) grmmar = "ADV";
        else if (speech1.Equals("ASP") && speech2.Equals("ASP")) grmmar = "ASP";
        else if (speech1.Equals("N") && speech2.Equals("N")) grmmar = "N";
        else if (speech1.Equals("DET") && speech2.Equals("DET")) grmmar = "DET";
        else if (speech1.Equals("M") && speech2.Equals("M")) grmmar = "M";
        else if (speech1.Equals("P") && speech2.Equals("P")) grmmar = "P";
        else if (speech1.Equals("Vi") && speech2.Equals("Vi")) grmmar = "Vi";
        else if (speech1.Equals("Vt") && speech2.Equals("Vt")) grmmar = "Vt";
        else if (speech1.Equals("Vt") && speech2.Equals("Vt")) grmmar = "Vt";

        return grmmar;
    }

    public override bool isEnglish(string str)
    {
        Regex reg1 = new Regex(@"^[A-Za-z0-9]+$");
        return reg1.IsMatch(str);
    }

    public override bool isNumberic(string str)
    {
        try
        {
            int i = Convert.ToInt32(str);
            return true;

        }
        catch (Exception e)
        {
            return false;
        }
    }

    public override List<Match> symol(string str)
    {
        string warpSpeciaSybbol = @"，+。+？+！";

        List<Match> match = new List<Match>();

        match.Clear();

        MatchCollection splitResult = Regex.Matches(str, warpSpeciaSybbol, RegexOptions.IgnoreCase);
        foreach (Match test in splitResult)
            match.Add(test);

        return match;
    }

    public override List<Match> wrap(string str)
    {
        string warpSpeciaSybbol = @"[^+/d{，+。+？+！+}]+[a-zA-Z+0-9+\u4e00-\u9fa5+s ]";
        List<Match> match = new List<Match>();

        match.Clear();

        MatchCollection splitResult = Regex.Matches(str, warpSpeciaSybbol, RegexOptions.IgnoreCase);
        foreach (Match test in splitResult)
            match.Add(test);

        return match;

    }
}
