using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp133
{
    internal class UniversityManager
    {
        private Student[] students;
        private Teacher[] teachers;
        private int studentCount;
        private int teacherCount;

        public UniversityManager(int maxStudents, int maxTeachers)
        {
            students = new Student[maxStudents];
            teachers = new Teacher[maxTeachers];
            studentCount = 0;
            teacherCount = 0;
        }

        // Add new student
        public void AddStudent(Student student)
        {
            if (studentCount < students.Length)
            {
                students[studentCount] = student;
                studentCount++;
            }
            else
            {
                throw new UniversityException("Cannot add more students - capacity full");
            }
        }

        // Add new teacher
        public void AddTeacher(Teacher teacher)
        {
            if (teacherCount < teachers.Length)
            {
                teachers[teacherCount] = teacher;
                teacherCount++;
            }
            else
            {
                throw new UniversityException("Cannot add more teachers - capacity full");
            }
        }

        // Get total number of students
        public int GetTotalStudents()
        {
            return studentCount;
        }

        // Get number of scholarship students
        public int GetScholarshipStudents()
        {
            int count = 0;
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].HasScholarship)
                {
                    count++;
                }
            }
            return count;
        }

        // Find student and display courses
        public void PrintStudentCourses(int studentId, string lastName)
        {
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].Id == studentId && students[i].LastName == lastName)
                {
                    Console.WriteLine("Courses for student: " + students[i].FirstName + " " + students[i].LastName);
                    for (int j = 0; j < students[i].Courses.Length; j++)
                    {
                        if (!string.IsNullOrEmpty(students[i].Courses[j]))
                        {
                            Console.WriteLine("- " + students[i].Courses[j]);
                        }
                    }
                    return;
                }
            }
            throw new UniversityException("Student not found");
        }

        // Top 10 students in second year
        public void PrintTopSecondYearStudents()
        {
            // Sort students by GPA
            for (int i = 0; i < studentCount - 1; i++)
            {
                for (int j = i + 1; j < studentCount; j++)
                {
                    if (students[i].GPA < students[j].GPA)
                    {
                        Student temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }

            Console.WriteLine("Top 10 students in second year:");
            int count = 0;
            for (int i = 0; i < studentCount && count < 10; i++)
            {
                if (students[i].CurrentYear == 2)
                {
                    Console.WriteLine((count + 1) + ". " + students[i].FirstName + " " + students[i].LastName + " - GPA: " + students[i].GPA);
                    count++;
                }
            }
        }

        // Display teacher income
        public void PrintTeacherIncome(int teacherId)
        {
            for (int i = 0; i < teacherCount; i++)
            {
                if (teachers[i].Id == teacherId)
                {
                    double income = teachers[i].CalculateMonthlyIncome();
                    Console.WriteLine("Monthly income for teacher " + teachers[i].FirstName + " " + teachers[i].LastName + ": " + income + " SYP");
                    return;
                }
            }
            throw new UniversityException("Teacher not found");
        }
    }
}
