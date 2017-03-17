using Cubo.KartSolution.Domain.Entities;
using Cubo.KartSolution.Domain.Scopes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cubo.KartSolution.Tests.Scopes
{
    [TestClass]
    public class RaceSpecTests
    {
        private Race _validRace = new Race(DateTime.Now, 038, "F.MASSA", 1, new TimeSpan(1, 02, 852), 44.275m);
        private Race _invalidPilotCode = new Race(DateTime.Now, 0, "F.MASSA", 1, new TimeSpan(1, 02, 852), 44.275m);
        private Race _invalidPilotName = new Race(DateTime.Now, 038, "", 1, new TimeSpan(1, 02, 852), 44.275m);
        private Race _invalidLapNumber = new Race(DateTime.Now, 038, "F.MASSA", 0, new TimeSpan(1, 02, 852), 44.275m);

        [TestMethod]
        [TestCategory("Race - Create")]
        public void Should_Return_True_When_Create_Race()
        {
            Assert.AreEqual(true, RaceScopes.CreateRaceScopeIsValid(_validRace));
        }

        [TestMethod]
        [TestCategory("Race - Create")]
        public void Should_Return_False_When_Create_Race_With_Invalid_Pilot_Code()
        {
            Assert.AreEqual(false, RaceScopes.CreateRaceScopeIsValid(_invalidPilotCode));
        }
        [TestMethod]
        [TestCategory("Race - Create")]
        public void Should_Return_False_When_Create_Race_With_Invalid_Pilot_Name()
        {
            Assert.AreEqual(false, RaceScopes.CreateRaceScopeIsValid(_invalidPilotName));
        }
        [TestMethod]
        [TestCategory("Race - Create")]
        public void Should_Return_False_When_Create_Race_With_Invalid_Lap_Number()
        {
            Assert.AreEqual(false, RaceScopes.CreateRaceScopeIsValid(_invalidLapNumber));
        }
    }
}
