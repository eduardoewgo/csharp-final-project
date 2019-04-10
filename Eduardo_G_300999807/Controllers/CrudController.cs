using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduardo_G_300999807.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eduardo_G_300999807.Controllers
{
    public class CrudController : Controller
    {
        private IClubRepository clubRepository;
        private IPlayerRepository playerRepository;

        public CrudController(IClubRepository clubRepo, IPlayerRepository playerRepo)
        {
            clubRepository = clubRepo;
            playerRepository = playerRepo;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ViewResult UpdateClub(int clubId)
        {
            return View(clubRepository.GetById(clubId));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult UpdateClub(Club club)
        {
            clubRepository.Update(club);
            return RedirectToAction("ClubList", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ViewResult DeleteClub(int clubId)
        {
            ViewBag.RecordsDeleted = clubRepository.Delete(clubId);
            return View();
        }
    }
}