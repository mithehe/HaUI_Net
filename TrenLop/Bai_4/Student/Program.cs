using System;

namespace HelloWorld{
    class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Mark { get; set; }
        public int Scholarship { get; set; }

        public Student()
        {

        }

        public Student(string id, string name, int mark, int scholarship)
        {
            ID = id;
            Name = name;
            Mark = mark;
            Scholarship = scholarship;
        }

        public void setScholaship(int mark)
        {
            if (mark > 8) Scholarship = 500;
            else if (mark <= 8 && mark >= 7) Scholarship = 300;
            else Scholarship = 0;
        }

        public static void Main(string[] args)
        {
            Student s = new Student();
            Console.Write("Enter student ID: ");
            s.ID = Console.ReadLine();
            Console.Write("Enter student name: ");
            s.Name = Console.ReadLine();
            Console.Write("Enter student mark: ");
            s.Mark = int.Parse(Console.ReadLine());
            s.setScholaship(s.Mark);
            Console.WriteLine($"Student ID: {s.ID}");
            Console.WriteLine($"Student Name: {s.Name}");
            Console.WriteLine($"Student Mark: {s.Mark}");
            Console.WriteLine($"Student Scholarship: {s.Scholarship}");
        }
    }
}
