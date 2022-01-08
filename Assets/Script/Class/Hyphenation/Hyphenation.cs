using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Hyphenation
{
    protected List<string> ward;
    protected string dataBaseTitlle;

    public Hyphenation(List<string>ward, string dataBaseTitlle)
    {
        this.ward = ward;
        this.dataBaseTitlle = dataBaseTitlle;
    }

    public abstract List<string> reverse(MySQLFunction mySQLFunction);
    public abstract List<string> forward(MySQLFunction mySQLFunction);

    public abstract List<string> speech(MySQLFunction mySQLFunction);
}
