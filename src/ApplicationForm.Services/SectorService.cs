using ApplicationForm.Data.Abstractions;
using ApplicationForm.Services.Contracts;
using ApplicationForm.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationForm.Services
{
    /// <summary>
    /// Provides the business-level operations for SectorService.
    /// </summary>
    public class SectorService : ISectorService
    {
        private readonly IDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SectorService"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public SectorService(IDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Lists the ordered sectors.
        /// </summary>
        /// <returns>The list of sectors.</returns>
        IList<Sector> ISectorService.ListOrderedSectors()
        {
            var sectors = _context.Sectors
                .Include(s => s.Children)
                .ToList()
                .Where(s => s.ParentId.HasValue == false);

            var sorted = new List<Sector>();
            FlattenSectorsTree(sectors);
            return sorted;

            void FlattenSectorsTree(IEnumerable<Data.Entities.Sector> source, int level = 0)
            {
                if (source == null)
                    return;

                source = source.OrderBy(s => s.Title);

                foreach (var sector in source)
                {
                    sorted.Add(new Sector(sector.Id) { Title = sector.Title, Value = sector.Value, Level = level });
                    FlattenSectorsTree(sector.Children, level + 1);
                }
            }
        }
    }
}
