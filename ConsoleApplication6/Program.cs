using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Security;
using System.Runtime.InteropServices;
namespace ConsoleApplication6
{

    class Program
    {

        static void Main(string[] args)
        {
            OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\PROG8140 Software Development Techniques\project\rough pjct\TestApp\TestApp\BusReservationSystem.accdb");
            OleDbDataAdapter da;
            DataTable dt = new DataTable();
            String userName = null;
            SecureString password = null;
            int input = 0;
            do
            {
                Console.WriteLine("Enter Username:");
                userName = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                password = getPassword();
                Console.WriteLine();
                da = new OleDbDataAdapter("select * from Login where Username='" + userName + "' and Password='" + SecureStringToString(password) + "'", cn);
                da.Fill(dt); 
                if (dt.Rows.Count <= 0)
                {
                    Console.WriteLine("Login failed");
                }
            } while (dt.Rows.Count <= 0);

            Console.WriteLine("Hi " + userName + " you successfully logged in. Here is your Menu ");

            do
            {
                Console.WriteLine("*******Menu*****");
                Console.WriteLine("1. User");
                Console.WriteLine("2. Route");
                Console.WriteLine("3. Bus");
                Console.WriteLine("4. Booking");
                Console.WriteLine("5. Exit");
                bool res = int.TryParse(Console.ReadLine(), out input);
                int option = 0;
                switch (input)
                {
                    case 1:
                        Console.WriteLine("------User Menu-------");                        
                        do{
                            User user = new User("erts","frts","Admin");
                            user.SaveUserToDB();
                            Console.WriteLine("1. Display all Users");
                            Console.WriteLine("2. Add User");
                            Console.WriteLine("3. Edit User");
                            Console.WriteLine("4. Delete User");
                            Console.WriteLine("5. go back to main menu");
                            int.TryParse(Console.ReadLine(), out option);
                        } while (option!=5);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                }
            } while (input != 5);

        }
        public static SecureString getPassword()
        {
            SecureString pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }
        public static String SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }
}
