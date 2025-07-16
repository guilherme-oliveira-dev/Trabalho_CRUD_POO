using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_CRUD.Mapeamento;

namespace Trabalho_CRUD.Mapeamento
{
    public class Pet
    {
        private int _id;
        private string _nome;
        private string _especie;
        private string _raca;
        private DateTime _dataNascimento;
        private string _tipo;
        private string _nomeDono;
        private string _telefoneDono;


      
        public int GetId()
        {
            return _id;
        }
        public void SetId(int id)
        {
            _id = id;

        }

        public string GetNome()
        {
            return _nome;
        }
        public void SetNome(string nome)
        {
            _nome = nome;
        }

        public string GetEspecie()
        {
            return _especie;
        }
        public void SetEspecie(string especie)
        {
            _especie = especie;
        }

        public string GetRaca()
        {
            return _raca;
        }
        public void SetRaca(string raca)
        {
            _raca = raca;
        }

        public string GetNomeDono()
        {
            return _nomeDono;
        }
        public void SetNomeDono(string nomeDono)
        {
            _nomeDono = nomeDono;
        }

        public string GetTelefoneDono()
        {
            return _telefoneDono;
        }
        public void SetTelefoneDono(string telefoneDono)
        {
            _telefoneDono = telefoneDono;
        }

        public DateTime GetDataNascimento()
        {
            return _dataNascimento;
        }
        public void SetDataNascimento(DateTime dataNascimento)
        {
            _dataNascimento = dataNascimento;
        }
        public void SetTipo(string tipo)
        {
            _tipo = tipo;
        }
        public string GetTipo()
        {
            return _tipo;
        }


        public (int anos, int meses) CalcularIdade()
        {
            DateTime hoje = DateTime.Today;
            int anos = hoje.Year - _dataNascimento.Year;
            int meses = hoje.Month - _dataNascimento.Month;

            if (hoje.Day < _dataNascimento.Day)
            {
                meses--;
            }
            if (meses < 0)
            {
                anos--;
                meses += 12;
            }

            return (anos, meses);
        }
    }
}
