using ApplicationForm.Services.Models;
using System.Collections.Generic;

namespace ApplicationForm.Services.Contracts
{
    /// <summary>
    /// Defines the business-level operations for SectorService.
    /// </summary>
    public interface ISectorService
    {
        /// <summary>
        /// Lists the ordered sectors.
        /// </summary>
        /// <returns>The list of sectors.</returns>
        IList<Sector> ListOrderedSectors();
    }
}
