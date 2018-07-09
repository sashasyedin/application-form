using System.Collections.Generic;

namespace ApplicationForm.Services.Models
{
    /// <summary>
    /// Represents an Application.
    /// </summary>
    public class Application
    {
        public bool Agreement { get; set; }

        public string Name { get; set; }

        public IEnumerable<int> SectorsValues { get; set; }
    }
}
