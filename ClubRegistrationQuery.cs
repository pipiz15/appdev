using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07LAB
{
    internal class ClubRegistrationQuery
    {
        private SqlConnection sqlConnect;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlAdapter;

        public DataTable dataTable;
        public BindingSource bindingSource;

        private string connectionString;

        public ClubRegistrationQuery()
        {
            connectionString = @"Data Source=JOMA\SQLEXPRESS;Initial Catalog=ClubDB;Integrated Security=True;";
            sqlConnect = new SqlConnection(connectionString);
            dataTable = new DataTable();
            bindingSource = new BindingSource();
        }

        public bool DisplayList()
        {
            string query = "SELECT StudentId, FirstName, MiddleName, LastName, Age, Gender, Program FROM ClubMembers";
            sqlAdapter = new SqlDataAdapter(query, sqlConnect);

            dataTable.Clear();
            sqlAdapter.Fill(dataTable);
            bindingSource.DataSource = dataTable;

            return true;
        }

        public bool RegisterStudent(int ID, long StudentID, string FirstName, string MiddleName,
                                    string LastName, int Age, string Gender, string Program)
        {
            sqlCommand = new SqlCommand(
                "INSERT INTO ClubMembers VALUES(@ID, @StudentID, @FirstName, @MiddleName, @LastName, @Age, @Gender, @Program)",
                sqlConnect);

            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            sqlCommand.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = StudentID;
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
            sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
            sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = Program;

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();

            return true;
        }

        public bool UpdateMember(long StudentID, string FirstName, string MiddleName,
                                 string LastName, int Age, string Gender, string Program)
        {
            sqlCommand = new SqlCommand(
                "UPDATE ClubMembers SET FirstName=@FN, MiddleName=@MN, LastName=@LN, Age=@Age, Gender=@Gender, Program=@Program " +
                "WHERE StudentId=@StudentID",
                sqlConnect);

            sqlCommand.Parameters.Add("@FN", SqlDbType.VarChar).Value = FirstName;
            sqlCommand.Parameters.Add("@MN", SqlDbType.VarChar).Value = MiddleName;
            sqlCommand.Parameters.Add("@LN", SqlDbType.VarChar).Value = LastName;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
            sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = Program;
            sqlCommand.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = StudentID;

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();

            return true;
        }
    }
}
