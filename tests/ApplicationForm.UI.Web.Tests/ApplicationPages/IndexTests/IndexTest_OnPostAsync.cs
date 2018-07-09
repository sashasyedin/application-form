using ApplicationForm.UI.Web.Models;
using ApplicationForm.UI.Web.Pages.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationForm.UI.Web.Tests.ApplicationPages.IndexTests
{
    public class IndexTest_OnPostAsync : IndexTest
    {
        private int _callsToOnPostAsync;

        public IndexTest_OnPostAsync()
        {
            _callsToOnPostAsync = 1;
        }

        [Fact]
        public async Task OnPostAsync_UnderValidCircumstances_ExpectSuccess()
        {
            (Model as IndexModel).FormData = new FormData
            {
                Name = "Alex",
                Agreement = true,
                SectorsValues = new List<int> { 1, 2, 3 }
            };

            Stub();

            var actual = await Act();

            Assert.IsType<PageResult>(actual);
            AssertCore();
        }

        protected override void AssertCore()
        {
            base.AssertCore();

            UserService.Verify(
                service => service.CreateApplication(
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<IEnumerable<int>>()),
                Times.Exactly(_callsToOnPostAsync));
        }

        protected override void Stub()
        {
            base.Stub();

            UserService.Setup(
                service => service.CreateApplication(
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<IEnumerable<int>>()));
        }

        private Task<IActionResult> Act()
        {
            return Model.OnPostAsync();
        }
    }
}
