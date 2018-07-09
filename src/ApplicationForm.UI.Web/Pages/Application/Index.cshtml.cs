using ApplicationForm.Services.Contracts;
using ApplicationForm.Services.Models;
using ApplicationForm.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationForm.UI.Web.Pages.Application
{
    public class IndexModel : PageModel
    {
        private const string NotSaved = "Not saved";
        private const string Saved = "Saved";

        private readonly ISectorService _sectorService;
        private readonly IUserService _userService;

        public IndexModel(
            ISectorService sectorService,
            IUserService userService)
        {
            _sectorService = sectorService;
            _userService = userService;
        }

        [BindProperty]
        public FormData FormData { get; set; }

        [BindProperty]
        public string Message { get; private set; }

        [BindProperty]
        public IList<Sector> SectorOptions
        {
            get { return _sectorService.ListOrderedSectors(); }
        }

        public void OnGet()
        {
            Message = NotSaved;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateApplication(FormData.Name, FormData.Agreement, FormData.SectorsValues);
                Message = Saved;
            }

            return Page();
        }
    }
}
