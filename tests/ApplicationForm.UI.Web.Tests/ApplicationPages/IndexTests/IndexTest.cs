using ApplicationForm.Services.Contracts;
using ApplicationForm.Tests;
using ApplicationForm.UI.Web.Pages.Application;
using Moq;

namespace ApplicationForm.UI.Web.Tests.ApplicationPages.IndexTests
{
    /// <summary>
    /// Base class for Index tests.
    /// </summary>
    public abstract class IndexTest : PageModelTest<IndexModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexTest"/> class.
        /// </summary>
        public IndexTest()
        {
            SectorService = new Mock<ISectorService>();
            UserService = new Mock<IUserService>();
            
            Model = new IndexModel(SectorService.Object, UserService.Object);
        }

        protected Mock<ISectorService> SectorService { get; set; }
        
        protected Mock<IUserService> UserService { get; set; }
    }
}
