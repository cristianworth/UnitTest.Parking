using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Unit.Tests.Parking
{
    public class VehicleTest
    {
        [Fact]
        public void TestVehicleAccelerate()
        {
            var vehicle = new Vehicle();
            vehicle.Acelerar(10);
            Assert.Equal(100, vehicle.VelocidadeAtual);
        }

        [Fact]
        public void TestVehicleBreak() 
        {
            var vehicle = new Vehicle();
            vehicle.Frear(10);
            Assert.Equal(-150, vehicle.VelocidadeAtual);
        }
    }
}
