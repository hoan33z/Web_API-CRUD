using AppData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        Ph24402DbContext dbContext = new Ph24402DbContext();
        public DbSet<NhanVien> nhanViens;

        public NhanVienController()
        {
            nhanViens=dbContext.NhanViens;
        }

        //GET: api/<NhanVirnController>
        [HttpGet]
        public IEnumerable<NhanVien> Get()
        {
            return nhanViens.ToList();
        }
        [HttpGet("{id}")]
        public NhanVien Get(Guid id)
        { 
           return nhanViens.FirstOrDefault(p => p.ID == id);
        }

        //POST api/<NhanVirnController>
        [HttpPost("create")]
        public bool Post(NhanVien nv)
        {
            NhanVien sp = new NhanVien();
            sp.ID = Guid.NewGuid();
            sp.Tuoi = nv.Tuoi; sp.Ten = nv.Ten;
            sp.Role = nv.Role; sp.Luong = nv.Luong;
            sp.TrangThai = nv.TrangThai; sp.Email = nv.Email;
            try
            {
                nhanViens.Add(sp);   // Thêm vào Dbset
                dbContext.SaveChanges();  // Lưu lại trạng thái thay đổi DbContext
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //PUT api/<NhanVirnController>/5
        [HttpPut("update")]
        public bool Put(NhanVien nv)
        {
            var sp = nhanViens.First(p => p.ID == nv.ID);
            sp.Tuoi = nv.Tuoi; sp.Ten = nv.Ten;
            sp.Role = nv.Role; sp.Luong = nv.Luong;
            sp.TrangThai = nv.TrangThai; sp.Email = nv.Email;
            try
            {
                nhanViens.Update(sp);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //DELETE api/<NhanVirnController>/5
        [HttpGet("delete/{id}")]
        public bool Delete(Guid id)
        {
            var sp = nhanViens.First(p => p.ID == id);
            try
            {
                nhanViens.Remove(sp);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
