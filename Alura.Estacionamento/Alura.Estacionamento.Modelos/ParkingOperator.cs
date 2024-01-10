using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Alura.Estacionamento.Modelos
{
    public class ParkingOperator
    {
        private string _registrationNumber;
        private string _name;

        public string RegistrationNumber { get { return _registrationNumber; } set { _registrationNumber = value; } }
        public string Name { get { return _name; } set { _name = value; } }

        public ParkingOperator(string name)
        {
            _registrationNumber = Guid.NewGuid().ToString()[..8];
            _name = name;
        }

        public override string ToString()
        {
            return $"Parking Operator: {_name}\n" +
                    $"Registration Number: {_registrationNumber}";
        }
    }
}
