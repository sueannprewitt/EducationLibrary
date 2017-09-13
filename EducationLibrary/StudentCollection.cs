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

        //get students so we need a method:
        public static StudentCollection Select()        {
            var connStr = @"Server=Student05;Database=DotNetDatabase;Trusted_Connection=yes;";
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
            return null;

    }
        public static bool Insert(Student student)
        {
            return false;
        }
        public static bool Update(Student student)
        {
            return false;
        }
        public static bool Delete (int id)
        {
            return false;
        }




    }
}
