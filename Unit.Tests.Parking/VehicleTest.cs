using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.ComponentModel;
using Xunit;

namespace Unit.Tests.Parking
{
    public class VehicleTest
    {
        [Fact(DisplayName = "Vehicle Accelerate")]
        [Trait("Category", "Speed")]
        public void TestVehicleAccelerate()
        {
            // AAA pattern = Arange, Act, Assert
            // Arange = set up the variables and values of the tests.
            var vehicle = new Vehicle();
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
            var vehicle = new Vehicle();
            // Act = Execute the method that should be tested.
            vehicle.Frear(10);
            // Assert = validate if the return of the method it's the expected one.
            Assert.Equal(-150, vehicle.VelocidadeAtual);
        }

        [Fact(DisplayName = "Vehicle is Car")]
        [Trait("Category", "Vehicle Type")]
        public void TestVehicleIsCar()
        {
            // AAA pattern = Arange, Act, Assert
            // Arange = set up the variables and values of the tests.
            var vehicle = new Vehicle();
            // Act = Execute the method that should be tested.
            // Assert = validate if the return of the method it's the expected one.
            Assert.Equal(EnumVehicleType.Car, vehicle.Tipo);
        }

        [Fact(DisplayName = "Vehicle is Motorcycle", Skip = "Not implemented yet.")]
        [Trait("Category", "Vehicle Type")]
        public void TestVehicleIsMotorcycle() 
        { 
            
        }
    }
}
