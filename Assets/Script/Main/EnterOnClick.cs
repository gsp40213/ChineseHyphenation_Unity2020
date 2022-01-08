using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class EnterOnClick : OnClick
{
    Symbol symbol = new Symbol();

    List<string> reverseSentence = new List<string>();
    List<string> forwardSentence = new List<string>();

    List<string> reverse = new List<string>();
    List<string> forward = new List<string>();
    List<string> forward_speech = new List<string>();
    List<string> reverse_speech = new List<string>();

    HyphenationSetting forwardStatus;
    HyphenationSetting reverseStatus;
    HyphenationSetting speechStatus_forward;
    HyphenationSetting speechStatus_reverse;

    private string databaseTitile = "glossary";

    private string hort = "127.0.0.1";
    private string database = "corpus2";
    private string id = "gsp40214";
    private string passward = "123456";
    private string port = "3306";

    MySQLFunction forwardStatus_sql;
    MySQLFunction reverseStatus_sql;
    MySQLFunction speechStatus_forward_sql;
    MySQLFunction speechStatus_reverse_sql;

    public static string RESULT;

    public void onClick()
    {

        forwardStatus_sql = new MySQLFunction(hort, id, passward, database, port);
        reverseStatus_sql = new MySQLFunction(hort, id, passward, database, port);
        speechStatus_forward_sql = new MySQLFunction(hort, id, passward, database, port);
        speechStatus_reverse_sql = new MySQLFunction(hort, id, passward, database, port); 

        foreach (Match match in symbol.wrap(Layout_Main.USER_INPUT_MESSAGE))
        {
            reverseSentence.Add(match.ToString());
            forwardSentence.Add(match.ToString());
        }

        forwardStatus_sql.openDatabse();
        reverseStatus_sql.openDatabse();
        speechStatus_forward_sql.openDatabse();
        speechStatus_reverse_sql.openDatabse();

        RESULT = result();
    }

    public string result()
    {
        string logeForwad = "";
        string logeReverse = "";

        forwardStatus = new HyphenationSetting(forwardSentence, databaseTitile);
        reverseStatus = new HyphenationSetting(reverseSentence, databaseTitile);  

        reverse = reverseStatus.reverse(forwardStatus_sql);
        forward = forwardStatus.forward(reverseStatus_sql);

        speechStatus_forward = new HyphenationSetting(forward, databaseTitile);
        speechStatus_reverse = new HyphenationSetting(reverse, databaseTitile);

        forward_speech = speechStatus_forward.speech(speechStatus_forward_sql); 
        reverse_speech = speechStatus_reverse.speech(speechStatus_reverse_sql);

        for (int x = 0; x < forward.Count; x++)
            logeForwad += forward[x] + "" +
                "(" + forward_speech[x] + ")";

        for (int x = reverse.Count - 1; x >= 0; x--)
            logeReverse += reverse[x] + "" +
                "(" + reverse_speech[x] + ")";

        return "正向長詞結果 : \n" + logeForwad + "\n\n" + "反向長詞結果 : \n" + logeReverse + "\n\n";
    }

    // 解構子
    ~EnterOnClick()
    {
        Debug.Log("關閉資料庫");

        forwardStatus_sql.closeSqlConnection();
        reverseStatus_sql.closeSqlConnection();
        speechStatus_forward_sql.closeSqlConnection();
        speechStatus_reverse_sql.closeSqlConnection();
    }
}
