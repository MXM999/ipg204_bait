using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp133
{
    internal class Tester
    {
        public static void Main(string[] args)
        {
            UniversityManager university = new UniversityManager(100, 50);

            InitializeSampleData(university);

            bool exit = false;
            while (!exit)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Total registered students: " + university.GetTotalStudents());
                            break;
                        case "2":
                            Console.WriteLine("Number of scholarship students: " + university.GetScholarshipStudents());
                            break;
                        case "3":
                            Console.Write("Enter student ID: ");
                            int studentId = int.Parse(Console.ReadLine());
                            Console.Write("Enter student last name: ");
                            string lastName = Console.ReadLine();
                            university.PrintStudentCourses(studentId, lastName);
                            break;
                        case "4":
                            university.PrintTopSecondYearStudents();
                            break;
                        case "5":
                            RegisterNewStudent(university);
                            break;
                        case "6":
                            AddNewTeacher(university);
                            break;
                        case "7":
                            Console.Write("Enter teacher ID: ");
                            int teacherId = int.Parse(Console.ReadLine());
                            university.PrintTeacherIncome(teacherId);
                            break;
                        case "8":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("==== University Management System ====");
            Console.WriteLine("1. Print number of registered students");
            Console.WriteLine("2. Print number of scholarship students");
            Console.WriteLine("3. Display student courses");
            Console.WriteLine("4. Top 10 students in second year");
            Console.WriteLine("5. Register new student");
            Console.WriteLine("6. Add new teacher");
            Console.WriteLine("7. Print teacher monthly income");
            Console.WriteLine("8. Exit");
            Console.Write("Choose task: ");
        }

        static void InitializeSampleData(UniversityManager university)
        {
            Student student1 = new Student(1, "Ahmed", "Mohammed", 85.5, "Computer Engineering",
                                          new DateTime(2000, 5, 15), new DateTime(2023, 9, 1), 2, false);
            student1.Courses[0] = "IPG202";
            student1.Courses[1] = "IPG203";

            Student student2 = new Student(2, "Fatima", "Ali", 92.3, "Computer Engineering",
                                          new DateTime(1999, 8, 20), new DateTime(2023, 9, 1), 2, true);
            student2.Courses[0] = "IPG202";
            student2.Courses[1] = "IPG203";

            university.AddStudent(student1);
            university.AddStudent(student2);

            Teacher teacher1 = new Teacher(101, "Dr. Mohammed", "Al-Khaled", 500000, false , 5);
            teacher1.TeachingCourses[0] = "IPG202";

            Teacher teacher2 = new Teacher(102, "Dr. Sara", "Hussein", 30, true);
            teacher2.TeachingCourses[0] = "IPG203";

            university.AddTeacher(teacher1);
            university.AddTeacher(teacher2);
        }

        static void RegisterNewStudent(UniversityManager university)
        {
            Console.Write("Student ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.Write("GPA: ");
            double gpa = double.Parse(Console.ReadLine());
            Console.Write("Major: ");
            string major = Console.ReadLine();
            Console.Write("Current year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Has scholarship? (yes/no): ");
            bool scholarship = Console.ReadLine().ToLower() == "yes";
            

            Student newStudent = new Student(id, firstName, lastName, gpa, major,
                                           DateTime.Now, DateTime.Now, year, scholarship);
            university.AddStudent(newStudent);
            Console.WriteLine("Student registered successfully");
        }

        static void AddNewTeacher(UniversityManager university)
        {
            Console.Write("Teacher ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Monthly salary: ");
            double salary = double.Parse(Console.ReadLine());
            Console.Write("Is hourly teacher? (yes/no): ");
            bool hourly = Console.ReadLine().ToLower() == "yes";

            Teacher newTeacher = new Teacher(id, firstName, lastName, salary, hourly);
            university.AddTeacher(newTeacher);
            Console.WriteLine("Teacher added successfully");
        }
    }
}
