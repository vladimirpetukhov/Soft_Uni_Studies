namespace FestivalManager.Tests
{
    using Core.Controllers;
    using Entities;
    using Entities.Instruments;
    using Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void TestController()
        {
            var set1 = new Short("set1");

            var performer = new Performer("Shushana", 25);
            var instrument = new Guitar();
            performer.AddInstrument(instrument);
            var song = new Song("name", new TimeSpan(0, 0, 25, 0));

            var stage = new Stage();
            stage.AddSet(set1);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            var controller = new SetController(stage);

            var expectedResult = "1. set1:\r\n-- Did not perform";
            Assert.AreEqual(expectedResult, controller.PerformSets());
        }

        [Test]
        public void TestWhetherTheControllerGivesCorrectOutput()
        {
            var set1 = new Short("set1");

            var performer = new Performer("Bat nasko", 30);
            var instrument = new Guitar();
            performer.AddInstrument(instrument);
            var song = new Song("name", new TimeSpan(0, 0, 10, 0));

            var stage = new Stage();
            set1.AddPerformer(performer);
            set1.AddSong(song);
            stage.AddSet(set1);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            var controller = new SetController(stage);
            var stringOutput = controller.PerformSets();

            var expectedResult = "1. set1:\r\n-- 1. name (10:00)\r\n-- Set Successful";
            Assert.AreEqual(expectedResult, stringOutput);
        }

        [Test]
        public void TestWhetherTheControllerFailsToPerform()
        {
            var set1 = new Short("set1");

            var performer = new Performer("Woah", 39);
            var instrument = new Microphone();
            performer.AddInstrument(instrument);
            var song = new Song("WoahButSong", new TimeSpan(0, 0, 5, 0));

            var stage = new Stage();
            set1.AddPerformer(performer);
            set1.AddSong(song);
            stage.AddSet(set1);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            var controller = new SetController(stage);
            controller.PerformSets();
            controller.PerformSets();
            var stringOutput = controller.PerformSets();

            var expectedResult = "1. set1:\r\n-- Did not perform";
            Assert.AreEqual(expectedResult, stringOutput);
        }
    }
}