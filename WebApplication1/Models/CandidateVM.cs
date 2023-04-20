using DocuSign.eSign.Model;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication1.Models
{
    public class CandidateVM
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string? firstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string? lastName { get; set; }
        public string? Constituency { get; set; }  

    }
}
