using Microsoft.AspNetCore.Mvc;
using ThiThucHanh.Repository;
namespace ThiThucHanh.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly IRepository repository;

        public LoaiSpMenuViewComponent(IRepository repository)
        {
            this.repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var loaisp = repository.GetAll().OrderBy(x => x.Loai);
            return View(loaisp);
        }
    }
}
