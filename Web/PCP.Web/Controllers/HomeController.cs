namespace PCP.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using PCP.Services.Data;
    using PCP.Web.ViewModels;
    using PCP.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ICPUService cpuService;
        private readonly IMotherboardService motherboardService;
        private readonly IGPUService gpuService;

        public HomeController(
            ICPUService cpuService,
            IMotherboardService motherboardService,
            IGPUService gpuService)
        {
            this.cpuService = cpuService;
            this.motherboardService = motherboardService;
            this.gpuService = gpuService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                RandomProducts = new RandomProductsViewModel(),
            };
            viewModel.RandomProducts.CPUs = this.cpuService.GetRandom<BasicInfoViewModel>(4);
            viewModel.RandomProducts.Motherboards = this.motherboardService.GetRandom<BasicInfoViewModel>(4);
            viewModel.RandomProducts.GPUs = this.gpuService.GetRandom<BasicInfoViewModel>(4);
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
