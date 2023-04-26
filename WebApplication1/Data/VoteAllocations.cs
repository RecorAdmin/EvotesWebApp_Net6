using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    public class VoteAllocations : BaseEntity
    {

        [ForeignKey("CandidateId")]
        public Candidates Candidates { get; set; }
        public int CandidatesId { get; set; }
        public int voteCount { get; set; }
    }
}
