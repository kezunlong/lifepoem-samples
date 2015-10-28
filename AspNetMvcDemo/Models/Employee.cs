using Lifepoem.Foundation.Utilities.DBHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcDemo.Models
{
    /// <summary>
    /// Test Model
    /// </summary>
    public class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Remark { get; set; }
    }


    public class EmployeeManager
    {
        public List<Employee> SelectEmployees(PagingOption option)
        {
            if (option.GetRecordCount)
            {
                option.RecordCount = 1000;

                if (option.RecordCount < option.Start)
                {
                    option.RecordCount = option.Start;
                }
            }

            List<Employee> list = new List<Employee>();

            for (int index = option.Start; index < option.Start + option.Length; index++)
            {
                list.Add(new Employee
                {
                    Name = "Name " + index.ToString(),
                    Email = string.Format("Email{0}@163.com", index),
                    Telephone = "1234567"
                });
            }

            return list;
        }
    }
}