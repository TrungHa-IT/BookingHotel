using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HotelBooking.Repositories;

namespace HotelBooking.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRoleRepositories _roleRepository;

        public RolesController(IRoleRepositories roleRepositories)
        {
            _roleRepository = roleRepositories; 
        }

        // GET: Roles
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, string searchName = "")
        {
            var roles = await _roleRepository.GetRolePagedAsync(pageNumber, pageSize, searchName);
            return View(roles);
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = await _roleRepository.GetRoleByIdAsync(id.Value);
            if (roles == null)
            {
                return NotFound();
            }

            return View(roles);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Roles role)
        {
            if (ModelState.IsValid)
            {
                await _roleRepository.CreateRoleAsync(role);
                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }


        

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _roleRepository.DeleteRoleAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        private bool RolesExists(int id)
        {
            return _roleRepository.GetRoleByIdAsync(id).Result != null;
        }

        // GET: Clubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _roleRepository.GetRoleByIdAsync(id.Value);
            if (club == null)
            {
                return NotFound();
            }
            return View(club);
        }

        // POST: Clubs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Roles role)
        {
            if (id != role.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {   
                    await _roleRepository.UpdateRoleAsync(role);
                }
                catch (KeyNotFoundException)
                {
                    if (!await _roleRepository.RoleExistAsync(role.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }
    }
}
