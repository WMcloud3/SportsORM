using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.Problome1 = _context.Leagues
                .Where(leauge => leauge.Name.Contains("Women"))
                .ToList();

            // ...all leagues where sport is any type of hockey
            ViewBag.Problome2 = _context.Leagues
                .Where(leauge => leauge.Sport.Contains("Hockey"))
                .ToList();

            // ...all leagues where sport is something OTHER THAN football
            // ViewBag.Problome3 = _context.Leagues
            //     .Where(leauge => leauge.Sport.Except("Fooball"))
            //     .ToList();

            // ...all leagues that call themselves "conferences"
            ViewBag.Problome4 = _context.Leagues
                .Where(leauge => leauge.Name.Contains("Conference"))
                .ToList();

            // ...all leagues in the Atlantic region
            ViewBag.Problome5 = _context.Leagues
                .Where(leauge => leauge.Name.Contains("Atlantic"))
                .ToList();

            // ...all teams based in Dallas
            ViewBag.Problome6 = _context.Teams
                .Where(team => team.Location == "Dallas")
                .ToList();

            // ...all teams named the Raptors
            ViewBag.Problome7 = _context.Teams
                .Where(team => team.TeamName.Contains("Raptors"))
                .ToList();

            // ...all teams whose location includes "City"
            ViewBag.Problome8 = _context.Teams
                .Where(team => team.Location.Contains("City"))
                .ToList();

            // ...all teams whose names begin with "T"
            ViewBag.Problome9 = _context.Teams
                .Where(team => team.TeamName.StartsWith("T"))
                .ToList();

            // ...all teams, ordered alphabetically by location
            ViewBag.Problome10 = _context.Teams
                .OrderBy(team => team.Location)
                .ToList();

            // ...all teams, ordered by team name in reverse alphabetical order
            ViewBag.Problome11 = _context.Teams
                .OrderByDescending(team => team.TeamName)
                .ToList();

            // ...every player with last name "Cooper"
            ViewBag.Problome12 = _context.Players
                .Where(player => player.LastName.Contains("Cooper"))
                .ToList();

            // ...every player with first name "Joshua"
            ViewBag.Problome13 = _context.Players
                .Where(player => player.FirstName.Contains("Joshua"))
                .ToList();

            // ...every player with last name "Cooper" EXCEPT those with "Joshua" as the first name
            // ViewBag.Problome14 = _context.Players
            //     .Where(player => player.LastName.Contains("Cooper"))
            //     .Except(player.FirstName.Contains("Joshua"))
            //     .ToList();

            // ...all players with first name "Alexander" OR first name "Wyatt"


            return View();
        }


        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            // ...all teams, past and present, that Samuel Evans has played with
            // ViewBag.Sam = _context.Players
            //     .Include(player => player.CurrentTeam)
            //     .Include(player => player.AllTeam)
            //     .ThenInclude(player => pt.TeamofPlayer)
            //     .FirstorDefault(Player => player.FirstName == "Samuel" && player.LastName =="Evans");

            return View();
        }

    }
}