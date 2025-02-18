
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
        private readonly IBookAbleRepositories _bookAbleRepositories;

        public BookingController(IBookAbleRepositories bookAbleRepositories)
        {
            _bookAbleRepositories = bookAbleRepositories;
        }

        public async Task<IActionResult> Index()
        {
            var display = await _bookAbleRepositories.GetAllBookAbleAsync();
            return View(display);
        }

        // Create / BookAble
        public IActionResult Create()
        {
            return View();
        }

        // [HttpPost]
        // [ValidateAntiForgeryToken]

        // public async Task<IActionResult> Create (Booking booking){
        //     if(!ModelState.IsValid){
        //         booking.
        //     }
        // }
    
    }
}