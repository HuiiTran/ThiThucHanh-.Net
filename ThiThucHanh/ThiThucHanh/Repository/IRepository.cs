using ThiThucHanh.Models;

namespace ThiThucHanh.Repository
{
    public interface IRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp Delete(TLoaiSp loaiSp);
        TLoaiSp GetLoaiSp(TLoaiSp loaiSp);
        IEnumerable<TLoaiSp> GetAll();
    }
}
