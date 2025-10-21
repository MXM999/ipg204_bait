using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp133
{
    public class Student : Person
    {
        public double GPA { get; set; }
        public string Major { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime GraduationDate { get; set; }
        public int CurrentYear { get; set; }
        public string[] Courses { get; set; }
        public bool HasScholarship { get; set; }

        public Student(int id, string firstName, string lastName, double gpa, string major,
                      DateTime birthDate, DateTime regDate, int currentYear, bool scholarship)
                      : base(id, firstName, lastName)
        {
            GPA = gpa;
            Major = major;
            BirthDate = birthDate;
            RegistrationDate = regDate;
            CurrentYear = currentYear;
            HasScholarship = scholarship;
            Courses = new string[10]; // Array for courses
        }

        public virtual double CalculateFees()
        {
            if (HasScholarship)
            {
                return 0; // Scholarship student pays no fees
            }
            else
            {
                double registrationFee = 4000000; // Base registration fee
                double transportationFee = 1000000; // Transportation fee

                // 9% increase after first year
                for (int i = 1; i < CurrentYear; i++)
                {
                    registrationFee = registrationFee * 1.09;
                }

                return registrationFee + transportationFee;
            }
        }
    }

    public class Teacher : Person
    {
        public double MonthlySalary { get; set; }
        public string[] TeachingCourses { get; set; }
        public bool IsHourly { get; set; }
        public int ExtraHours { get; set; }

        public Teacher(int id, string firstName, string lastName, double salary, bool hourly)
                      : base(id, firstName, lastName)
        {
            MonthlySalary = salary;
            IsHourly = hourly;
            TeachingCourses = new string[10]; // Array for courses
            ExtraHours = 0;
        }

        // Calculate monthly income
        public virtual double CalculateMonthlyIncome()
        {
            if (IsHourly)
            {
                return MonthlySalary; // Hourly teacher
            }
            else
            {
                // Monthly teacher + extra hours
                return MonthlySalary + (ExtraHours * 25000);
            }
        }
    }

    public class UniversityException : Exception
    {
        public UniversityException(string message) : base(message) { }
    }
}
