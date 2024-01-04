using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.ComponentModel;
using Xunit;
using Xunit.Abstractions;

namespace Unit.Tests.Parking
{
    public class VehicleTest : IDisposable
    {
        private Vehicle vehicle;
        public ITestOutputHelper ConsoleOutput;

        public VehicleTest(ITestOutputHelper _consoleOutput)
        {
            // This is where I Setup the vehicle that will be used for the tests.
            ConsoleOutput = _consoleOutput;
            ConsoleOutput.WriteLine("Teste Started.");
            vehicle = new Vehicle("Emily Davis", "QWZ-5154", "Green", "Santana", EnumVehicleType.Car);
        }

        [Fact(DisplayName = "Vehicle Accelerate")]
        [Trait("Category", "Speed")]
        public void TestVehicleAccelerate()
        {
            // AAA pattern = Arange, Act, Assert

            // Arange = set up the variables and values of the tests.

            // Act = Execute the method that should be tested.
            vehicle.Acelerar(10);

            // Assert = validate if the return of the method it's the expected one.
            Assert.Equal(100, vehicle.VelocidadeAtual);
        }

        [Fact(DisplayName = "Vehicle Break")]
        [Trait("Category", "Speed")]
        public void TestVehicleBreak()
        {
            // AAA pattern = Arange, Act, Assert
            // Arange = set up the variables and values of the tests.

            // Act = Execute the method that should be tested.
            vehicle.Frear(10);

            // Assert = validate if the return of the method it's the expected one.
            Assert.Equal(-150, vehicle.VelocidadeAtual);
        }

        [Fact(DisplayName = "Vehicle is a Car")]
        [Trait("Category", "Vehicle Type")]
        public void TestVehicleIsCar()
        {
            // AAA pattern = Arange, Act, Assert

            // Arange = set up the variables and values of the tests.

            // Act = Execute the method that should be tested.

            // Assert = validate if the return of the method it's the expected one.
            Assert.Equal(EnumVehicleType.Car, vehicle.Tipo);
        }

        [Fact(DisplayName = "Vehicle is a Motorcycle", Skip = "Not implemented yet.")]
        [Trait("Category", "Vehicle Type")]
        public void TestVehicleIsMotorcycle()
        {

        }

        [Fact]
        public void TestGetFormattedVehicleData()
        {
            // Arrange.

            // Act.
            var formattedVehicleData = vehicle.ToString();

            // Assert.
            Assert.Contains("Owner: Emily Davis", formattedVehicleData);
            Assert.Contains("Vehicle type: Car", formattedVehicleData);
            Assert.Contains("Plate: QWZ-5154", formattedVehicleData);
            Assert.Contains("Color: Green", formattedVehicleData);
            Assert.Contains("Model: Santana", formattedVehicleData);
        }

        [Fact]
        public void TestOwnerNameLength()
        {
            var ownerName = "Le";

            // Throws<ExceptionExpected>(functionToBeExecuted);
            Assert.Throws<FormatException>(() => new Vehicle(ownerName));
        }

        [Fact]
        public void TestLicensePlateLength()
        {
            var licensePlate = "LSN4I49";

            var exception = Assert.Throws<FormatException>(() => new Vehicle().Placa = licensePlate);

            Assert.Equal("A placa deve possuir 8 caracteres", exception.Message);
        }

        public void Dispose()
        {
            // This is the Clean up, that can be used to close sessions because it's the last thing to be executed after each method.
            ConsoleOutput.WriteLine("Dispose called.");
        }
    }
}
