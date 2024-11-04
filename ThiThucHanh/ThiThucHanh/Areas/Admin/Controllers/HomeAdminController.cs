using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThiThucHanh.Models;
using X.PagedList;

namespace ThiThucHanh.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QlbanHangThiContext db = new QlbanHangThiContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listSanPham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> listSpPage = new PagedList<TDanhMucSp>(listSanPham, pageNumber, pageSize);


            return View(listSpPage);
        }
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu","ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");



            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(TDanhMucSp sanpham)
        {
            if(ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanpham);
        }

        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(string maSanPham)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");

            var sanPham = db.TDanhMucSps.Find(maSanPham);


            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TDanhMucSp sanpham)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Update(sanpham);
                //db.Entry(sanPham).State = EnitiyState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            return View(sanpham);
        }

        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(string maSanPham)
        {
            TempData["Message"] = "";
            var chiTietSanPham = db.TChiTietSanPhams.Where(x => x.MaSp == maSanPham).ToList();
            if(chiTietSanPham.Count > 0)
            {
                TempData["Message"] = "Khong xoa duoc san pham nay";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSanPham);
            if (anhSanPham.Any())
            {
                db.RemoveRange(anhSanPham);
            }
            db.Remove(db.TDanhMucSps.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "Da xoa san pham nay";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");

        }

        [Route("ChiTietSanPham")]
        [HttpGet]
        public IActionResult ChiTietSanPham(string maSp)
        {
            var sanPham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
            var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
            ViewBag.anhSanPham = anhSanPham;
            return View(sanPham);
        }



        //Danhsachnguoidung

        [Route("danhsachnguoidung")]
        public IActionResult DanhSachNguoiDung(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listNguoiDung = db.TKhachHangs.AsNoTracking().OrderBy(x => x.TenKhachHang);
            PagedList<TKhachHang> listSpPage = new PagedList<TKhachHang>(listNguoiDung, pageNumber, pageSize);


            return View(listSpPage);
        }
        [Route("ThemNguoiDungMoi")]
        [HttpGet]
        public IActionResult ThemNguoiDungMoi()
        {
            /*ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");

*/

            return View();
        }
        [Route("ThemNguoiDungMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNguoiDungMoi(TKhachHang Khach)
        {
            if (ModelState.IsValid)
            {
                db.TKhachHangs.Add(Khach);
                db.SaveChanges();
                return RedirectToAction("DanhSachNguoiDung");
            }
            return View(Khach);
        }

        [Route("SuaNguoiDung")]
        [HttpGet]
        public IActionResult SuaNguoiDung(string maKhachHang)
        {
            /*ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");*/

            var sanPham = db.TKhachHangs.Find(maKhachHang);


            return View(maKhachHang);
        }
        [Route("SuaNguoiDung")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNguoiDung(TKhachHang khach)
        {
            if (ModelState.IsValid)
            {
                db.TKhachHangs.Update(khach );
                //db.Entry(sanPham).State = EnitiyState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSachNguoiDung", "HomeAdmin");
            }
            return View(khach);
        }

        [Route("XoaNguoiDung")]
        [HttpGet]
        public IActionResult XoaNguoiDung(string maKhachHang)
        {
            TempData["Message"] = "";
           
            db.Remove(db.TKhachHangs.Find(maKhachHang));
            db.SaveChanges();
            TempData["Message"] = "Da xoa san pham nay";
            return RedirectToAction("DanhSachNguoiDung", "HomeAdmin");

        }

        [Route("ChiTietNguoiDung")]
        [HttpGet]
        public IActionResult ChiTietNguoiDung(string maKhachHang)
        {
            var khach = db.TKhachHangs.SingleOrDefault(x => x.MaKhanhHang == maKhachHang);
            return View(khach);
           
        }
    }
}
