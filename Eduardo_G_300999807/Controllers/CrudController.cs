using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduardo_G_300999807.Models;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult UpdateClub(int clubId)
        {
            return View(clubRepository.GetById(clubId));
        }

        [HttpPost]
        public ViewResult UpdateClub(Club club)
        {
            clubRepository.Update(club);
            ViewBag.isUpdated = true;
            return View();
        }

        public ViewResult DeleteClub(int clubId)
        {
            ViewBag.RecordsDeleted = clubRepository.Delete(clubId);
            return View();
        }
    }
}