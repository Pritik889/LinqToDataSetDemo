using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LinqToDatasetDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //(1) Simple query :Like Sql query =>Select * from Tablename
            Console.WriteLine("-----------------------------Simple Query to=> select all column data--------------------------------------");
            var data = from s in MyData().Tables[0].AsEnumerable()
                       select s;
            foreach (var mydata in data)
            {
                Console.WriteLine("EmployeeID:" + mydata["Employeeid"] + "," + "Name:" + mydata["Name"] + "Gender:" + mydata["Gender"] + ",Age:" + mydata["Age"] +
                    ",Qualification:" + mydata["Qualification"] + ",FatherName:" + mydata["FatherName"] + ",Address:" + mydata["Address"] + Environment.NewLine);
            }

            //(2)Simple query  =>using linq Method=>Lambda Expression:Like Sql query =>Select * from Tablename
            Console.WriteLine("-----------Simple Query to=>select all column data using Lambda Expression of linq----------------");
            var data2 = MyData().Tables[0].AsEnumerable().Select(k => k);
            foreach (var mydata in data2)
            {
                Console.WriteLine("EmployeeID:" + mydata["Employeeid"] + "," + "Name:" + mydata["Name"] + "Gender:" + mydata["Gender"] + ",Age:" + mydata["Age"] +
                    ",Qualification:" + mydata["Qualification"] + ",FatherName:" + mydata["FatherName"] + ",Address:" + mydata["Address"] + Environment.NewLine);
            }

            //(3)Like Sql query =>select columnname1,columnname2 from tablename
            Console.WriteLine("--------------------------Simple Query to=> select specific column data----------------------------");
            var data1 = from p in MyData().Tables[0].AsEnumerable()
                        select new { Employeeid = p["Employeeid"].ToString(), Name = p["Name"].ToString() };
            foreach (var mydata1 in data1)
            {
                Console.WriteLine(mydata1.Employeeid + "," + mydata1.Name);
            }
            //(4)Using Lambda expression=>Like Sql query =>select columnname1,columnname2 from tablename
            Console.WriteLine("-----------Simple Query to=>select all column data using Lambda Expression of linq----------------");
            var data3 = MyData().Tables[0].AsEnumerable().Select(k => new { Employeeid = k["Employeeid"], Name = k["Name"] });
            foreach (var mydata1 in data3)
            {
                Console.WriteLine(mydata1.Employeeid + "," + mydata1.Name);
            }

            //(5)Using Lambda expression=>Like Sql query=>use case  in Sql query
            //=>select columnname1,columnname2,case when columnname3 = 1 then 'Female' when columnname3 = 2 then 'Male' from tablename
            Console.WriteLine("-----------Simple Query to=>select all column data using Lambda Expression of linq----------------");
            var data4 = MyData().Tables[0].AsEnumerable().Select(k => new
            {
                Employeeid = k["Employeeid"],
                Name = k["Name"],
                Gender = k["Gender"].ToString() == "1" ? "Female" : k["Gender"].ToString() == "2" ? "Male" : ""

            });
            foreach (var mydata1 in data4)
            {
                Console.WriteLine(mydata1.Employeeid + "," + mydata1.Name + "," + mydata1.Gender);
            }


            Console.ReadKey();

        }

        /// <summary>
        /// Here my Data
        /// </summary>
        /// <returns></returns>
        private static DataSet MyData()
        {
            DataSet _ds = new DataSet();
            DataTable _dt = new DataTable();
            _dt.Columns.Add("Employeeid");
            _dt.Columns.Add("Name");
            _dt.Columns.Add("Age");
            _dt.Columns.Add("Qualification");
            _dt.Columns.Add("FatherName");
            _dt.Columns.Add("Address");
            _dt.Columns.Add("Gender");//Here 1 for Female and 2 for Male.

            _dt.Rows.Add("1001", "Priya", "24", "B-Tech", "Suresh Yadav", "Delhi", "1");
            _dt.Rows.Add("1002", "priyanka", "26", "B-Tech", "Sudhir singh", "Patna", "1");
            _dt.Rows.Add("1003", "Anu", "25", "MCA", "Sekhar singh", "bhagalpur", "1");
            _dt.Rows.Add("1004", "Suman", "26", "BCA", "Rohit singh", "Indor", "1");
            _dt.Rows.Add("1005", "Vijay Mishra", "26", "B-tech", "Raju Mishra", "Patna", "2");
            _dt.Rows.Add("1006", "Rekha", "24", "B-tech", "Sudhakar singh", "Chandigarh", "1");
            _dt.Rows.Add("1007", "Ankush kumar", "28", "B-tech", "Sunil Kumar", "Delhi", "2");
            _ds.Tables.Add(_dt);
            return _ds;

        }

    }
}
