using ApplicationForm.Data.Abstractions;
using ApplicationForm.Services.Contracts;
using ApplicationForm.Tests;
using Moq;

namespace ApplicationForm.Services.Tests.SectorServiceTests
{
    /// <summary>
    /// Base class for SectorService tests.
    /// </summary>
    public abstract class SectorServiceTest : UnitTestContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SectorServiceTest"/> class.
        /// </summary>
        public SectorServiceTest()
        {
            DbContext = new Mock<IDbContext>();

            SectorService = new SectorService(DbContext.Object);
        }

        protected Mock<IDbContext> DbContext { get; set; }

        protected ISectorService SectorService { get; set; }
    }
}
