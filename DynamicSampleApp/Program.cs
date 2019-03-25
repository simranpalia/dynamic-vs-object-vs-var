using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicSampleApp
{
    class Program
    {
        public class Student
        {
            public long StudentId { get; set; }

            public string StudentName { get; set; }

        }

        static void Main(string[] args)
        {
            //Dynamic
            dynamic d = null;

            d = new { StudentId = 123, StudentName = "Simran" };

            Student student = new Student();
            student.StudentId = d.StudentId;
            student.StudentName = d.StudentName;

            //Object
            Object objStudent = new { StudentId = 123, StudentName = "Simran" };
            Student studentNew = new Student();
            studentNew.StudentId = Convert.ToInt64(objStudent.GetType().GetProperty("StudentId").GetValue(objStudent).ToString());
            studentNew.StudentName = objStudent.GetType().GetProperty("StudentName").GetValue(objStudent).ToString();

            //Var keyword
            var varObj = new { StudentId = 123, StudentName = "Simran" };
            Student studentVar = new Student();
            studentVar.StudentId = varObj.StudentId;//Evaluate properties at compile time
            studentVar.StudentName = varObj.StudentName;//Evaluate properties at compile time



            Console.ReadLine();
        }
    }
}
