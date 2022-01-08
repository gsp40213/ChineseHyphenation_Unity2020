/********************************************
* 程式說明:
* ※ MySql 套件下載 https://dev.mysql.com/downloads/connector/net/1.0.html
* ※ MySql 套件 載點1: https://drive.google.com/file/d/1guMWQB7k1WwmA_HiBw4azVlTBN_wQYM0/view
* ※ MySql 套件 載點1: https://pan.baidu.com/s/1_TSvPHUZrACV1rsYkjAB0w
* 因由 Unity 連結 Mysql 需倚賴 PHP 方式來做溝通
* 此程式只適用於 OS: windows 7 - 10 (微軟)
********************************************/

using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System;


public abstract class MySQL
{
    protected string host;
    protected string id;
    protected string password;
    protected string dataBase;
    protected string port;
    protected MySqlConnection mySqlConnection = new MySqlConnection();

    public MySQL(string host, string id, string password, string dataBase, string port)
    {
        this.host = host;
        this.id = id;
        this.password = password;
        this.dataBase = dataBase;
        this.port = port;
    }

    public abstract string opensqlConnection(string connection);

    public abstract void query(string query);
    public abstract DataSet getDataSet(string sqlString);

    public abstract string stringUtf8(string message);

    public abstract string inquire(string dataBaseTitle, int numberingType, string message);

    public abstract void openDatabse();

    public abstract void closeSqlConnection();
}
