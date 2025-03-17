using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        List<Member> GetAll();
        Member Get(int id);
        Boolean Add(Member member);
        Boolean Delete(int id);
        Boolean Update(Member member);
        Member auth(string email, string password);
    }
}
