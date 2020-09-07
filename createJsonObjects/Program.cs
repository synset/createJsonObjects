using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Web.Script.Serialization;

namespace createJsonObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student();
            string JSONresultStudent = JsonConvert.SerializeObject(stu);
            string studentPath = @"C:\jsonStudent\student.json";

            if (File.Exists(studentPath))
            {
                File.Delete(studentPath);
                using (StreamWriter tw = new StreamWriter(studentPath, true))
                {
                    tw.WriteLine(JSONresultStudent.ToString());
                    tw.Close();
                }
            }
            else if (!File.Exists(studentPath))
            {
                using (StreamWriter tw = new StreamWriter(@"C:\jsonStudent\student.json", true))
                {
                    tw.WriteLine(JSONresultStudent.ToString());
                    tw.Close();
                }
            }

            // reading JSON from a file
            JObject student = JObject.Parse(File.ReadAllText(studentPath));
            
            using (StreamReader file = File.OpenText(studentPath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject stud = (JObject)JToken.ReadFrom(reader);
            }

            //and saving it in a new file
            string studentPath2 = @"C:\jsonStudent\student2.json";

            if (File.Exists(studentPath2))
            {
                File.Delete(studentPath2);
                using (StreamWriter tw = new StreamWriter(studentPath2, true))
                {
                    tw.WriteLine(student.ToString());
                    tw.Close();
                }
            }
            else if (!File.Exists(studentPath2))
            {
                using (StreamWriter tw = new StreamWriter(@"C:\jsonStudent\student2.json", true))
                {
                    tw.WriteLine(student.ToString());
                    tw.Close();
                }
            }


            //
            //Another solution
            //

            //// read file into string and deserialize JSON to a type
            //Student newStudent = JsonConvert.DeserializeObject<Student>(File.ReadAllText(studentPath));
            //// deserialize JSON directly from a file
            //using (StreamReader file = File.OpenText(studentPath))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    Student newStud = (Student)serializer.Deserialize(file, typeof(Student));
            //}



            //
            // Employee code
            //

            //Employee emp = new Employee();
            //string JSONresult = JsonConvert.SerializeObject(emp);
            //string path = @"C:\json\employee.json";

            //if (File.Exists(path))
            //{
            //    File.Delete(path);
            //    using(StreamWriter tw = new StreamWriter(path, true))
            //    {
            //        tw.WriteLine(JSONresult.ToString());
            //        tw.Close();
            //    }
            //}
            //else if (!File.Exists(path))
            //{
            //    using (StreamWriter tw = new StreamWriter(path, true))
            //    {
            //        tw.WriteLine(JSONresult.ToString());
            //        tw.Close();
            //    }
        }
    }
}
