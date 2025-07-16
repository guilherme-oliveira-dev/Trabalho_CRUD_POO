
using System.Globalization;
using Trabalho_CRUD.Mapeamento;
using Trabalho_CRUD.PetDAO;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MENU PRINCIPAL ===");
            Console.WriteLine("1 - Gerenciar Pets");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    MenuPet();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void MenuPet()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MENU PET ===");
            Console.WriteLine("1 - Cadastrar Pet");
            Console.WriteLine("2 - Listar Pets");
            Console.WriteLine("3 - Atualizar Pet");
            Console.WriteLine("4 - Excluir Pet");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarPet();
                    break;
                case "2":
                    ListarPets();
                    break;
                case "3":
                    AtualizarPet();
                    break;
                case "4":
                    ExcluirPet();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Console.ReadKey();
                    break;
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void CadastrarPet()
    {
        try
        {
            string nome, especie, raca, tipo, nomeDono, telefoneDono;
            DateTime dataNasc;

            while (true)
            {
                Console.Write("Nome do Pet: ");
                nome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nome)) break;
                Console.WriteLine("Nome obrigatório!");
            }
            while (true)
            {
                Console.Write("Espécie: ");
                especie = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(especie)) break;
                Console.WriteLine("Espécie obrigatória!");
            }

            while (true)
            {
                Console.Write("Raça: ");
                raca = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(raca)) break;
                Console.WriteLine("Raça obrigatória!");
            }

            while (true)
            {
                Console.Write("Data de nascimento (dd/MM/yyyy): ");
                string dataInput = Console.ReadLine();
                if (DateTime.TryParseExact(dataInput, "dd/MM/yyyy", null, DateTimeStyles.None, out dataNasc))
                    break;
                Console.WriteLine("Data inválida!");
            }

            while (true)
            {
                Console.Write("Tipo de animal (1 - Comum | 2 - Exótico): ");
                string tipoInput = Console.ReadLine();
                if (tipoInput == "1" || tipoInput == "2")
                {
                    tipo = tipoInput == "2" ? "Exótico" : "Comum";
                    break;
                }
                Console.WriteLine("Digite 1 ou 2.");
            }

            while (true)
            {
                Console.Write("Nome do Dono: ");
                nomeDono = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nomeDono)) break;
                Console.WriteLine("Nome obrigatório!");
            }

            while (true)
            {
                Console.Write("Telefone do Dono: ");
                telefoneDono = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(telefoneDono)) break;
                Console.WriteLine("Telefone obrigatório!");
            }

            Pet pet = new Pet();
            pet.SetNome(nome);
            pet.SetEspecie(especie);
            pet.SetRaca(raca);
            pet.SetDataNascimento(dataNasc);
            pet.SetTipo(tipo);
            pet.SetNomeDono(nomeDono);
            pet.SetTelefoneDono(telefoneDono);

            new PetDAO().Cadastrar(pet);
            Console.WriteLine("Pet cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }
    }

    static void ListarPets()
    {
        try
        {
            var dao = new PetDAO();
            var lista = dao.Buscar();

            if (lista == null || lista.Count == 0)
            {
                Console.WriteLine("Nenhum pet cadastrado.");
                return;
            }

            foreach (var pet in lista)
            {
                Console.WriteLine($"Pet: {pet.GetNome()} | Espécie: {pet.GetEspecie()} | Raça: {pet.GetRaca()} | Tipo: {pet.GetTipo()} | Dono: {pet.GetNomeDono()} | Telefone: {pet.GetTelefoneDono()}");
                var idade = pet.CalcularIdade();
                Console.WriteLine($"Idade: {idade.anos} anos e {idade.meses} meses");
                Console.WriteLine("--------------------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao listar pets: " + ex.Message);
        }
    }

    static void AtualizarPet()
    {
        try
        {
            var dao = new PetDAO();
            var pets = dao.Buscar();  // Retorna List<Pet>

            if (pets == null || pets.Count == 0)
            {
                Console.WriteLine("Nenhum pet cadastrado no banco.");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\n=== Lista de Pets Cadastrados ===");
            foreach (var pet in pets)
            {
                Console.WriteLine($"ID: {pet.GetId()} | Nome: {pet.GetNome()} | Dono: {pet.GetNomeDono()} | Telefone: {pet.GetTelefoneDono()}");
            }
            Console.WriteLine("----------------------------------");

            int id;
            while (true)
            {
                Console.Write("ID do Pet a atualizar: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out id))
                {
                    bool idExiste = pets.Exists(p => p.GetId() == id);
                    if (idExiste)
                        break;
                    else
                        Console.WriteLine("ID não encontrado na lista. Informe um ID válido.");
                }
                else
                {
                    Console.WriteLine("ID inválido. Digite um número válido.");
                }
            }

            string nome;
            while (true)
            {
                Console.Write("Novo nome: ");
                nome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nome)) break;
                Console.WriteLine("Nome obrigatório!");
            }

            string especie;
            while (true)
            {
                Console.Write("Nova espécie: ");
                especie = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(especie)) break;
                Console.WriteLine("Espécie obrigatória!");
            }

            string raca;
            while (true)
            {
                Console.Write("Nova raça: ");
                raca = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(raca)) break;
                Console.WriteLine("Raça obrigatória!");
            }

            DateTime dataNasc;
            while (true)
            {
                Console.Write("Data de nascimento (dd/MM/yyyy): ");
                string dataInput = Console.ReadLine();
                if (DateTime.TryParseExact(dataInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNasc))
                    break;
                Console.WriteLine("Data inválida!");
            }

            string tipo;
            while (true)
            {
                Console.Write("Novo tipo (Comum/Exótico): ");
                tipo = Console.ReadLine();
                if (tipo == "Comum" || tipo == "Exótico")
                    break;
                Console.WriteLine("Tipo inválido! Digite 'Comum' ou 'Exótico'.");
            }

            string nomeDono;
            while (true)
            {
                Console.Write("Novo nome do dono: ");
                nomeDono = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nomeDono)) break;
                Console.WriteLine("Nome do dono obrigatório!");
            }

            string telefoneDono;
            while (true)
            {
                Console.Write("Novo telefone do dono: ");
                telefoneDono = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(telefoneDono)) break;
                Console.WriteLine("Telefone do dono obrigatório!");
            }

            Pet petAtualizado = new Pet();
            petAtualizado.SetId(id);
            petAtualizado.SetNome(nome);
            petAtualizado.SetEspecie(especie);
            petAtualizado.SetRaca(raca);
            petAtualizado.SetDataNascimento(dataNasc);
            petAtualizado.SetTipo(tipo);
            petAtualizado.SetNomeDono(nomeDono);
            petAtualizado.SetTelefoneDono(telefoneDono);

            dao.Atualizar(petAtualizado);
            Console.WriteLine("Pet atualizado!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }
    }


    static void ExcluirPet()
    {
        try
        {
            // Listar pets antes de pedir o ID
            var dao = new PetDAO();
            var pets = dao.Buscar();

            if (pets == null || pets.Count == 0)
            {
                Console.WriteLine("Nenhum pet cadastrado.");
                return;
            }

            Console.WriteLine("\n=== Lista de Pets Cadastrados ===");
            foreach (var item in pets)
            {
                var pet = item;
                Console.WriteLine($"ID: {pet.GetId()} | Nome: {pet.GetNome()} | Dono: {pet.GetNomeDono()} | Telefone: {pet.GetTelefoneDono()}");
            }

            Console.WriteLine("----------------------------------");

            int id;
            while (true)
            {
                Console.Write("Digite o ID do pet a excluir: ");
                if (int.TryParse(Console.ReadLine(), out id))
                    break;
                Console.WriteLine("ID inválido. Digite um número válido.");
            }

            dao.Excluir(id);
            Console.WriteLine("Pet excluído com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao excluir pet: " + ex.Message);
        }
    }

}