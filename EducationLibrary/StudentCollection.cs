using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationLibrary
{

    //StudentCollection is a list of Students:
   public class StudentCollection : List<Student> {

        private static string connStr = @"Server=Student05;Database=DotNetDatabase;Trusted_Connection=yes;";


        //get students so we need a method:
        public static StudentCollection Select()        {
           // var connStr = @"Server=Student05;Database=DotNetDatabase;Trusted_Connection=yes;";
            SqlConnection connection = new SqlConnection(connStr);
            connection.Open();
            if(connection.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connection did not open");
                return null;
            }
            StudentCollection students = new StudentCollection();
            var sql = "Select * from Student";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetInt32(reader.GetOrdinal("Id"));
                var firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                var lastName = reader.GetString(reader.GetOrdinal("LastName"));
                var address = reader.GetString(reader.GetOrdinal("Address"));
                var city = reader.GetString(reader.GetOrdinal("City"));
                var state = reader.GetString(reader.GetOrdinal("State"));
                var zipcode = reader.GetString(reader.GetOrdinal("Zipcode"));
                var phoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                var email= reader.GetString(reader.GetOrdinal("Email"));
                var birthday = reader.GetDateTime(reader.GetOrdinal("Birthday"));
                var majorid = -1; //means that the MajorId in the db is NULL
                if (!reader.GetValue(reader.GetOrdinal("Majorid")).Equals(DBNull.Value))
                {
                    majorid = reader.GetInt32(reader.GetOrdinal("MajorId"));
                }
                var sat = reader.GetInt32(reader.GetOrdinal("SAT"));
                var gpa = reader.GetDouble(reader.GetOrdinal("GPA"));

                Student student = new Student();
                student.Id = id;
                student.FirstName = firstName;
                student.LastName = lastName;
                student.Address = address;
                student.City = city;
                student.State = state;
                student.Zipcode = zipcode;
                student.PhoneNumber = phoneNumber;
                student.Email = email;
                student.Birthday = birthday;
                student.MajorId = majorid;
                student.SAT = sat;
                student.GPA = gpa;
                students.Add(student);

            }
            reader.Close();
            connection.Close();
            return students;
        }
    public static Student Select(int id)
    {
         //   var connStr = @"Server=Student05;Database=DotNetDatabase;Trusted_Connection=yes;";
            SqlConnection connection = new SqlConnection(connStr);
            connection.Open();
            if (connection.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connection did not open");
                return null;
            }
            StudentCollection students = new StudentCollection();
            var sql = $"Select * from Student where Id = {id}";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id2 = reader.GetInt32(reader.GetOrdinal("Id"));
                var firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                var lastName = reader.GetString(reader.GetOrdinal("LastName"));
                var address = reader.GetString(reader.GetOrdinal("Address"));
                var city = reader.GetString(reader.GetOrdinal("City"));
                var state = reader.GetString(reader.GetOrdinal("State"));
                var zipcode = reader.GetString(reader.GetOrdinal("Zipcode"));
                var phoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                var email = reader.GetString(reader.GetOrdinal("Email"));
                var birthday = reader.GetDateTime(reader.GetOrdinal("Birthday"));
                var majorid = -1; //means that the MajorId in the db is NULL
                if (!reader.GetValue(reader.GetOrdinal("Majorid")).Equals(DBNull.Value))
                {
                    majorid = reader.GetInt32(reader.GetOrdinal("MajorId"));
                }
                var sat = reader.GetInt32(reader.GetOrdinal("SAT"));
                var gpa = reader.GetDouble(reader.GetOrdinal("GPA"));

                Student student = new Student();
                student.Id = id2;
                student.FirstName = firstName;
                student.LastName = lastName;
                student.Address = address;
                student.City = city;
                student.State = state;
                student.Zipcode = zipcode;
                student.PhoneNumber = phoneNumber;
                student.Email = email;
                student.Birthday = birthday;
                student.MajorId = majorid;
                student.SAT = sat;
                student.GPA = gpa;
                students.Add(student);

            }
            reader.Close();
            connection.Close();
            if(students.Count == 0)
            {
                return null;
            }else
            {
                return students[0];
            }

    }
        public static bool Insert(Student student)
        {
           // var connStr = @"Server=Student05;Database=DotNetDatabase;Trusted_Connection=yes;";
            SqlConnection connection = new SqlConnection(connStr);
            connection.Open();
            if (connection.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connection did not open");
                return false;
            }
            var sql = $"Insert into Student (FirstName, LastName, Address, City, State, Zipcode," +
                $"PhoneNumber, Email, Birthday, MajorId, SAT, GPA)" +
                $"VALUES" +
                $"('{student.FirstName}', '{student.LastName}', '{student.Address}', " +
                $"'{student.City}', '{student.State}', '{student.Zipcode}', " +
                $"'{student.PhoneNumber}', '{student.Email}', '{student.Birthday}', " +
                $"{student.MajorId}, {student.SAT}, {student.GPA})";
            SqlCommand cmd = new SqlCommand(sql, connection);
            var recsAffected = cmd.ExecuteNonQuery();
            return (recsAffected == 1);
        }
        public static bool Update(Student student)
        {
           // var connStr = @"Server=Student05;Database=DotNetDatabase;Trusted_Connection=yes;";
            SqlConnection connection = new SqlConnection(connStr);
            connection.Open();
            if (connection.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connection did not open");
                return false;
            }

            var sql = $"UPDATE Student Set " +
                $"FirstName = '{student.FirstName}'," +
                $"LastName = '{student.LastName}'," +
                $"Address = '{student.Address}'," +
                $"City = '{student.City}'," +
                $"State = '{student.State}'," +
                $"Zipcode = '{student.Zipcode}'," +
                $"Birthday = '{student.Birthday}'," +
                $"PhoneNumber = '{student.PhoneNumber}'," +
                $"Email = '{student.Email}'," +
                $"MajorId = {student.MajorId}," +
                $"SAT = {student.SAT}," +
                $"GPA = {student.GPA} " +
                $"WHERE ID = {student.Id}";  //add where clause or you'd be updating your entire database!

            SqlCommand cmd = new SqlCommand(sql, connection);
            var recsAffected = cmd.ExecuteNonQuery();
            return (recsAffected == 1);


        }



        public static bool Delete (int id)
        {
           // var connStr = @"Server=Student05;Database=DotNetDatabase;Trusted_Connection=yes;";
            SqlConnection connection = new SqlConnection(connStr);
            connection.Open();
            if (connection.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connection did not open");
                return false;
            }

            var sql = $"DELETE from Student " +
                $"WHERE ID = {id}";  

            SqlCommand cmd = new SqlCommand(sql, connection);
            var recsAffected = cmd.ExecuteNonQuery();
            return (recsAffected == 1);

        }




    }
}
