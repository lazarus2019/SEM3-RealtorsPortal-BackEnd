using Microsoft.EntityFrameworkCore;
using NETAPI_SEM3.Entities;
using NETAPI_SEM3.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Services
{
	public class MemberServiceImpl : MemberService
	{
		#region Injection DB

		private ProjectSem3DBContext db;

		public MemberServiceImpl(ProjectSem3DBContext _db)
		{
			db = _db;
		}

		public bool changeMemberImage(int memberId, string photoName)
		{
			try
			{
				var member = db.Members.Find(memberId);
				member.Photo = photoName;
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool changePassword(int memberId, string password)
		{
			try
			{
				//var result = await _userManager.CreateAsync(user, request.Password);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool checkPasswordDB(int memberId, string password)
		{
			try
			{
				var member = db.Members.Find(memberId);
				//var isValidPassword = await _userManager.CheckPasswordAsync(member.Username, password);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool updateMember(Member member)
		{
			try
			{
				var oldMember = db.Members.Find(member.MemberId);
				oldMember.FullName = member.FullName;
				oldMember.Phone = member.Phone;
				oldMember.IsShowMail = member.IsShowMail;
				oldMember.Description = member.Description;
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public IEnumerable findMember(int memberId)
		{
			return db.Members.Where(member => member.MemberId == memberId).Select(
				member => new
				{
					MemberId = member.MemberId,
					Username = member.Username,
					//RoleId = member.RoleId,
					FullName = member.FullName,
					Phone = member.Phone,
					Description = member.Description,
					IsShowMail = member.IsShowMail,
					Email = member.Email,
					Status = member.Status,
					Photo = member.Photo
				}
				);
		}

		#endregion


		public bool CreateMember(Member member)
		{
			try
			{
				if (member != null)
				{
					db.Members.Add(member);
					db.SaveChanges();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public IEnumerable<Member> GetAllMember()
		{
			return db.Members.Where(m => m.RoleId != "1").ToList();
		}

		public int GetMemberId(string userId)
		{
			return db.Members.FirstOrDefault(m => m.AccountId.Equals(userId)).MemberId;
		}

		public IEnumerable<Member> SearchMember(string fullName, string roleId, string status)
		{
			try
			{

				IEnumerable<Member> members = db.Members.Where(m => m.RoleId != "1").ToList();
				if (!fullName.Equals(".all"))
				{
					members = members.Where(m => m.FullName.ToLower().Contains(fullName.ToLower())).ToList();
				}

				if (!roleId.Equals("all"))
				{
					members = members.Where(m => m.RoleId == roleId).ToList();
				}
				if (!status.Equals("all"))
				{
					members = members.Where(m => m.Status == bool.Parse(status));
				}
				return members;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);

				return null;
			}
		}

		public bool UpdateStatus(int id, bool status)
		{
			try
			{
				var member = db.Members.Find(id);
				if (status == true)
				{
					member.Status = false;
				}
				else if (status == false)
				{
					member.Status = true;
				}
				db.Members.Update(member);
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public IEnumerable findUser(string userId)
		{
			try
			{
				return db.Members.Where(m => m.AccountId.Equals(userId)).Select(
				member => new
				{
					MemberId = member.MemberId,
					Username = member.Username,
					//RoleId = member.RoleId,
					FullName = member.FullName,
					Phone = member.Phone,
					Description = member.Description,
					IsShowMail = member.IsShowMail,
					Email = member.Email,
					Status = member.Status,
					Photo = member.Photo
				}
				);
			}
			catch
			{
				return null;
			}
		}
	}
}
