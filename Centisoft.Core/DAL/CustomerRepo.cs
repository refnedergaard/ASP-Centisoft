﻿using Centisoft.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Core.DAL
{
    public class CustomerRepo : BaseRepo
    {
        public List<Customer> LoadAll()
        {
            return context.Customers.ToList();
        }

        public Customer Load(int id)
        {
            return context.Customers.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Customer c)
        {
            if (c.Id > 0)
            {
                context.Entry(c).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Customer c = Load(id);
            context.Customers.Remove(c);
        }
    }
}

