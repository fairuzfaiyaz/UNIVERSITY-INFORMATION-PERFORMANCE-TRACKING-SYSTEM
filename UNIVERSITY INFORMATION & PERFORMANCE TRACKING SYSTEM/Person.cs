using System;
using System.Runtime.InteropServices;

namespace UNIVERSITY_INFORMATION___PERFORMANCE_TRACKING_SYSTEM
{
    internal class Person
    {
        private string name;
        private int age;
        protected string address;
        internal string email;
        public static int personCount;

        static Person()
        {
            personCount = 0;
        }
        public Person()
        {
            this.name = "Unknown";
            this.age = 0;
            this.address = "Not Set";
            this.email = "Not Set";
            personCount++;
        }
        public Person(string name, int age, string address, string email)
        {
            this.name = name;
            this.age = age;
            this.address = address;
            this.email = email;
            personCount++;
        }
        public Person(Person copy)
        {
            this.name = copy.name;
            this.age = copy.age;
            this.address = copy.address;        
            this.email = copy.email;
            personCount++;  
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine("Name: " + this.name);
            Console.WriteLine("Age: " + this.age);
            Console.WriteLine("Address: " + this.address);
            Console.WriteLine("Email: " + this.email);
        }
        public void changeAddress(string newAddress)
        {
            this.address = newAddress;
        }

        public string Name
        {
            get 
            { 
                return this.name; 
            }
            set
            {
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (this.age > 20 && this.age < 25)
                    this.age = value;
                else
                {
                    Console.WriteLine("Student is not in Appropriate Age to join university");
                    return;
                }
                    
            }
        }

    }
}
