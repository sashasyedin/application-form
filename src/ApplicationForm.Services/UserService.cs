using ApplicationForm.Data.Abstractions;
using ApplicationForm.Data.Entities;
using ApplicationForm.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace ApplicationForm.Services
{
    /// <summary>
    /// Provides the business-level operations for UserService.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public UserService(IDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Creates the application.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="agreed">If set to <c>true</c> agreed to terms.</param>
        /// <param name="sectorsValues">The sectors values.</param>
        /// <returns>The application.</returns>
        async Task IUserService.CreateApplication(string name, bool agreed, IEnumerable<int> sectorsValues)
        {
            using (var scope = new TransactionScope(
                TransactionScopeOption.Required,
                TransactionScopeAsyncFlowOption.Enabled))
            {
                var user = new User { Agreement = agreed, Name = name };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                var userSectors = _context.Sectors
                    .Where(s => sectorsValues.Contains(s.Value))
                    .Select(s => new UserSector { UserId = user.Id, SectorId = s.Id })
                    .ToList();

                _context.AttachRange(userSectors);
                userSectors.ForEach(us => { user.UserSectors.Add(us); });

                await _context.SaveChangesAsync();

                scope.Complete();
            }
        }
    }
}
