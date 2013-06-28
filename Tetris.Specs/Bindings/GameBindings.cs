using FluentAssertions;
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

        [Given(@"there is no current piece")]
        public void GivenThereIsNoCurrentPiece()
        {
            CurrentGame.ShouldHave().NoCurrentPiece();
        }

        [Given(@"there is a current piece")]
        public void GivenThereIsACurrentPiece()
        {
            CurrentGame.Tick();
            CurrentGame.ShouldHave().ACurrentPiece();
        }

        [Given(@"there is no obstacle under the piece")]
        public void GivenThereIsNoObstacleUnderThePiece()
        {
            CurrentGame.ShouldHave().NoObstacleUnderThePiece();
        }

        [When(@"I do nothing")]
        [When(@"I do not tick")]
        public void WhenIDoNothing()
        {
            // Do nothing
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

        [When(@"I tick")]
        public void WhenITick()
        {
            if (CurrentGame.CurrentPiece != null)
            {
                PositionBeforeTick = CurrentGame.CurrentPiece.Position;
            }
            CurrentGame.Tick();
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

        [Then(@"a new piece is put into the game")]
        public void ThenANewPieceIsPutIntoTheGame()
        {
            CurrentGame.ShouldHave().ACurrentPiece();
        }

        [Then(@"the game has no current piece")]
        public void ThenTheGameHasNoCurrentPiece()
        {
            CurrentGame.ShouldHave().NoCurrentPiece();
        }

        [Then(@"the piece is on the top row")]
        public void ThenThePieceIsOnTheTopRow()
        {
            var topRow = CurrentGame.RowCount;
            CurrentGame.ShouldHave().CurrentPieceAtRow(topRow);
        }

        [Then(@"the piece drops by one row")]
        public void ThenThePieceDropsByOneRow()
        {
            CurrentGame.CurrentPiece.Position.Row.Should().Be(PositionBeforeTick.Row - 1);
        }

        #region Infrastructure

        private Game CurrentGame
        {
            get { return ScenarioContext.Current.Get<Game>(); }
            set { ScenarioContext.Current.Set(value); }
        }

        private Position PositionBeforeTick
        {
            get { return ScenarioContext.Current.Get<Position>("beforeTick"); }
            set { ScenarioContext.Current.Set(value, "beforeTick"); }
        }

        private static Game GetNewGame()
        {
            return new Game(new PieceGenerator());
        }

        private Game GetRunningGame()
        {
            var game = GetNewGame();
            game.Start();
            return game;
        }

        private Game GetPausingGame()
        {
            var game = GetNewGame();
            game.Pause();
            return game;
        }

        #endregion
    }
}