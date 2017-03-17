using Cubo.KartSolution.Domain.Commands.Results;
using Cubo.KartSolution.Domain.Entities;
using Cubo.KartSolution.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cubo.KartSolution.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly RaceRepository _repository;

        public HomeController()
        {
            _repository = new RaceRepository();
        }

        public ActionResult Index()
        {
            return View(_repository.GetRaceResult());
        }

        public ActionResult AverageSpeedRaceByPilot()
        {
            return PartialView("_AverageSpeedByPilot", _repository.GetAverageSpeedRaceByPilot());
        }

        public ActionResult BestLapByPilot()
        {
            return PartialView("_BestLapByPilot", _repository.GetBestLapByPilot());
        }

        public ActionResult BestLapByRace()
        {
            return PartialView("_BestLapByRace", _repository.GetBestLapByRace());
        }

        public ActionResult LogRace()
        {
            return View(_repository.GetLog());
        }

        
    }
}