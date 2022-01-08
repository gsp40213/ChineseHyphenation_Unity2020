using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public abstract class SegmentationSymbol
{
    public abstract List<Match> wrap(string str);

    public abstract string grammarCombinationModule(string speech1, string speech2);

    public abstract bool isEnglish(string str);

    public abstract bool isNumberic(string str);

    public abstract List<Match> symol(string str);

}
