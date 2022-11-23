using System;
namespace Ora2_Csharp.LINQ
{
    public class School
    {
        public static void RunExample()
        {
            var students = new List<Student>()
            {
                new Student
                {
                    Name = "Anita",
                    Age = 12,
                    Nationality = "Hungarian",
                    FavouriteSubjects = {"history", "math"}
                },
                new Student("Cyril",13,"Slovak"),
                new("Daniel",13,"Ukrainian") { FavouriteSubjects = {"math"}},
                new("Emil",12, "Slovak"),
                new("Feri",13),
                new("Gergő",13)
            };

            var olderThan13YearOldByNationality = students
                .Where(student => student.Age > 12)
                .GroupBy(student => student.Nationality)
                .Select(group => new { Nationality = group.Key, StudentNames = string.Join(", ", group.Select(student => student.Name)) });
        }
    }
}

