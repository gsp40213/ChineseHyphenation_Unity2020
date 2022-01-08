using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MySQLFunction : MySQL
{
    public MySQLFunction(string host, string id, string password, string dataBase, string port) : 
        base(host, id, password, dataBase, port) { }

    public override DataSet getDataSet(string sqlString)
    {
        DataSet ds = new DataSet();

        try
        {
            MySqlDataAdapter da = new MySqlDataAdapter(sqlString, mySqlConnection);
        }
        catch (Exception e)
        {
            throw new Exception("SQL:" + sqlString + "\n");
        }

        return ds;
    }

    public override string inquire(string dataBaseTitle, int numberingType, string message)
    {
        string sqlText = "select * from " + dataBaseTitle + " where Message='" + message + "'";
        string str = "";

        MySqlCommand cmd = new MySqlCommand(sqlText, mySqlConnection);
        MySqlDataReader data = cmd.ExecuteReader();

        while (data.Read())
        {
            try
            {
                str = data[numberingType].ToString();
            }

            finally { }
        }

        data.Close();

        return str;
    }

    public override void openDatabse()
    {
        string connectionString = string.Format("Server = {0}; Database = {1}; UserID = {2}; Password = {3}; Port = {4};", host, dataBase, id, password, port);
        opensqlConnection(connectionString);
    }

    public override void query(string query)
    {
        IDbCommand dbcommand = mySqlConnection.CreateCommand();
        dbcommand.CommandText = query;
        IDataReader reader = dbcommand.ExecuteReader();
        reader.Close();
        reader = null;
        dbcommand.Dispose();
        dbcommand = null;
    }

    public override string opensqlConnection(string connection)
    {    
        try
        {
            mySqlConnection = new MySqlConnection(connection);
            mySqlConnection.Open();
            return mySqlConnection.ServerVersion;
        }
        catch
        {
            return "無法連結資料庫";
        }
    }

    public override string stringUtf8(string message)
    {
        throw new System.NotImplementedException();
    }

    public override void closeSqlConnection()
    {
        try
        {
            mySqlConnection.Close();
            mySqlConnection.Dispose();
            mySqlConnection = null;
        }
        catch { }
    }
}
