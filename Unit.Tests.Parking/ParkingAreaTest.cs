using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Unit.Tests.Parking
{
    public class ParkingAreaTest
    {
        [Fact(DisplayName = "Parking Fee single vehicle")]
        [Trait("Category", "Fee")]
        public void TestParkingFee()
        { 
            // Arrange.
            var parkingArea = new ParkingArea();
            var vehicle = new Vehicle();
            vehicle.Proprietario = "Cristian Weissmantel";
            vehicle.Tipo = EnumVehicleType.Car;
            vehicle.Cor = "Black";
            vehicle.Modelo = "Palio";
            vehicle.Placa = "asd-9999";

            parkingArea.RegistrarEntradaVeiculo(vehicle);
            parkingArea.RegistrarSaidaVeiculo(vehicle.Placa);

            // Act.
            double parkingFee = parkingArea.TotalFaturado();

            // Assert.
            Assert.Equal(2, parkingFee);
        }

        [Theory(DisplayName = "Parking Fee multiples vehicles")]
        [Trait("Category", "Fee")]
        [InlineData("John Doe", "ASD-1498", "Black", "Gol")]
        [InlineData("Jane Smith", "POL-9242", "Gray", "Beetle")]
        [InlineData("Alice Johnson", "GDR-6524", "Blue", "Opala")]
        [InlineData("Bob Thompson", "OKU-1498", "Yellow", "HB20")]
        [InlineData("Emily Davis", "QWZ-5154", "Green", "Santana")]
        [InlineData("Chris Wilson", "PLU-8472", "White", "Logan")]
        public void ValidateVehiclesFee(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange.
            var parkingArea = new ParkingArea();
            var vehicle = new Vehicle();
            vehicle.Proprietario = proprietario;
            vehicle.Tipo = EnumVehicleType.Car;
            vehicle.Cor = cor;
            vehicle.Modelo = modelo;
            vehicle.Placa = placa;
            
            vehicle.Acelerar(10);
            vehicle.Frear(5);

            parkingArea.RegistrarEntradaVeiculo(vehicle);
            parkingArea.RegistrarSaidaVeiculo(vehicle.Placa);

            // Act.
            double parkingFee = parkingArea.TotalFaturado();

            // Assert.
            Assert.Equal(2, parkingFee);
        }
    }
}
