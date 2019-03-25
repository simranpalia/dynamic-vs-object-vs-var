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
            student.StudentId = d.StudentId;        //No parsing and run time binding
            student.StudentName = d.StudentName;    //No parsing and run time binding

            //Object
            Object objStudent = new { StudentId = 123, StudentName = "Simran" };
            Student studentNew = new Student();
            studentNew.StudentId = Convert.ToInt64(objStudent.GetType().GetProperty("StudentId").GetValue(objStudent).ToString());      //Explicit parsing using Reflection
            studentNew.StudentName = objStudent.GetType().GetProperty("StudentName").GetValue(objStudent).ToString();                   //Explicit parsing using Reflection

            //Var keyword
            var varObj = new { StudentId = 123, StudentName = "Simran" };
            Student studentVar = new Student();
            studentVar.StudentId = varObj.StudentId;        //Evaluate properties at compile time with intellisense
            studentVar.StudentName = varObj.StudentName;    //Evaluate properties at compile time with intellisense

            Console.ReadLine();
        }
    }
}
