using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;
public class DBAccess : MonoBehaviour
{
    public Text text0;
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;   

    void AccessDB()
    {
        string s;
        string ItemID = "";
        string ItemName = "";
        int ItemPrice = 0;

        string filepath = string.Empty;

        if (Application.platform == RuntimePlatform.Android)//실행플랫폼이 안드로이드일 경우
        {
            filepath = Application.persistentDataPath + "/DB.db";
            text0.text = "RuntimePlatform.Android 실행";
            if (!File.Exists(filepath))
            {
/*              UnityWebRequest unityWebRequest = UnityWebRequest.Get("jar:file://" + Application.dataPath + "!/assets/ItemDB.db");
                unityWebRequest.downloadedBytes.ToString();
                yield return unityWebRequest.SendWebRequest().isDone;
                File.WriteAllBytes(filepath, unityWebRequest.downloadHandler.data);*/

                //
                WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/DB.db");
                text1.text = "경로가!/assets/DB.db이게 맞냐 ";//여기까지는 출력이 된다
                loadDB.bytesDownloaded.ToString();
                while (!loadDB.isDone) { }
                File.WriteAllBytes(filepath, loadDB.bytes);
                //

            }
        }
        else
        {
            filepath = Application.dataPath + "/StreamingAssets/DB.db";
            if (!File.Exists(filepath))
            {
                File.Copy(Application.streamingAssetsPath + "/DB.db", filepath);
                print(filepath);
                text0.text = "윈도우 환경 DB.db 실행";
            }
        }
        //print("CopyDB()작동");
        string temp_filepath = "URI=file:" + filepath;
        try
        {
            text2.text = "try문 실행";
            SqliteConnection con = new SqliteConnection(temp_filepath);
            con.Open();
            //SqliteCommand cmd = con.CreateCommand();
            //SqliteCommand cmd = new SqliteCommand();//지웠는데 왜 되냐
            //cmd.Connection = con;//지웠는데 왜 되냐
            //con.Open();
            print("오픈성공?");
            text3.text = "오픈성공";
            //
            IDbCommand dbcmd = con.CreateCommand();
            string sqlQuery = "SELECT ItemID, ItemName, ItemPrice FROM Item";

            dbcmd.CommandText = sqlQuery;

            IDataReader reader = dbcmd.ExecuteReader();

            while (reader.Read())
            {
                ItemID = reader.GetString(0);
                ItemName = reader.GetString(1);
                ItemPrice = reader.GetInt32(2);

                Debug.Log("ItemID: " + ItemID + "ItemName: " + ItemName);
                text4.text = ItemID +" "+ ItemName+ " " + ItemPrice;
            }
            //
            if (con.State == ConnectionState.Open)
            {
                s = "OK";
                //text.text = "디비 실행" + s;
                //
                /*IDbCommand dbcmd = con.CreateCommand();
                string sqlQuery = "SELECT ItemID, ItemName FROM Item";
                dbcmd.CommandText = sqlQuery;

                IDataReader reader = dbcmd.ExecuteReader();

                while (reader.Read())
                {
                    ItemID = reader.GetString(0);
                    ItemName = reader.GetString(1);

                    Debug.Log("ItemID: " + ItemID + "ItemName: " + ItemName);
                    text.text = ItemID + "\n" + ItemName;
                }*/
                //
            }
            else
            {
                s = "ERR";
                //textConn.text = s;
            }
            con.Clone();
        }
        catch (Exception e)
        {
            s = e.ToString();
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        AccessDB();

    }
    // Update is called once per frame
    void Update()
    {

    }

    /*public static string TestConnection()
    {
        string s;
        try
        {
            SqliteConnection con = new SqliteConnection(GetConStr());
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = con;
            con.Open();
            if(con.State == ConnectionState.Open)
            {
                s = "OK";
                //
                IDbCommand dbcmd = con.CreateCommand();
                string sqlQuery = "SELECT ItemID, ItemName FROM Item";
                dbcmd.CommandText = sqlQuery;

                IDataReader reader = dbcmd.ExecuteReader();

                while (reader.Read())
                {
                    string ItemID = reader.GetString(0);
                    string ItemName = reader.GetString(1);

                    Debug.Log("ItemID: " + ItemID + "ItemName: " + ItemName);
                }
                //
            }
            else
            {
                s = "ERR";
            }
            con.Clone();
        }catch(Exception e)
        {
            s = e.ToString();
        }
        print("TestConnection()작동");

        return s;
    }
    public static string GetConStr()
    {
        string strCon = "";
        if(Application.platform == RuntimePlatform.Android)
        {
            strCon = "URI=file:" + Application.dataPath + "/DB/ItemDB.db";
        }
        else
        {
            strCon = "URI=file:" + Application.dataPath + "/DB/ItemDB.db";
        }
        return strCon;
    }
    void CopyDB()
    {
        string filepath = string.Empty;
        if(Application.platform == RuntimePlatform.Android)
        {
            filepath = Application.persistentDataPath + "/DB/ItemDB.db";
            if (!File.Exists(filepath))
            {
                WWW loadDB =  new WWW("jar:file://"+Application.dataPath + "/DB/ItemDB.db");
                loadDB.bytesDownloaded.ToString();
                while (!loadDB.isDone) { }
                File.WriteAllBytes(filepath, loadDB.bytes);
            }
        }
        else
        {
            filepath = Application.dataPath + "/DB/ItemDB.db";
            if (!File.Exists(filepath))
            {
                File.Copy(Application.streamingAssetsPath + "/DB/ItemDB.db", filepath);
            }
        }
        print("CopyDB()작동");
    }
    // Start is called before the first frame update
    void Start()
    {
        CopyDB();
        GetConStr();
        TestConnection();

        *//*string conn = "URI=file:" + Application.dataPath + "/DB/ItemDB.db";//피씨만 될듯?

        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        print("오픈");

        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT ItemID, ItemName FROM Item";
        dbcmd.CommandText = sqlQuery;

        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            string ItemID = reader.GetString(0);
            string ItemName = reader.GetString(1);

            Debug.Log("ItemID: "+ ItemID + "ItemName: "+ ItemName);
        }

        //닫기
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;*//*
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
