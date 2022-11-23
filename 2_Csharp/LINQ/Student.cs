using System;
namespace Ora2_Csharp.LINQ
{
    public class Student
    {
        public string Name { get; init; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public List<string> FavouriteSubjects { get; set; } = new List<string>();

        public Student() { }

        public Student(string name, int age, string nationality = "Hungarian")
        {
            Name = name;
            Age = age;
            Nationality = nationality;
        }
    }
}
