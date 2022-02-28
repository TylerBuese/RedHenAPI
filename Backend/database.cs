using System;
using System.Data.SQLite;
using RedHenAPI.Models;
using System.IO;
using System.Collections.Generic;

namespace RedHenAPI.Backend
{
    public class database
    {
        public SQLiteConnection db_conn = new SQLiteConnection(String.Format("Data source={0}; version=3", "Account.db"));
        public void CreateDatabaseFile()
        {
            SQLiteConnection.CreateFile("Account.db");
            CreateTables();
        }

        public void AddParent(AccountModel account)
        {
            db_conn.Open();
            string sql = 
@$"INSERT INTO Account (
Password,
FirstName,
LastName,
Email,
IsParent,
CareGiverID,
CareGiverStreet,
CareGiverCity,
CareGIverCounty,
CareGiverState,
CareGiverNumOfSlotsAvailable,
CareGiverEmail,
CareGiverPhoneNumber) VALUES (
'{account.Password}', '{account.FirstName}', '{account.LastName}', '{account.Email}', {account.isParent}, '{account.CareGiverID}', '{account.CareGiverStreet}', '{account.CareGiverCity}', '{account.CareGiverCounty}', '{account.CareGiverState}', {account.CareGiverNumOfSlotsAvailable}, '{account.Email}', '{account.CareGiverPhoneNumber}')";
            SQLiteCommand command = new SQLiteCommand(sql, db_conn);
            command.ExecuteNonQuery();

        }

        private void CreateTables()
        {
            db_conn.Open();
            var files = Directory.GetFiles(".\\SqlScriptsInit");
            foreach (var file in files)
            {
                var sql = File.ReadAllText(file);
                SQLiteCommand command = new SQLiteCommand(sql, db_conn);
                command.ExecuteNonQuery();
            }
        }

        public AccountModel GetParent(int accountNumber)
        {
            var account = new AccountModel();
            var sql = String.Format("SELECT * FROM Account WHERE AccountNumber={0}", accountNumber);
            db_conn.Open();
            {
                using (SQLiteCommand command = new SQLiteCommand(db_conn))
                {
                    command.CommandText = sql;
                    command.CommandType = System.Data.CommandType.Text;
                    SQLiteDataReader r = command.ExecuteReader();
                    while (r.Read())
                    {
                        account.AccountNumber = Convert.ToInt16(r["AccountNumber"]);
                        account.FirstName = Convert.ToString(r["FirstName"]);
                        account.LastName = Convert.ToString(r["LastName"]);
                        account.Password = Convert.ToString(r["Password"]);
                        account.Email = Convert.ToString(r["Email"]);
                        account.isParent = Convert.ToBoolean(r["IsParent"]);
                        account.CareGiverEmail = Convert.ToString(r["CareGiverEmail"]);
                        account.CareGiverID = Convert.ToString(r["CareGiverID"]);
                        account.CareGiverCity = Convert.ToString(r["CareGiverCity"]);
                        account.CareGiverCounty = Convert.ToString(r["CareGiverCounty"]);
                        account.CareGiverState = Convert.ToString(r["CareGiverState"]);
                        account.CareGiverEmail = Convert.ToString(r["CareGiverEmail"]);
                        account.CareGiverNumOfSlotsAvailable = Convert.ToInt16(r["CareGiverNumOfSlotsAvailable"]);
                        account.CareGiverPhoneNumber = Convert.ToString(r["CareGiverPhoneNumber"]);
                        account.CareGiverStreet = Convert.ToString(r["CareGiverPhoneNumber"]);
                    }


                }
            }
            db_conn.Close();

            return account;

        }
    }
}
