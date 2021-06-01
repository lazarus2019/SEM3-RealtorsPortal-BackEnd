using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public interface MemberService
	{
		public bool changeMemberImage(int memberId, string photoName);

		public IEnumerable findMember(int memberId);
		public IEnumerable findUser(string userId);

		public bool updateMember(Member member);
		public bool checkPasswordDB(int memberId, string password);
		public bool changePassword(int memberId, string password);

		public IEnumerable<Member> GetAllMember();
		public IEnumerable<Member> SearchMember(string fullName, string roleId, string status);
		public bool UpdateStatus(int id, bool status);
		public int GetMemberId(string userId);
		public bool CreateMember(Member member);
	}
}
