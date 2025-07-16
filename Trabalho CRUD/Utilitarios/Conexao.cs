using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Exemplo_crud.Utilitarios;

internal static class Conexao
{
    static MySqlConnection conexao;

    public static MySqlConnection Conectar()
    {
        try
        {
            string strconexao = "server=localhost;uid=root;pwd=guilherme;port=3306; database=clinicavet";
            conexao = new MySqlConnection(strconexao);
            conexao.Open();
            //Console.WriteLine("Conectado!");
            return conexao;
        }
        catch (Exception ex)
        {
            throw new Exception(" Erro ao conectar com o banco de Dados" + ex.Message);

        }


    }
    //metodo que fecha a conexão 
    public static void Fecharconexao()
    {
        conexao.Close();
    }





}