using ApplicationForm.Data.Abstractions;
using ApplicationForm.Services.Contracts;
using ApplicationForm.Tests;
using Moq;

namespace ApplicationForm.Services.Tests.UserServiceTests
{
    /// <summary>
    /// Base class for UserService tests.
    /// </summary>
    public abstract class UserServiceTest : UnitTestContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserServiceTest"/> class.
        /// </summary>
        public UserServiceTest()
        {
            DbContext = new Mock<IDbContext>();

            UserService = new UserService(DbContext.Object);
        }

        protected Mock<IDbContext> DbContext { get; set; }

        protected IUserService UserService { get; set; }
    }
}
