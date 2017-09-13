using EducationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducationLibrary
{
    class Program
    {
        void Run()
        {
            StudentCollection students = StudentCollection.Select(); //calling StudentCollection Select method

            Student Susie = StudentCollection.Select(5);
            Student doesNotExist = StudentCollection.Select(0); //should return null
            Student stud = new Student();
            stud.FirstName = "Test";
            stud.LastName = "Test";
            stud.Address = "Test";
            stud.City = "Test";
            stud.State = "OH";
            stud.Zipcode = "Test";
            stud.Birthday = new DateTime(2017, 9, 13);
            stud.PhoneNumber = "5135551212";
            stud.Email = "a@b.c";
            stud.MajorId = 6;
            stud.SAT = 1600;
            stud.GPA = 5.0;
            bool rc = StudentCollection.Insert(stud);

        }
        static void Main(string[] args)
        {
            new Program().Run();
        }
    }
}
