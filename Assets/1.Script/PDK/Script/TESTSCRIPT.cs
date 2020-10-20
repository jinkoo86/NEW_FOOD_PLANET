using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class TESTSCRIPT : MonoBehaviour {

    void Start() {
        {
            string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/DB.db"; //Path to database.
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.

            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT *" + "FROM MyEquip";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read()) {
                string EquipName = reader.GetString(0);
                int EquipLevel = reader.GetInt32(1);
                //ID,NAME,AGE,ADDRESS,SALARY
                Debug.Log("EquipName= " + EquipName + "  EquipLevel =" + EquipLevel);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }

    // Update is called once per frame
    void Update() {
    }
}
