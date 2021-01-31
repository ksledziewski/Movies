using Movies.Logic;
using Movies.Test.Adapters;
using NUnit.Framework;

namespace Movies.Test
{
    /// <summary>
    /// Tests for movie rating
    /// </summary>
    public class MovieRatingTest
    {
        private MovieLogic _movieLogic;
        
        /// <summary>
        /// Setup method
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // NOTE: DI framework should be used here
            _movieLogic = new MovieLogic(new MovieRepositoryAdapter(), new MovieExternalServiceAdapter());
        }

        /// <summary>
        /// Test rating too low
        /// </summary>
        [Test]
        public void RateMovieCheckScoreTooLow()
        {
            var result = _movieLogic.RateMovie("Test", -1);
            Assert.AreEqual(false, result.IsValid);
        }
        
        /// <summary>
        /// Test rating to high
        /// </summary>
        [Test]
        public void RateMovieCheckScoreTooHigh()
        {
            var result = _movieLogic.RateMovie("Test", 11);
            Assert.AreEqual(false, result.IsValid);
        }
        
        /// <summary>
        /// Test proper rating
        /// </summary>
        [Test]
        public void RateMovieCheckProperRating()
        {
            var result = _movieLogic.RateMovie("Test", 5);
            Assert.AreEqual(true, result.IsValid);
        }
        
        /// <summary>
        /// Test for non existing title
        /// </summary>
        [Test]
        public void RateMovieCheckNonExistingTitle()
        {
            var result = _movieLogic.RateMovie("Test111", 5);
            Assert.AreEqual(false, result.IsValid);
        }
    }
}