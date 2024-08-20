using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Implementation
{
    class DAL
    {
        SqlConnection conn;
        public DAL()
        {
            string conf = "Data Source=DESKTOP-TCFACU3\\SQLEXPRESS01;Initial Catalog=fullstack;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";
            conn = new SqlConnection(conf);
            conn.Open();//connection started

        }
        public void saveEmp()
        {
            string ename, edept, edoj;
            double esalary;

            Console.WriteLine("Enter name:");
            ename = Console.ReadLine();

            Console.WriteLine("Enter department:");
            edept = Console.ReadLine();

            Console.WriteLine("Enter DOJ ");
            edoj = Console.ReadLine();

            Console.WriteLine("Enter Salary");
            esalary = double.Parse(Console.ReadLine());

            try
            {
                string q = "Insert into emp(cname,dept,salary,doj) values ('" + ename + "','" + edept + "','" + esalary + "','" + edoj + "')";
                SqlCommand cmd = new SqlCommand(q, conn);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    Console.WriteLine("Emp Added successfully");
                }
                else
                {
                    Console.WriteLine("Data is not inserted");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void fetchEmp()
        {
            try
            {
                string q = "select * from emp";
                SqlCommand sqlCommand = new SqlCommand(q, conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string ename = reader["cname"].ToString();
                        string dept = reader["dept"].ToString();
                        double salary = Convert.ToDouble(reader["salary"].ToString());
                        string doj = reader["doj"].ToString();

                        Console.WriteLine($"Emp id is{id} \n Emp name is {ename} \n Emp dept is {dept} \n Emp salary is {salary} \n Emp DOJ is {doj}");
                        Console.WriteLine("=========================================================");
                    }

                }
                else
                {
                    Console.WriteLine("No Entries Found");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public void DeleteEmp()
        {
            int eid;
            Console.WriteLine("Enter Emp id to delete the record");
            eid=int.Parse(Console.ReadLine());

            try
            {
                string q = "delete from emp where id='" + eid + "'";
                SqlCommand sqlCommand = new SqlCommand(q, conn);
                int row = sqlCommand.ExecuteNonQuery();
                if (row > 0)
                {
                    Console.WriteLine("Employee deleted successfully");
                }
                else
                {
                    Console.WriteLine("Data is Not deleted");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }


        public void updateEmp()
        {
            string ename, edpet, edoj;
            double esalary;
            int eid;

            Console.WriteLine("Enter Employee id  to edit the record");
            eid=int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Employee name");
            ename =Console.ReadLine();

            Console.WriteLine("Enter Employee dept");
            edpet = Console.ReadLine();

            Console.WriteLine("Enter Employee DOJ");
            edoj = Console.ReadLine();

            Console.WriteLine("Enter Employee Salary");
            esalary =double.Parse( Console.ReadLine());

            try
            {
                string q = "update emp set cname='"+ename+"',dept='"+edpet+"',salary='"+esalary+"',doj='"+edoj+"' where id='"+eid+"'";
                SqlCommand sqlCommand = new SqlCommand( q, conn);
                int row = sqlCommand.ExecuteNonQuery();
                if (row > 0)
                {
                    Console.WriteLine("Emp updated Successfully");
                }
                else
                {
                    Console.WriteLine("Something went wrong");
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void search()
        {
            string sname;
            Console.WriteLine("Search by Name...");
            sname = Console.ReadLine();
            try
            {
                string q = "select * from emp where cname Like  '%" + sname + "%'";
                SqlCommand sqlCommand = new SqlCommand(q, conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string ename = reader["cname"].ToString();
                    string dept = reader["dept"].ToString();
                    double salary = Convert.ToDouble(reader["salary"].ToString());
                    string doj = reader["doj"].ToString();

                    Console.WriteLine($"Emp id is{id} \n Emp name is {ename} \n Emp dept is {dept} \n Emp salary is {salary} \n Emp DOJ is {doj}");
                    Console.WriteLine("=========================================================");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
