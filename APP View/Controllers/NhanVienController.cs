using APP_View.Controllers;
using AppData;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly ILogger<NhanVienController> _logger;

        public NhanVienController(ILogger<NhanVienController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddNhanVien()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNhanVien(NhanVien nv)
        {
            string apiUrl = "https://localhost:7112/api/NhanVien/create";
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.PostAsJsonAsync(apiUrl, nv);// Lấy dữ liệu ra
            return RedirectToAction("GetAllNhanVien");
        }
        public async Task<IActionResult> GetAllNhanVien()
        {
            string apiUrl = "https://localhost:7112/api/NhanVien";
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.GetAsync(apiUrl);// Lấy dữ liệu ra
            //Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            //Lấy kqua trả về từ API
            // Đọc từ string Json vừa thu được sang List<T>
            var nhanviens = JsonConvert.DeserializeObject<List<NhanVien>>(apiData);
            return View(nhanviens);
        }

        [HttpGet]
        public async Task<IActionResult> DetailNhanVien(Guid id)
        {
            string apiUrl = "https://localhost:7112/api/NhanVien/" + id;
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.GetAsync(apiUrl);// Lấy dữ liệu ra
                                                             // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kqua trả về từ API
            // Đọc từ string Json vừa thu được sang List<T>
            var nhanviens = JsonConvert.DeserializeObject<NhanVien>(apiData);
            return View(nhanviens);
        }
        [HttpGet]
        public async Task<IActionResult> EditNhanVien(Guid id)
        {
            string apiUrl = "https://localhost:7112/api/NhanVien/" + id;
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.GetAsync(apiUrl);// Lấy dữ liệu ra
                                                             // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kqua trả về từ API
            // Đọc từ string Json vừa thu được sang List<T>
            var sanphams = JsonConvert.DeserializeObject<NhanVien>(apiData);
            return View(sanphams);

        }
        [HttpPost]
        public async Task<IActionResult> EditNhanVien(NhanVien nv)
        {
            string apiUrl = "https://localhost:7112/api/NhanVien/update";
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.PutAsJsonAsync(apiUrl, nv);// Lấy dữ liệu ra
                                                                       // Lấy dữ liệu Json trả về từ Api được call dạng string
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllNhanVien");
            }
            return View("EditNhanVien");
        }
        //[HttpDelete]
        public async Task<IActionResult> DeleteNhanVien(Guid id)
        {
            string apiUrl = "https://localhost:7112/api/NhanVien/delete/" + id;
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.GetAsync(apiUrl);// Lấy dữ liệu ra
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllNhanVien");
            }
            return View("Index");
        }
    }
}
