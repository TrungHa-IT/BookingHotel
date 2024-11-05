using HotelBooking.Models;
using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelBooking.Controllers
{
    public class VoucherController : Controller
    {

        private readonly IVoucherRepositories _voucherRepositories;
       
        public VoucherController(IVoucherRepositories voucherRepositories)
        {
            _voucherRepositories = voucherRepositories;
        }
        public async Task<IActionResult> Index()
        {
            var sc = await _voucherRepositories.GetAllVoucherAsync();
            return View(sc);
        }

        //Create/CategoriesRoom
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Voucher voucher)
        {
            if (!ModelState.IsValid)
            {
                voucher.CreateAt = DateTime.Now;
                voucher.Status = 1;
               
                await _voucherRepositories.CreateVoucherAsync(voucher);
                return RedirectToAction(nameof(Index));
            }
            return View(voucher);
        }
        //Details/CategoriesRoom
        public async Task<IActionResult> Details(int id)
        {
            var vc = await _voucherRepositories.GetVoucherByIdAsync(id);
            return vc == null ? NotFound() : View(vc);
        }
        //Edits/CategoriesRoom
        public async Task<IActionResult> Edit(int id)
        {
            var vc = await _voucherRepositories.GetVoucherByIdAsync(id);
            return vc == null ? NotFound() : View(vc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Voucher voucher)
        {
            await _voucherRepositories.UpdateVoucherAsync(voucher);
            return RedirectToAction(nameof(Index));
        }
        //Delete/CategoriesRoom
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vc = await _voucherRepositories.GetVoucherByIdAsync(id);
            if (vc == null) return NotFound();
            await _voucherRepositories.DeleteVoucherAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
