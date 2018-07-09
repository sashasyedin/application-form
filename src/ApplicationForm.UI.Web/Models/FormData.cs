using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationForm.UI.Web.Models
{
    /// <summary>
    /// The FormData ViewModel. 
    /// </summary>
    public class FormData
    {
        [Required]
        [Display(Name = "Agree to terms")]
        [Compare("IsTrue", ErrorMessage = "Please agree to terms.")]
        public bool Agreement { get; set; }

        public bool IsTrue => true;

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Sectors")]
        public IEnumerable<int> SectorsValues { get; set; }
    }
}
