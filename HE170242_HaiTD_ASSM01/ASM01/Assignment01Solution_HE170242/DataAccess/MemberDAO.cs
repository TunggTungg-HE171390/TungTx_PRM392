using AutoMapper.Execution;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        public static BusinessObject.Member GetMemberLogin(string email, string password)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            if(email == config["AdminAccount:Email"] && password == config["AdminAccount:Password"])
            {
                return new BusinessObject.Member
                        { MemberId = 0,
                            Email = email,
                            Passsword = password,
                            Country = "",
                            City = "",
                            CompanyName = ""};
            }
            using (var context = new EStoreContext()) {
                return context.Members.FirstOrDefault(m => m.Email == email & m.Passsword == password);
            }
        }
        public static List<BusinessObject.Member> GetAll()
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    var list = context.Members.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static BusinessObject.Member Get(int id)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    var mem = context.Members.FirstOrDefault(m => m.MemberId == id);
                    return mem;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Boolean Add(BusinessObject.Member member) {
            try
            {
                using (var context = new EStoreContext())
                {
                   context.Members.Add(member);
                   int rows = context.SaveChanges();
                    if (rows > 0) return true;
                    else return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Boolean Delete(int id) {
            try
            {
                using (var context = new EStoreContext())
                {
                    BusinessObject.Member mem = Get(id);
                    if (mem != null)
                    {
                        context.Members.Remove(mem);
                        int rows = context.SaveChanges();
                        if (rows > 0) return true;
                        else return false;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Boolean Update(BusinessObject.Member member)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    context.Entry<BusinessObject.Member>(member).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    int rows = context.SaveChanges();
                    if (rows > 0) return true;
                    else return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
