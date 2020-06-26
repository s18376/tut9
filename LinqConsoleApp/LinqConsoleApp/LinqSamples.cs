using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqConsoleApp
{
    public class LinqSamples
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        public LinqSamples()
        {
            LoadData();
        }

        public void LoadData()
        {
            List<Emp> empsCol = new List<Emp>();
            List<Dept> deptsCol = new List<Dept>();

            #region Load depts
            Dept d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            Dept d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            Dept d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion

            #region Load emps
            Emp e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            Emp e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            Emp e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            Emp e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            Emp e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            Emp e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            Emp e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            Emp e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            Emp e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            Emp e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;

            #endregion

        }

        /*
            The purpose of the exercise is to implement the following methods.
            Each method should contain C# code, which with the help of LINQ will perform queries described using SQL.
        */

        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        public void Task1()
        {
            //var res = new List<Emp>();
            //foreach(var emp in Emps)
            //{
            //    if (emp.Job == "Backend programmer") res.Add(emp);
            //}

            //1. Query syntax (SQL)
            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select new
                      {
                          Nazwisko = emp.Ename,
                          Zawod = emp.Job
                      };

            //2. Lambda and Extension methods
            IEnumerable<Emp> result = Emps
                .Where(emp => emp.Job == "Backend programmer");
        }

        /// <summary>
        /// SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        public void Task2()
        {
            IOrderedEnumerable<Emp> result = Emps
                .Where(emp => emp.Job == "Frontend programmer" && emp.Salary > 1000)
                .OrderByDescending(emp => emp.Ename);
        }

        /// <summary>
        /// SELECT MAX(Salary) FROM Emps;
        /// </summary>
        public void Task3()
        {
            int result = Emps.Max(emp => emp.Salary);
        }

        /// <summary>
        /// SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        public void Task4()
        {
            IEnumerable<Emp> result = Emps
                .Where(emp => emp.Salary == (Emps.Max(emp1 => emp1.Salary)));
        }

        /// <summary>
        /// SELECT ename AS FirstName, job AS EmployeeJob FROM Emps;
        /// </summary>
        public void Task5()
        {
            // var result = from emp1 in Emps select new {FirstName = emp1.Ename, EmployeeJob = emp1.Job};

            var res = Emps.Select(emp => new
            {
                FirstName = emp.Ename,
                EmployeeJob = emp.Job
            });
        }

        /// <summary>
        /// SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        /// INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        /// Result: Joining collections Emps and Depts.
        /// </summary>
        public void Task6()
        {
            var result = Emps
                .Join(Depts, e => e.Deptno,
                             d => d.Deptno,
                             (e, d) => new { e.Ename, e.Job, d.Dname });
        }

        /// <summary>
        /// SELECT Job AS EmployeeJob, COUNT(1) EmployeeNuber FROM Emps GROUP BY Job;
        /// </summary>
        public void Task7()
        {
            var result = Emps
                .GroupBy(emp => emp.Job)
                .Select(e => new
                {
                    EmployeeJob = e.Key,
                    EmployeeNumber = Emps.Distinct().Count()
                });
        }

        /// <summary>
        /// Return value "true" if at least one of 
        /// the elements of collection works as "Backend programmer".
        /// </summary>
        public void Task8()
        {
            bool result = Emps.Any(emp => emp.Job == "Backend programmer");
        }

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        public void Task9()
        {
            IOrderedEnumerable<Emp> result = Emps
                .Where(e => e.Job == "Frontend programmer")
                .GroupBy(e => e.HireDate)
                .Select(e => e.OrderByDescending(e => e.HireDate))
                .FirstOrDefault();
        }

        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "No value", null, null;
        /// </summary>
        public void Task10()
        {
            var unionList = new[]
            {
                new
                {
                    Ename = "No value",
                    Job = (string) null,
                    HireDate = (DateTime?) null
                }
            };

            var result = Emps.Select(emp => new
            {
                emp.Ename,
                emp.Job,
                emp.HireDate
            }).Union(unionList);
        }

        //Find the employee with the highest salary using the Aggregate () method
        public void Task11()
        {
            Emp result = Emps.Aggregate((v1, v2) => v1.Salary > v2.Salary ? v1 : v2);
        }

        //Using the LINQ language and the SelectMany method, 
        //perform a CROSS JOIN join between collections Emps and Depts
        public void Task12()
        {
            var result = Emps
                .SelectMany(emp => Depts
                    .Select(dept => new
                    {
                        emp,
                        dept
                    }));
        }
    }
}
