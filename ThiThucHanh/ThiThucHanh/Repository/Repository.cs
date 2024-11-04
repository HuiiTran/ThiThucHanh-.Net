using ThiThucHanh.Models;

namespace ThiThucHanh.Repository
{
    public class Repository : IRepository
    {
        public readonly QlbanHangThiContext qlbanHangThiContext;
        public Repository(QlbanHangThiContext qlbanHangThiContext)
        {
            this.qlbanHangThiContext = qlbanHangThiContext;
        }

        public TLoaiSp Add(TLoaiSp sp)
        {
            qlbanHangThiContext.Add(sp);
            qlbanHangThiContext.SaveChanges();
            return sp;
        }
        public TLoaiSp Delete(TLoaiSp sp)
        {
            throw new NotImplementedException();
        }

        public TLoaiSp Update(TLoaiSp sp)
        {
            qlbanHangThiContext.Update(sp);
            qlbanHangThiContext.SaveChanges() ;
            return sp;
        }
        public TLoaiSp GetLoaiSp(TLoaiSp sp)
        {
            return qlbanHangThiContext.TLoaiSps.Find(sp);
        }

        public IEnumerable<TLoaiSp> GetAll()
        {
            return qlbanHangThiContext.TLoaiSps;
        }

        
    }
}
