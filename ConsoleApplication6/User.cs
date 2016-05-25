using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class User
    {
        private int userId=0;
        private string userName;
        private string password;
        private string level;
        public User(string userName, string password, string level)
        {
            this.userName = userName;
            this.password = password;
            this.level = level;
        }
        public User(int userId, string userName, string password, string level)
        {
            this.userId = userId;
            this.userName = userName;
            this.password = password;
            this.level = level;
        }
        public void EditUser(string userName, string password, string level)
        {
            this.userName = userName;
            this.password = password;
            this.level = level;
        }
        public void DisplayUser()
        {
            Console.WriteLine("{0} {1}  {2}", userId, userName, level);
        }
        public void SaveUserToDB()
        {
            string connetionString = null;
            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            string sql = null;
            connetionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\PROG8140 Software Development Techniques\project\rough pjct\TestApp\TestApp\BusReservationSystem.accdb";
            connection = new OleDbConnection(connetionString);
            if (userId == 0)
            {
                //insert query                
                sql = "insert into Login(UserName,Password) values('user1','password1','kkkkk')";
                try
                {
                    connection.Open();
                    oledbAdapter.InsertCommand = new OleDbCommand(sql, connection);
                    oledbAdapter.InsertCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    
                }
                finally
                {
                    connection.Close();
                }
            }               
            else{
                //update query
                sql = "insert into user values('user1','password1')";
                try
                {
                    connection.Open();
                    oledbAdapter.UpdateCommand = new OleDbCommand(sql, connection);
                    oledbAdapter.UpdateCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }
                finally
                {
                    connection.Close();
                }
            }            
        }
        public void DeleteUserFromDB()
        {
            string connetionString = null;
            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            string sql = null;
            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Your mdb filename;";
            connection = new OleDbConnection(connetionString);
            if (userId != 0)
            {
                
                //delete query
                sql = "delete from User where UserId=" + userId;
                try
                {
                    connection.Open();
                    oledbAdapter.DeleteCommand = new OleDbCommand(sql, connection);
                    oledbAdapter.DeleteCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }
                finally
                {
                    connection.Close();
                }
            }
                
        }
    }
}
