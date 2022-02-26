using System;
using System.Data.SQLite;
using RedHenAPI.Models;
using System.IO;
namespace RedHenAPI.Backend
{
    public class database
    {
        public SQLiteConnection db_conn = new SQLiteConnection(String.Format("Data source={0}; version=3", "Account.db"));
        public void CreateDatabaseFile()
        {
            SQLiteConnection.CreateFile("Account.db");
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
'{account.Password}', '{account.FirstName}', '{account.LastName}', '{account.Email}', {account.isParent}, '{account.CareGiverID}', '{account.CareGiverStreet}', '{account.CareGiverCity}', '{account.CarGiverCounty}', '{account.CareGiverState}', {account.CareGiverNumOfSlotsAvailable}, '{account.Email}', '{account.CareGiverPhoneNumber}')";
            SQLiteCommand command = new SQLiteCommand(sql, db_conn);
            command.ExecuteNonQuery();

        }

        private void CreateParentTable()
        {
            db_conn.Open();
            var files = Directory.GetFiles(".\\SqlScriptsInit");
            foreach (var file in files)
            {
                //var sql = 
            }
        }
    }
}
