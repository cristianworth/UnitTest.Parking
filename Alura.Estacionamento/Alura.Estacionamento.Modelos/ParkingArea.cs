using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Modelos
{
    public class ParkingArea
    {

        public ParkingArea()
        {
            Faturado = 0;
            veiculos = new List<Vehicle>();
        }
        private List<Vehicle> veiculos;
        private double faturado;
        public double Faturado { get => faturado; set => faturado = value; }
        public List<Vehicle> Veiculos { get => veiculos; set => veiculos = value; }
        public double TotalFaturado()
        {
            return this.Faturado;
        }

        public string MostrarFaturamento()
        {
            string totalfaturado = String.Format("Total faturado até o momento :::::::::::::::::::::::::::: {0:c}", this.TotalFaturado());
            return totalfaturado;
        }

        public void RegistrarEntradaVeiculo(Vehicle veiculo)
        {
            veiculo.HoraEntrada = DateTime.Now;
            CreateTicket(veiculo);
            this.Veiculos.Add(veiculo);
        }

        public string RegistrarSaidaVeiculo(String placa)
        {
            Vehicle procurado = null;
            string informacao = string.Empty;

            foreach (Vehicle v in this.Veiculos)
            {
                if (v.Placa == placa)
                {
                    v.HoraSaida = DateTime.Now;
                    TimeSpan tempoPermanencia = v.HoraSaida - v.HoraEntrada;
                    double valorASerCobrado = 0;
                    if (v.Tipo == EnumVehicleType.Car)
                    {
                        /// o método Math.Ceiling(), aplica o conceito de teto da matemática onde o valor máximo é o inteiro imediatamente posterior a ele.
                        /// Ex.: 0,9999 ou 0,0001 teto = 1
                        /// Obs.: o conceito de chão é inverso e podemos utilizar Math.Floor();
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 2;

                    }
                    if (v.Tipo == EnumVehicleType.Motorcycle)
                    {
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 1;
                    }
                    informacao = string.Format(" Hora de entrada: {0: HH: mm: ss}\n " +
                                             "Hora de saída: {1: HH:mm:ss}\n " +
                                             "Permanência: {2: HH:mm:ss} \n " +
                                             "Valor a pagar: {3:c}", v.HoraEntrada, v.HoraSaida, new DateTime().Add(tempoPermanencia), valorASerCobrado);
                    procurado = v;
                    this.Faturado = this.Faturado + valorASerCobrado;
                    break;
                }

            }
            if (procurado != null)
            {
                this.Veiculos.Remove(procurado);
            }
            else
            {
                return "Não encontrado veículo com a placa informada.";
            }

            return informacao;
        }

        public Vehicle SearchVehicle(string idTicket)
        {
            var vehicle = from Vehicle in this.Veiculos
                          where Vehicle.IdTicket == idTicket
                          select Vehicle;

            return vehicle.SingleOrDefault();
        }

        public Vehicle UpdateVehicleData(Vehicle changedVehicle)
        {
            var existingVehicle = SearchVehicle(changedVehicle.IdTicket);
            existingVehicle.UpdateData(changedVehicle);

            return existingVehicle;
        }

        public void CreateTicket(Vehicle vehicle)
        {
                        // Guid.NewGuid().ToString().Substring(0, 5);
            var idTicket = Guid.NewGuid().ToString()[..5];
            var ticketText = "### Parking ticket ###\n" +
                                $">>> Ticket: {idTicket}\n" +
                                $">>> Date: {DateTime.Now}\n" +
                                $">>> Plate: {vehicle.Placa}\n";

            vehicle.IdTicket = idTicket;
            vehicle.TicketText = ticketText;
        }
    }
}
