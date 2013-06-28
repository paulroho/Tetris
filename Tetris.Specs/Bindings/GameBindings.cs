using TechTalk.SpecFlow;
using Tetris.Model;
using Tetris.Specs.ShouldExtensions;

namespace Tetris.Specs.Bindings
{
    [Binding]
    public class GameBindings
    {
        [Given(@"I have a game")]
        public void GivenIHaveAGame()
        {
            CurrentGame = GetNewGame();
        }

        [Given(@"the game is blank")]
        public void GivenTheGameIsBlank()
        {
            // Nothing to do, just ensure the assertion
            CurrentGame.ShouldBe().Blank();
        }

        [Given(@"the game is running")]
        public void GivenTheGameIsRunning()
        {
            CurrentGame = GetRunningGame();
        }

        [Given(@"the game is pausing")]
        public void GivenTheGameIsPausing()
        {
            CurrentGame = GetPausingGame();
        }

        [When(@"I do nothing")]
        public void WhenIDoNothing()
        {
            // To nothing
        }

        [When(@"I start the game")]
        public void WhenIStartTheGame()
        {
            CurrentGame.Start();
        }

        [When(@"I pause the game")]
        public void WhenIPauseTheGame()
        {
            CurrentGame.Pause();
        }

        [When(@"I resume the game")]
        public void WhenIResumeTheGame()
        {
            CurrentGame.Resume();
        }

        [Then(@"the game should be blank")]
        public void ThenTheGameShouldBeBlank()
        {
            CurrentGame.ShouldBe().Blank();
        }

        [Then(@"the game should be running")]
        public void ThenTheGameShouldBeRunning()
        {
            CurrentGame.ShouldBe().Running();
        }

        [Then(@"the game should be pausing")]
        public void ThenTheGameShouldBePausing()
        {
            CurrentGame.ShouldBe().Pausing();
        }

        private Game CurrentGame
        {
            get { return ScenarioContext.Current.Get<Game>(); }
            set { ScenarioContext.Current.Set(value); }
        }

        private static Game GetNewGame()
        {
            return new Game();
        }

        private Game GetRunningGame()
        {
            var game = new Game();
            game.Start();
            return game;
        }

        private Game GetPausingGame()
        {
            var game = new Game();
            game.Pause();
            return game;
        }
    }
}