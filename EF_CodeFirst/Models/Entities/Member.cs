using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Member
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public DateTime MemberDateOfBirth { get; set; }
        public string MemberPhoneNumber { get; set; }
        public string MemberMail { get; set; }
        public DateTime MemberJoinDate { get; set; }
        public string MemberJob { get; set; }
        public bool IsDeleted { get; set; }

    }
}