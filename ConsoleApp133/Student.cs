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
        {
            Person_ADD(id, firstName, lastName);
            GPA = gpa;
            Major = major;
            BirthDate = birthDate;
            RegistrationDate = regDate;
            CurrentYear = currentYear;
            HasScholarship = scholarship;
            Courses = new string[10]; 
        }

        public override void Person_ADD(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public double CalculateFees()
        {
            if (HasScholarship)
            {
                return 0; 
            }
            else
            {
                double registrationFee = 4000000; 
                double transportationFee = 1000000;


                //double test1 = 0;
                //for (int i = 0; i < CurrentYear; i++)
                //{
                //    test1 = test1 + registrationFee * 0.09;
                //}

                //double test2 = 0;
                //for (int i = 0; i < CurrentYear; i++)
                //{
                //    test2 = registrationFee * 0.09;
                //    registrationFee = registrationFee + test2;
                //}

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
        public double WorkHour { get; set; }
        public bool IsHourly { get; set; }
        public double ExtraHours { get; set; }

        public Teacher(int id, string firstName, string lastName, double salary, bool hourly , double exHours)
        {
            Person_ADD(id, firstName, lastName);
            MonthlySalary = salary;
            IsHourly = hourly;
            TeachingCourses = new string[10]; 
            ExtraHours = exHours;
        }
        public Teacher(int id, string firstName, string lastName, double hoursWork, bool hourly)
        {
            Person_ADD(id, firstName, lastName);
            WorkHour = hoursWork;
            IsHourly = hourly;
            TeachingCourses = new string[10];
        }
        public override void Person_ADD(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public virtual double CalculateMonthlyIncome()
        {
            if (IsHourly)
            {
                return WorkHour * 25000; 
            }
            else
            {
                return MonthlySalary + (ExtraHours * 25000);
            }
        }
    }

    public class UniversityException : Exception
    {
        public UniversityException(string message) : base(message) { }
    }
}
