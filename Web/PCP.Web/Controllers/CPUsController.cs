namespace PCP.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PCP.Services.Data;
    using PCP.Web.ViewModels;
    using PCP.Web.ViewModels.CPUs;

    public class CPUsController : BaseController
    {
        private readonly ICPUService cpuService;

        public CPUsController(ICPUService cpuService)
        {
            this.cpuService = cpuService;
        }

        public IActionResult All(int id)
        {
            if (id <= 0)
            {
                id = 1;
            }

            var productsPerPage = 20;
            var viewModel = new CPUsViewModel
            {
                CPUs = this.cpuService.GetAll<BasicInfoViewModel>(id, productsPerPage),
                PagingViewModel = new PagingViewModel
                {
                    PageNumber = id,
                    ProductsPerPage = productsPerPage,
                    ProductsCount = this.cpuService.GetProductsCount(),
                },
            };
            var pagesCount = viewModel.PagingViewModel.PagesCount;
            if (id > pagesCount)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        public IActionResult ById(string id)
        {
            var viewModel = this.cpuService.GetById<CPUViewModel>(id);
            return this.View(viewModel);
        }
    }
}
