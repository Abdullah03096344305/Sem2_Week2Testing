using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Testing
{
    class Program
    {
        class Students
        {
            public string name;
            public int roll_no;
            public float cgpa;
            public char isHostellide;
            public string department;
        }
        static char Menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Press 1 for Adding a Student:");
            Console.WriteLine("Press 2 to View Students:");
            Console.WriteLine("Press 3 for Top Three Students:");
            Console.WriteLine("Press 4 to Exit:");
            choice = char.Parse(Console.ReadLine());
            return choice;

        }
        static Students AddStudent()
        {
            Students s1 = new Students();
            Console.WriteLine("Enter Name: ");
            s1.name = Console.ReadLine();
            Console.WriteLine("Enter Roll No: ");
            s1.roll_no = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter CGPA: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Deprtment: ");
            s1.department = Console.ReadLine();
            Console.WriteLine("Is Hotelide(Y || N): ");
            s1.isHostellide = char.Parse(Console.ReadLine());           
            return s1;
        }
        static void viewStudent(Students[] s,int count)
        {
            Console.Clear();
            Console.WriteLine("Name\t\tRoll No\t\tCGPA\t\tDepartment\t\tIsHotelide");
            for (int i = 0;i < count;i++)
            {                 
                Console.WriteLine(s[i].name +"\t"+ s[i].roll_no + "\t\t" + s[i].cgpa + "\t\t" + s[i].department + "\t\t" + s[i].isHostellide);
            }
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
        }
        static void TopStudent(Students[] s,ref int count)
        {
            Console.Clear();
            if(count == 0)
            {
                Console.WriteLine("No Record Present");
            }
            else if(count == 1)
            {
                viewStudent(s, 1);
            }
            else if(count == 2)
            {
                for(int x = 0;x < 2;x++)
                {
                    int index = largest(s,ref x,ref count);
                    Students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewStudent(s, 2);
            }
            else
            {
                for(int x =0;x<3;x++)
                {
                    int index = largest(s,ref x,ref count);
                    Students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewStudent(s, 3);
            }
        }
        static int largest(Students[] s,ref int start,ref int end)
        {
            int index = start;
            float large = s[start].cgpa;
            for(int x = start; x < end;x++)
            {
                if(large < s[x].cgpa)
                {
                    large = s[x].cgpa;
                    index = x;
                }
            }
            return index;
        }
        static void Main(string[] args)
        {
            /*//First Object---------------
            Students s1 = new Students();
            s1.name = "ahmad";
            s1.roll_no = 5;
            s1.cgpa = 3.25F;
            Console.WriteLine("Name: {0} Roll No: {1} CGPA: {2}", s1.name, s1.roll_no, s1.cgpa);
            //Second Object---------------
            Students s2 = new Students();
            s2.name = "ali";
            s2.roll_no = 89;
            s2.cgpa = 2.88F;
            Console.WriteLine("Name: {0} Roll No: {1} CGPA: {2}", s2.name, s2.roll_no, *//*s2.cgpa);*/


            //========================================================
            //First Object
            /* Students s1 = new Students();
             Console.WriteLine("Enter Name: ");
             s1.name = Console.ReadLine();
             Console.WriteLine("Enter Roll No: ");
             s1.roll_no = int.Parse(Console.ReadLine());
             Console.WriteLine("Enter CGPA: ");
             s1.cgpa = float.Parse(Console.ReadLine());
             Console.WriteLine("Name:   {0} Roll No:   {1} CGPA:    {2}", s1.name, s1.roll_no, s1.cgpa);*/
            Students[] s = new Students[10];
            char option;
            int count = 0;
            do
            {
                option = Menu();
                if (option == '1')
                {
                    s[count] = AddStudent();
                    count = count + 1;
                }
                else if (option == '2')
                {
                    viewStudent(s, count);
                }
                else if (option == '3')
                {
                    TopStudent(s, ref count);
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }

            }
            while (option != '4');
            Console.WriteLine("Press Enter To Exit...");
           Console.Read();
        }
    }
}
