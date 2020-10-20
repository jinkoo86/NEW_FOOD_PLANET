using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class LoadDB : MonoBehaviour
{
    GameObject textMoney;

    // Start is called before the first frame update
    void Start()
    {
        textMoney = GameObject.Find("Money_Text");
        DB();
    }
    public void DB() { 
        string filepath = string.Empty;
        if (Application.platform == RuntimePlatform.Android)//실행플랫폼이 안드로이드일 경우
        {
            //안드로이드 일 경우
            filepath = Application.persistentDataPath + "/DB.db";
            if (!File.Exists(filepath))
            {
                WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/DB.db");
                loadDB.bytesDownloaded.ToString();
                while (!loadDB.isDone) { }
                File.WriteAllBytes(filepath, loadDB.bytes);
            }
        }
        else
        {
            //윈도우 일 경우
            filepath = Application.dataPath + "/StreamingAssets/DB.db";
            if (!File.Exists(filepath))
            {
                File.Copy(Application.streamingAssetsPath + "/DB.db", filepath);
                //print(filepath);
            }
        }
        try
        {
            //filepath = Application.persistentDataPath + "/DB.db";
            string temp_path = "URI=file:" + filepath;
            SqliteConnection con = new SqliteConnection(temp_path);
            con.Open();

            print("업데이트 쪽 오픈성공");

            IDbCommand dbcmd = con.CreateCommand();

            string sqlQuery2 = "UPDATE Money SET MyMoney = 100";
            string sqlQuery = "SELECT MyMoney, DailyMoney FROM Money";

            dbcmd.CommandText = sqlQuery2;
            

            print("커맨드 텍스트 성공");
            IDataReader reader = dbcmd.ExecuteReader();
            print("reader 변수대입 성공");
            print(reader);
            while (reader.Read())
            {
                print("1LoadDB while진입 성공");
                int myMoney = reader.GetInt32(0);
                int dailyMoney = reader.GetInt32(1);


                Debug.Log("myMoney: " + myMoney + "dailyMoney: " + dailyMoney);
            }
            reader.Close();
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                print("2LoadDB while진입 성공");
                int myMoney = reader.GetInt32(0);
                int dailyMoney = reader.GetInt32(1);


                Debug.Log("myMoney: " + myMoney + "dailyMoney: " + dailyMoney);
            }
            //
            if (con.State == ConnectionState.Open)
            {
                print("OK");
            }
            else
            {
                print("ERR");
            }
            //con.Clone();
            con.Close();
        }
        catch (Exception e)
        {
            print(e);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
