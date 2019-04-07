using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduardo_G_300999807.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eduardo_G_300999807.Controllers
{
    public class HomeController : Controller
    {
        // Not sure if we should have multiples controllers at this point.
        private IClubRepository clubRepository;
        private IPlayerRepository playerRepository;

        public HomeController(IClubRepository clubRepo, IPlayerRepository playerRepo)
        {
            clubRepository = clubRepo;
            playerRepository = playerRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClubList()
        {            
            return View(FetchClubs());
        }

        [Authorize]
        public IActionResult ManagePlayers()
        {
            return View(FetchPlayers());
        }

        [Authorize]
        public IActionResult AssociatePlayer(int playerId)
        {
            Player player = playerRepository.GetById(playerId);
            IEnumerable<Club> clubs = clubRepository.Clubs;

            AssociationViewModel associationViewModel = new AssociationViewModel(clubs, player);
            return View(associationViewModel);
        }

        [HttpPost]
        public IActionResult AssociatePlayer(AssociationViewModel association)
        {
            Club newClub = clubRepository.GetById(association.ClubId);
            playerRepository.AddToClub(association.Player, newClub);
            return View("ManagePlayers", FetchPlayers());
        }

        [HttpGet]
        [Authorize]
        public ViewResult PlayerAdd()
        {
            return View();
        }

        [HttpPost]
        public ViewResult PlayerAdd(Player player)
        {
            return View(playerRepository.Insert(player));
        }

        [HttpGet]
        [Authorize]
        public ViewResult ClubAdd()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ViewResult ClubAdd(Club club)
        {
            return View(clubRepository.Insert(club));
        }        

        public ViewResult ClubDetails(int clubId)
        {
            return View(clubRepository.GetById(clubId));
        }

        public List<Club> FetchClubs()
        {
            List<Club> clubs = new List<Club>();
            foreach (Club c in clubRepository.Clubs)
            {
                c.Players = clubRepository.GetPlayersByClubId(c.ClubId).ToList();
                clubs.Add(c);
            }
            return clubs;
        }

        public List<Player> FetchPlayers()
        {
            List<Player> players = new List<Player>();
            foreach (Player p in playerRepository.Players)
            {
                if (p.ClubId != null) p.Club = clubRepository.GetById(p.ClubId);
                players.Add(p);
            }
            return players;
        }
    }
}