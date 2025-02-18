
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Authorization;
using HotelBooking.Repositories;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace HotelBooking.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepositories _bookingRepositories;

        public BookingController(IBookingRepositories bookingRepositories)
        {
            _bookingRepositories = bookingRepositories;
        }

        public async Task<IActionResult> Index()
        {
            var display = await _bookingRepositories.GetAllBookingsAsync();
            return View(display);
        }

        // Create / BookAble
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                booking.CreateAt = DateTime.Now;
                await _bookingRepositories.CreateBookingAsync(booking);
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        //detail
        public async Task<IActionResult> Details(int id)
        {
            var booking = await _bookingRepositories.GetBookingsByIdAsync(id);
            return booking == null ? NotFound() : View(booking);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Booking booking)
        {
            await _bookingRepositories.UpdateBookingAsync(booking);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteCofirmed(int id)
        {
            var booking = await _bookingRepositories.GetBookingsByIdAsync(id);

            if (booking != null)
            {
                await _bookingRepositories.DeleteBookingAsync(id);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

    }
}