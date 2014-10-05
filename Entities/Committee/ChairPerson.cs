using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTAData.Entities
{
    [Serializable]
    public class ChairPerson
    {
        [Key]
        [Column(Order=1)]
        public string CommitteeName { get; set; }
        [Key]
        [Column(Order = 2)]
        public string MemberId { get; set; }

        [ForeignKey("MemberId")]
        public Member Member { get; set; }
        [ForeignKey("CommitteeName")]
        public Committee Committee { get; set; }
    }
}
