using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PTAData.Entities
{
    public class CommitteeEntry
    {
        [Key]
        public string EntryId { get; set; }
        public string CommitteeName { get; set; }
        public string EntryTitle { get; set; }
        public string EntryBody { get; set; }
    }
}
