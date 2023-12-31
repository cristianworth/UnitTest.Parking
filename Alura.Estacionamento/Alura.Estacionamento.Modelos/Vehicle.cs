﻿using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace Alura.Estacionamento.Modelos
{
    public class Vehicle
    {
        //Campos    
        private string _placa;
        private string _proprietario;
        private EnumVehicleType _tipo;
        private string _ticket;

        //Propriedades   

        public string Placa
        {
            get
            {
                return _placa;
            }
            set
            {
                // Checa se o valor possui pelo menos 8 caracteres
                if (value.Length != 8)
                {
                    throw new FormatException("A placa deve possuir 8 caracteres");
                }
                for (int i = 0; i < 3; i++)
                {
                    //checa se os 3 primeiros caracteres são numeros
                    if (char.IsDigit(value[i]))
                    {
                        throw new FormatException("Os 3 primeiros caracteres devem ser letras!");
                    }
                }
                //checa o Hifem
                if (value[3] != '-')
                {
                    throw new FormatException("O 4° caractere deve ser um hífen");
                }
                //checa se os 3 primeiros caracteres são numeros
                for (int i = 4; i < 8; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new FormatException("Do 5º ao 8º caractere deve-se ter um número!");
                    }
                }
                _placa = value;

            }
        }
        /// <summary>
        /// { get; set; } cria uma propriedade automática, ou seja,
        /// durante a compilação, é gerado um atributo para armazenar
        /// o valor da propriedade e os metodos get e set, respectivamente,
        /// lêem e escrevem diretamente no atributo gerado, sem
        /// qualquer validação. É um recurso útil, pois as propriedades
        /// permitem fazer melhor uso do recurso de Reflection do .Net
        /// Framework, entre outros benefícios.
        /// </summary>
        public string Cor { get; set; }
        public double Largura { get; set; }
        public double VelocidadeAtual { get; set; }
        public string Modelo { get; set; }
        public string Proprietario
        {
            get
            {
                return _proprietario;
            }
            set
            {
                if (value.Length < 4)
                {
                    throw new FormatException("Name minimum length is 4.");
                }
                _proprietario = value;
            }
        }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public EnumVehicleType Tipo { get => _tipo; set => _tipo = value; }

        public string IdTicket { get; set; }

        public string TicketText { get { return _ticket; } set { _ticket = value; } }

        //Métodos
        public void Acelerar(int tempoSeg)
        {
            this.VelocidadeAtual += (tempoSeg * 10);
        }

        public void Frear(int tempoSeg)
        {
            this.VelocidadeAtual -= (tempoSeg * 15);
        }

        //Construtor
        public Vehicle()
        {

        }

        public Vehicle(string proprietario, string placa, string cor, string modelo, EnumVehicleType vehicleType = EnumVehicleType.Car)
        {
            Proprietario = proprietario;
            Tipo = vehicleType;
            Cor = cor;
            Modelo = modelo;
            Placa = placa;
        }

        public Vehicle(string proprietario)
        {
            Proprietario = proprietario;
        }

        public void UpdateData(Vehicle changedVehicle)
        {
            this.Proprietario = changedVehicle.Proprietario;
            this.Placa = changedVehicle.Placa;
            this.Cor = changedVehicle.Cor;
            this.Modelo = changedVehicle.Modelo;
        }

        public override string ToString()
        {
            return $"Owner: {this.Proprietario}; " +
                    $"Vehicle type: {this.Tipo.ToString()}; " +
                    $"Plate: {this.Placa}; " +
                    $"Color: {this.Cor}; " +
                    $"Model: {this.Modelo}";
        }

    }
}
