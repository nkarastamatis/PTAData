using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTAData.Entities
{
    /// <summary>
    /// Summary description for Student
    /// </summary>
    public class Student
    {
        public Student()
        {
            //
            // TODO: Add constructor logic here
            //

            StudentId = Guid.NewGuid().ToString();
        }

        public string MembershipId { get; set; }
        public string StudentId { get; set; }
        public PersonName Name { get; set; }
        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}

//public class MemberStudent
//{
//    public string MemberId { get; set; }
//    public Member Member { get; set; }
//    public string StudentId { get; set; }
//    public Student Student { get; set; }
//}