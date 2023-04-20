using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    public class Voters:BaseEntity
    {
        public int TRN { get; set; }

        [ForeignKey("CandidateId")]
        public Candidates Candidates { get; set; }
        public int candidateId { get; set; }
    }
}
