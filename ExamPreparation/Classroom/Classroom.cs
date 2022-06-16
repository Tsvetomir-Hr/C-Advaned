using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count => students.Count;
        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (student == null)
            {
                return "Student not found";
            }
            students.Remove(student);
            return $"Dismissed student {firstName} {lastName}";
        }
        public string GetSubjectInfo(string subject)
        {
            int counter = 0;
            foreach (Student student in students)
            {
                if (student.Subject == subject)
                {
                    counter++;
                }
            }
            if (counter > 0)
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (Student student in students)
                {
                    if (student.Subject == subject)
                    {
                        sb.AppendLine($"{student.FirstName} {student.LastName}");
                    }
                }
                return sb.ToString().TrimEnd();
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }
        public int GetStudentsCount()
        {
            return students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {

            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            return student;
        }



    }
}
