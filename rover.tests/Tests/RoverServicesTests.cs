using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rover.spa.Services;
using rover.spa.Models;
using Xunit;
using System.Text.Json;

namespace rover.tests.Tests
{

    public class RoverServicesTests
    {

        private string firstRoverData = "1 2 N | LMLMLMLMM";
        private string secondRoverData = "3 3 E|MMRMMRMRRM";
        

        [Theory]
        [InlineData(new object[] { "0 0 N |" })]
        public void RoverServices_ReturnRoverOriginPosition(string input)
        {
            //we start with 
            List<string> csvData = new List<string>();
            csvData.Add(input);

            List<List<DirectionalPoint>> result = RoverServices.ProcessMovementsDataToLocationsData(csvData);   

            Assert.NotNull(result);

            Assert.IsType<List<List<DirectionalPoint>>>(result);

            Assert.IsType<List<DirectionalPoint>>(result[0]);

            List<DirectionalPoint> directionsList = result[0];
            var obj1 = JsonSerializer.Serialize(directionsList[0]);
            var obj2 = JsonSerializer.Serialize(new DirectionalPoint(0, 0, "N"));
            Assert.Equal(obj1, obj2);
        }

        [Theory]
        [InlineData(new object[] { "2 4 N |" })]
        public void RoverServices_ReturnRoverPositions(string input)
        {
            //we start with 
            List<string> csvData = new List<string>();
            csvData.Add(input);

            List<List<DirectionalPoint>> result = RoverServices.ProcessMovementsDataToLocationsData(csvData);

            Assert.NotNull(result);

            Assert.IsType<List<List<DirectionalPoint>>>(result);

            Assert.IsType<List<DirectionalPoint>>(result[0]);

            List<DirectionalPoint> directionsList = result[0];
            var obj1 = JsonSerializer.Serialize(directionsList[0]);
            var obj2 = JsonSerializer.Serialize(new DirectionalPoint(2, 4, "N"));
            Assert.Equal(obj1, obj2);
        }



    }
}
