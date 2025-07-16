using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_CRUD.Interfaces
{
    public interface IDAOpet<T>
    {
        void Cadastrar(T t);
        List<T> Buscar();
        void Atualizar(T t);
        void Excluir(int id);
    }
}
