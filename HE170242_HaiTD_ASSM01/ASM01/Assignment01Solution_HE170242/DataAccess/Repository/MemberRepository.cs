using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public bool Add(Member member) => MemberDAO.Add(member);

        public Member auth(string email, string password) => MemberDAO.GetMemberLogin(email, password);

        public bool Delete(int id) => MemberDAO.Delete(id);

        public Member Get(int id) => MemberDAO.Get(id);

        public List<Member> GetAll() => MemberDAO.GetAll();

        public bool Update(Member member) => MemberDAO.Update(member);
    }
}
