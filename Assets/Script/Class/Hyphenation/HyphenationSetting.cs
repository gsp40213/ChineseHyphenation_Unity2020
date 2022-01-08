using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyphenationSetting : Hyphenation
{
    private int forwardWardNumber = 0;
    private int reverceWardNumber = 0;

    public HyphenationSetting(List<string> ward, string dataBaseTitlle) : base(ward, dataBaseTitlle) { }

    // 正向
    public override List<string> forward(MySQLFunction mySQLFunction)
    {
        List<string> list = new List<string>();
        list.Clear();

        forwardWardNumber = 0;

        while (ward.Count >= 1)
        {
            if (forwardWardNumber < ward.Count)
            {
                if (ward[forwardWardNumber] != "")
                {
                    for (int y = 0; y <= ward[forwardWardNumber].Length; y++)
                    {
                        string ForwardMessage = ward[forwardWardNumber].Substring(0, ward[forwardWardNumber].Length - y);
                        if (ForwardMessage == mySQLFunction.inquire(dataBaseTitlle, 0, ForwardMessage))
                        {
                            list.Add(ForwardMessage);
                            ward[forwardWardNumber] = ward[forwardWardNumber].Remove(0, ForwardMessage.Length);
                        }
                        else if (ForwardMessage.Length == 1 && ward[forwardWardNumber] != mySQLFunction.inquire(dataBaseTitlle, 0, ForwardMessage))
                        {
                            list.Add(ForwardMessage);
                            ward[forwardWardNumber] = ward[forwardWardNumber].Remove(0, ForwardMessage.Length);
                        }
                    }
                }
                else
                    forwardWardNumber += 1;
            }
            else ward.Clear();
        }

        return list;
    }

    // 反向
    public override List<string> reverse(MySQLFunction mySQLFunction)
    {
        List<string> list = new List<string>();
        list.Clear();

        reverceWardNumber = 0;

        while (ward.Count >= 1)
        {
            if (reverceWardNumber < ward.Count)
            {
                if (ward[reverceWardNumber] != "")
                {
                    for (int y = 0; y <= ward[reverceWardNumber].Length; y++)
                    {
                        string ReverseMessage = ward[reverceWardNumber].Substring(y);

                        if (ReverseMessage == mySQLFunction.inquire(dataBaseTitlle, 0, ReverseMessage))
                        {
                            list.Add(ReverseMessage);
                            ward[reverceWardNumber] = ward[reverceWardNumber].Substring(0, ward[reverceWardNumber].Length - ReverseMessage.Length);
                        }
                        else if (ReverseMessage.Length <= 1 && ReverseMessage != mySQLFunction.inquire(dataBaseTitlle, 0, ReverseMessage))
                        {
                            list.Add(ReverseMessage);
                            ward[reverceWardNumber] = ward[reverceWardNumber].Substring(0, ward[reverceWardNumber].Length - ReverseMessage.Length);
                        }
                    }
                }
                else
                    reverceWardNumber += 1;
            }
            else ward.Clear();
        }

        return list;
    }

    // 詞性
    public override List<string> speech(MySQLFunction mySQLFunction)
    {
        List<string> list = new List<string>();

        foreach (string str in ward)
        {
            if (mySQLFunction.inquire(dataBaseTitlle, 1, str) != "")
                list.Add(mySQLFunction.inquire(dataBaseTitlle, 1, str));

            else list.Add("?");
        }

        return list;
    }
}