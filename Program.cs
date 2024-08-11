using System.Collections;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;



namespace Project_EMS
{
    internal class EMS_Main
    {
        static void Main(string[] args)
        {
            string Admin_user = "admin";
            string Admin_password = "admin@123";
            int Emp_ID = 1;
            string Emp_password = "employee@123";
            char ch3, ch4;



            employee_admin adm = new employee_admin();
            employee_admin emp = new employee_admin();

            Console.WriteLine("EMPLOYEE MANAGEMENT SYSTEM");
            Console.WriteLine("---------------------------------------------------------");
            do
            {
            entry: Console.WriteLine("\nEnter your choice ->\n1.Admin\n2.Employee\n3.EXIT");
                Console.Write(" Enter Your Choice: ");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("\n***************Admin Login***************");
                        Console.Write("Enter User Name:");
                        string Ad_user_name = Console.ReadLine();
                        Console.Write("Enter password:");
                        string Ad_pass = Console.ReadLine();
                        if (Admin_user == Ad_user_name && Admin_password == Ad_pass)
                        {
                            Console.WriteLine("Login Successfully\n");
                            do
                            {
                            admin: Console.WriteLine("Choose\n1.Add Employee\n2.Delete Employee\n3.Employee Details\n4.EXIT");
                                Console.WriteLine("Enter your choice:");
                                int ch1 = Convert.ToInt32(Console.ReadLine());
                                switch (ch1)
                                {
                                    case 1:
                                        adm.addEmp();
                                        break;
                                    case 2:
                                        adm.deleteEmp();
                                        Console.WriteLine("After Deleting employees....");
                                        adm.emp_updatefile();
                                        break;
                                    case 3:
                                        adm.emp_details();
                                        break;
                                    case 4:
                                        goto entry;
                                    default:
                                        Console.WriteLine("Wrong choice");
                                        break;

                                }
                                Console.WriteLine("\nSo do you want to continue  Y/N :");
                                ch4 = Convert.ToChar(Console.ReadLine());
                            } while (ch4 != 'N');
                        }
                        else
                        {
                            if (Admin_user != Ad_user_name)
                                Console.WriteLine("Invalid Username");
                            else Console.WriteLine("Invalid Password");
                        }
                        break;
                    case 2:

                        Console.WriteLine("\n***************Employee Login***************");
                        Console.Write("Enter Employee Id:");
                        int Emp_id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter password:");
                        string Emp_pass = Console.ReadLine();
                        if (Emp_id == Emp_ID && Emp_pass == Emp_password)
                        {
                            Console.WriteLine("Login Successfully");
                            Console.WriteLine("\nChoose\n1.Your Profile\n2.Edit/Update\n3.EXIT");
                            Console.WriteLine("Enter your choice:");
                            int ch1 = Convert.ToInt32(Console.ReadLine());
                            switch (ch1)
                            {
                                case 1:
                                    emp.profile();
                                    break;
                                case 2:
                                    emp.update();
                                    break;
                                case 3:
                                    goto entry;
                                default:
                                    Console.WriteLine("Wrong choice");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Login Failed");
                        }
                        break;
                    case 3:
                        goto exit;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
                Console.WriteLine("\nSo do you want to continue  Y/N :");
                ch3 = Convert.ToChar(Console.ReadLine());
            } while (ch3 != 'N');
        exit: Console.WriteLine("\n\tThank you for Visiting our Employee Management System");
            Console.WriteLine("-------------------------------------------------------------");
        }








        public class employee_admin
        {
            EMS_Main empA = new EMS_Main();
            public void profile()
            {
                Console.WriteLine("Enter Employee ID=");
                id = Convert.ToInt32(Console.ReadLine());
                strLine = File.ReadAllLines(adminFile);
                Console.WriteLine("Profile=");
                for (int i = 1; i <= strLine.Length; i++)
                {
                    if (i == id)
                    {
                        Console.WriteLine(strLine[i]);
                    }
                }

            }
            public void update()
            {
                Console.WriteLine("\n***************Update Employee Details***************");

                Console.WriteLine("Select\n1-update LEAVES\n2-update EXPERIENCE");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        int totalLeaves = 20, cnt = 0;
                        Console.WriteLine("Enter employee id=");
                        int id_leave = Convert.ToInt32(Console.ReadLine());
                    flow2: Console.WriteLine("How many leaves do u want? ");
                        int n1 = Convert.ToInt32(Console.ReadLine());
                        Dictionary<int, int> dict = new Dictionary<int, int>();
                        dict.Add(id_leave, totalLeaves);
                        cnt++;
                        foreach (var ele in dict)
                        {
                            if (ele.Key == id_leave)
                            {
                                Console.WriteLine("Totals leaves per year=20\nRemaining leaves=" + ele.Value);
                            }
                        }
                        totalLeaves = totalLeaves - n1;
                        dict[1] = totalLeaves;
                        Console.WriteLine("LEAVES SANCTIONED!!\nRemaining leaves=" + dict[1]);
                        Console.WriteLine("\nDo u want more leaves? Y/N ");
                        char c = Convert.ToChar(Console.ReadLine());
                        if (c == 'Y' || c == 'y')
                        {
                            goto flow2;
                        }

                        break;
                    case 2:
                        Dictionary<int, int> dict_salary = new Dictionary<int, int>();
                        admin_id = Convert.ToInt32(emp_Id);
                        admin_salary = Convert.ToInt32(emp_Salary);
                        admin_Experience = Convert.ToInt32(emp_Experience);
                        Console.WriteLine("Enter employee id=");
                        int id_exp = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter your experience in years=");
                        int e = Convert.ToInt32(Console.ReadLine());
                        e = e + admin_Experience;
                        //int x1=Convert.ToInt32(emp_Salary);
                        dict_salary.Add(admin_salary, admin_salary);

                        if (e >= 12)
                        {
                            foreach (var x in dict_salary)
                            {
                                if (Convert.ToInt32(x.Key) == id_exp)
                                {
                                    admin_salary = Convert.ToInt32(x.Value) + 15000;
                                    dict_salary.Add(x.Key, admin_salary);

                                }
                            }
                            Console.WriteLine("Congratulations...Now you are on the managerial post.\nYour incremented salary is " + admin_salary);
                        }
                        else if (e >= 5 && e < 12)
                        {
                            foreach (var x in dict_salary)
                            {
                                if (Convert.ToInt32(x.Key) == id_exp)
                                {
                                    admin_salary = Convert.ToInt32(x.Value) + 5000;
                                    dict_salary.Add(x.Key, admin_salary);

                                }
                            }
                            Console.WriteLine("Wohooo...Its time for Permanent employation.\nYour incremented salary is " + admin_salary);
                        }
                        else { Console.WriteLine("Need more experience for SALARY HIKE"); }
                        break;

                    default: Console.WriteLine("Incorrect Choice!"); break;
                }


            }


            public string emp_Id, emp_Name, emp_DOB, emp_Email, emp_Address;
            public int emp_Salary, delete_Id, id, emp_Experience;
            public string adminFile = @"C:\Users\Admin\source\repos\EMSupdated\AdminFile.txt";

            public string adminFile1 = @"C:\Users\Admin\source\repos\EMSupdated\AdminFile1.txt";
            public string employeeFile = @"C:\Users\Admin\source\repos\EMSupdated\EmpFile.txt";
            public string str, adminReadFile, strDelete;
            public int admin_id, admin_salary, admin_Experience = 0;
            public string[] strLine;



            Dictionary<int, int> dict_salary = new Dictionary<int, int>();

            ArrayList al = new ArrayList();
            public void addEmp()
            {


                Console.WriteLine("*****Add Employee Details*****");
                Console.Write("Enter Employee Id : ");
                emp_Id = Console.ReadLine();
                Console.Write("Enter Employee Name : ");
                emp_Name = Console.ReadLine();
                Console.Write("Enter Employee Date of Birth : ");
                emp_DOB = Console.ReadLine();
                Console.Write("Enter Employee Email :");
                emp_Email = Console.ReadLine();
                Console.Write("Enter Employee Address: ");
                emp_Address = Console.ReadLine();
                Console.Write("Enter Employee Salary: ");
                emp_Salary = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Experience: ");
                emp_Experience = Convert.ToInt32(Console.ReadLine());

                al.Add(emp_Id);
                al.Add(emp_Name);
                al.Add(emp_DOB);
                al.Add(emp_Email);
                al.Add(emp_Address);
                al.Add(emp_Salary);
                al.Add(emp_Experience);
                File.AppendAllText(adminFile, "\n");
                foreach (var ele in al)
                {
                    //Console.WriteLine(ele);
                    str = ele.ToString();
                    File.AppendAllText(adminFile, "  \t");
                    File.AppendAllText(adminFile, str);
                }


                Console.WriteLine("{0}'s details are saved successffully", emp_Name);
            }
            public void deleteEmp()
            {
                Console.WriteLine("Enter Employee Id=");
                delete_Id = Convert.ToInt32(Console.ReadLine());
                strLine = File.ReadAllLines(adminFile);
                for (int i = 1; i <= strLine.Length; i++)
                {
                    if ((i) == delete_Id)
                    {
                        strLine[i] = strLine[i].Replace(strLine[i], "       Deleted************");
                    }
                }

                for (int i = 0; i < strLine.Length; i++)
                {
                    File.AppendAllText(adminFile1, strLine[i]);
                    File.AppendAllText(adminFile1, "\n");
                }


            }
            public void emp_details()
            {
                Console.WriteLine("***** Employee Details are *****");

                adminReadFile = File.ReadAllText(adminFile);
                Console.WriteLine(adminReadFile);

            }
            public void emp_updatefile()
            {
                Console.WriteLine("************ Employee Details are ************");

                adminReadFile = File.ReadAllText(adminFile1);
                Console.WriteLine(adminReadFile);


            }

        }

    }



}
