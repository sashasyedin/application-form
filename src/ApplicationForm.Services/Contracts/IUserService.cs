using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationForm.Services.Contracts
{
    /// <summary>
    /// Defines the business-level operations for UserService.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates the application.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="agreed">If set to <c>true</c> agreed to terms.</param>
        /// <param name="sectorsValues">The sectors values.</param>
        Task CreateApplication(string name, bool agreed, IEnumerable<int> sectorsValues);
    }
}
