using IndianStatesCensusAnalyserProblem;
using IndianStatesCensusAnalyserProblem.POCO;
using static IndianStatesCensusAnalyserProblem.CensusAnalyser;

namespace TestIndianStatesCensusAnalyser
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusfilePath = @"E:\IndianStatesCensusAnalyserProblem248\IndianStatesCensusAnalyserProblem248\IndianStatesCensusAnalyserProblem\CSVFiles\IndianStateCensusData.csv";
        static string wrongIndianStateCensusfilePath = @"E:\IndianStatesCensusAnalyserProblem248\IndianStatesCensusAnalyserProblem248\IndianStatesCensusAnalyserProblem\CSVFiles\IndianCensusData.csv";
        
        IndianStatesCensusAnalyserProblem.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStatesCensusAnalyserProblem.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// TC1.1- Given indian census data file when readed should return census data count
        /// </summary>

        [Test]
        public void GivenIndianCensusDataFileWhenReadedShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusfilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Console.WriteLine("Total state census => {0}", totalRecord.Count);
        }

        /// <summary>
        /// TC1.2- Given state census csv file if incorrect returns a custom exception
        /// </summary>
        [Test]
        public void GivenWrongStateCensusCsvFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
    }
}