using System;
namespace HelloWorld{
    class Person
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Person()
        {
        }

        public Person(string id, string fullName, int age, string email, string address)
        {
            Id = id;
            FullName = fullName;
            Age = age;
            Email = email;
            Address = address;
        }

        public void checkAge()
        {
            if (Age > 18)
                Console.WriteLine("Bạn đã đủ tuổi bầu cử");
            else
                Console.WriteLine("Bạn chưa đủ tuổi bầu cử");
        }

        public void input()
        {
            Console.WriteLine("Enter your information");
            Console.Write("What is your ID: ");
            Id = Console.ReadLine();
            Console.Write("What is your name: ");
            FullName = Console.ReadLine();
            Console.Write("How old are you: ");
            Age = int.Parse(Console.ReadLine());
            Console.Write("What is your email: ");
            Email = Console.ReadLine();
            Console.Write("What is your address: ");
            Address = Console.ReadLine();
        }

        public void output()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Fullname is : {FullName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Address: {Address}");
        }

        public static void Main(string[] args)
        {
            Person p = new Person();
            p.input();
            p.output();
        }
    }
}


