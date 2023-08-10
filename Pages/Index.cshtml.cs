using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstateApp.Models;
using RealEstateApp.Services;

namespace RealEstateApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EstateService _estateService;

        public IList<Estate> Estates { get; set; }

        public IndexModel(ILogger<IndexModel> logger, EstateService estateService)
        {
            _logger = logger;
            _estateService = estateService;
        }

        public void OnGet()
        {
            Estates = _estateService.GetAll().ToList();
        }
    }
}