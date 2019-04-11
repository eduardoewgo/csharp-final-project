using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduardo_G_300999807.Models;
using Eduardo_G_300999807.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eduardo_G_300999807.Controllers
{
    public class HomeController : Controller
    {
        // Not sure if we should have multiples controllers at this point.
        private IClubRepository clubRepository;
        private IPlayerRepository playerRepository;
        private IFixtureRepository fixtureRepository;

        public HomeController(IClubRepository clubRepo, IPlayerRepository playerRepo, IFixtureRepository fixtureRepo)
        {
            clubRepository = clubRepo;
            playerRepository = playerRepo;
            fixtureRepository = fixtureRepo;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult ClubList()
        {            
            return View(clubRepository.Clubs);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ManagePlayers()
        {
            return View(playerRepository.Players);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AssociatePlayer(int playerId)
        {
            Player player = playerRepository.GetById(playerId);
            IEnumerable<Club> clubs = clubRepository.Clubs;

            AssociationViewModel associationViewModel = new AssociationViewModel(clubs, player);
            return View(associationViewModel);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult TransferLog(int playerId)
        {
            Player player = playerRepository.GetById(playerId);
            return View(player);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AssociatePlayer(AssociationViewModel association)
        {
            Club newClub = clubRepository.GetById(association.ClubId);
            playerRepository.AddToClub(association.Player, newClub);
            return View("ManagePlayers", playerRepository.Players);
        }

        [HttpGet]
        [Authorize(Roles = "General")]
        public ViewResult PlayerAdd()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "General")]
        public ViewResult PlayerAdd(Player player)
        {
            return View(playerRepository.Insert(player));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ViewResult ClubAdd()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult ClubAdd(Club club)
        {
            clubRepository.Insert(club);
            return RedirectToAction("ClubList", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ViewResult ClubDetails(int clubId)
        {
            return View(clubRepository.GetById(clubId));
        }

        [AllowAnonymous]
        public ViewResult FixtureList()
        {
            return View(fixtureRepository.Fixtures);
        }

        [Authorize(Roles = "Admin")]
        public ViewResult FixtureAdd()
        {
            return View(new FixtureAddViewModel() { Clubs = clubRepository.Clubs, Fixture = new Fixture() { MatchTime = DateTime.Now } });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult FixtureAdd(FixtureAddViewModel fixtureAddViewModel)
        {
            if (ModelState.IsValid)
            {
                fixtureAddViewModel.Fixture.Home = clubRepository.GetById(fixtureAddViewModel.HomeClubId);
                fixtureAddViewModel.Fixture.Away = clubRepository.GetById(fixtureAddViewModel.AwayClubId);
                fixtureRepository.Insert(fixtureAddViewModel.Fixture);
                return RedirectToAction("FixtureList", "Home");
            } else
            {
                // Not sure how can I pass this to the get method.
                ViewBag.Error = "Invalid values. Match not saved.";
                return RedirectToAction("FixtureAdd", "Home");
            }
            
        }

        [Authorize(Roles = "Admin")]
        public ViewResult FixtureSetScore(int fixtureId)
        {
            return View(fixtureRepository.GetById(fixtureId));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult FixtureSetScore(Fixture fixture)
        {
            fixtureRepository.SetScore(fixture);
            return RedirectToAction("FixtureList", "Home");
        }
    }
}