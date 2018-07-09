using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Moq;

namespace ApplicationForm.Tests
{
    /// <summary>
    /// Base class for unit tests that related to PageModel.  
    /// </summary>
    public abstract class PageModelTest<T> : UnitTestContainer
        where T : PageModel
    {
        protected T Model { get; set; }
        
        protected override void Stub()
        {
            base.Stub();

            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageContext = new PageContext(actionContext) { ViewData = viewData };

            Model.PageContext = pageContext;
            Model.TempData = tempData;
        }
    }
}
