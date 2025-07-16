using Exemplo_crud.Utilitarios;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_CRUD.Interfaces;
using Trabalho_CRUD.Mapeamento;

namespace Trabalho_CRUD.PetDAO
{
    public class PetDAO : IDAOpet<Pet>
    {
        public void Cadastrar(Pet pet)
        {
            try
            {
                string dataNasc = pet.GetDataNascimento().ToString("yyyy-MM-dd");
                string sql = "INSERT INTO pets (nome, especie, raca, data_nascimento, tipo, nome_dono, telefone_dono) " +
                             "VALUES (@nome, @especie, @raca, @data_nascimento, @tipo, @nome_dono, @telefone_dono)";

                var cmd = new MySqlCommand(sql, Conexao.Conectar());

                cmd.Parameters.AddWithValue("@nome", pet.GetNome());
                cmd.Parameters.AddWithValue("@especie", pet.GetEspecie());
                cmd.Parameters.AddWithValue("@raca", pet.GetRaca());
                cmd.Parameters.AddWithValue("@data_nascimento", dataNasc);
                cmd.Parameters.AddWithValue("@tipo", pet.GetTipo());
                cmd.Parameters.AddWithValue("@nome_dono", pet.GetNomeDono());
                cmd.Parameters.AddWithValue("@telefone_dono", pet.GetTelefoneDono());

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.Fecharconexao();
            }
        }

        public void Atualizar(Pet pet)
        {
            try
            {
                string dataNasc = pet.GetDataNascimento().ToString("yyyy-MM-dd");
                string sql = "UPDATE pets SET nome=@nome, especie=@especie, raca=@raca, data_nascimento=@data_nascimento, " +
                             "tipo=@tipo, nome_dono=@nome_dono, telefone_dono=@telefone_dono WHERE id=@id";

                var cmd = new MySqlCommand(sql, Conexao.Conectar());
                cmd.Parameters.AddWithValue("@id", pet.GetId());
                cmd.Parameters.AddWithValue("@nome", pet.GetNome());
                cmd.Parameters.AddWithValue("@especie", pet.GetEspecie());
                cmd.Parameters.AddWithValue("@raca", pet.GetRaca());
                cmd.Parameters.AddWithValue("@data_nascimento", dataNasc);
                cmd.Parameters.AddWithValue("@tipo", pet.GetTipo());
                cmd.Parameters.AddWithValue("@nome_dono", pet.GetNomeDono());
                cmd.Parameters.AddWithValue("@telefone_dono", pet.GetTelefoneDono());

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.Fecharconexao();
            }
        }

        public List<Pet> Buscar()
        {
            List<Pet> pets = new List<Pet>();
            try
            {
                string sql = "SELECT * FROM pets ORDER BY nome";
                var cmd = new MySqlCommand(sql, Conexao.Conectar());
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pet p = new Pet();
                        p.SetId(reader.GetInt32("id"));
                        p.SetNome(reader.GetString("nome"));
                        p.SetEspecie(reader.GetString("especie"));
                        p.SetRaca(reader.GetString("raca"));
                        p.SetDataNascimento(reader.GetDateTime("data_nascimento"));
                        p.SetTipo(reader.GetString("tipo"));
                        p.SetNomeDono(reader.GetString("nome_dono"));
                        p.SetTelefoneDono(reader.GetString("telefone_dono"));
                        pets.Add(p);
                    }
                }
                return pets;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.Fecharconexao();
            }
        }

        public void Excluir(int id)
        {
            try
            {
                string sql = "DELETE FROM pets WHERE id=@id";
                var cmd = new MySqlCommand(sql, Conexao.Conectar());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.Fecharconexao();
            }
        }
    }
}

