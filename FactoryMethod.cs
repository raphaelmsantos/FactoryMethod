/*
Aluno: Raphael Morais dos Santos
Email: raphael1710@gmail.com

Utilizei nesse exemplo o padrão Factory Method.

Imaginei que a transportadora pode ter 3 tipos de veículos: Moto, Carro e Caminhão.
Os três podem realizar entrega, porém cada tipo tem a sua capacidade máxima
Para isso criei o VeiculoFactory, onde eu informo qual o peso da encomenda e ele retorna o tipo de veículo adequado para fazer a entrega.

 */

/// <summary>
/// Interface de veículo
/// </summary>
public interface IVeiculo
{
    public void RealizarEntrega(Encomenda encomenda);
}

/// <summary>
/// Carro
/// </summary>
public class Carro : IVeiculo
{
    public int Id { get; set; }
    public string Placa { get; set; }

    public void RealizarEntrega()
    {
        throw NotImplementedException();
    }
}

/// <summary>
/// Moto
/// </summary>
public class Moto : IVeiculo
{
    public int Id { get; set; }
    public string Placa { get; set; }
    public void RealizarEntrega()
    {
        throw NotImplementedException();
    }
}

/// <summary>
/// Caminhão
/// </summary>
public class Caminhao : IVeiculo
{
    public int Id { get; set; }
    public string Placa { get; set; }

    public void RealizarEntrega()
    {
        throw NotImplementedException();
    }
}

/// <summary>
/// Interface da factory
/// </summary>
public abstract class IVeiculoFactory
{
    public abstract IVeiculo getVeiculoPorCapacidade(int pesoEncomenda);
}

/// <summary>
/// Classe concreta VeiculoFactory
/// Responsável por decidir qual tipo do veiculo sera entregue
/// </summary>
public class VeiculoFactory : IVeiculoFactory
{
    public override IVeiculo getVeiculoPorCapacidade(int peso)
    {
        switch (peso)
        {
            case (peso < 10):
                return new Moto();
            case (peso < 200):
                return new Carro();
            default:
                return new Caminhao();
        }
    }
}

/// <summary>
/// Encomenda
/// </summary>
public class Encomenda
{
    public int Id { get; set; }
    public List<ItemCompra> Itens { get; set; }
    public decimal Peso { get; set; }
}

/// <summary>
/// Funcionário
/// </summary>
public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

/// <summary>
/// Item
/// </summary>
public class ItemCompra
{
    public int Id { get; set; }
    public string Descricao { get; set; }
}


/// <summary>
/// Exemplo de Utilização do padrão Factory Method/// 
/// </summary>
public class ExemploUso
{
    public static void main(String[] args)
    {
        //// Defino o item da minha encomenda
        ItemCompra item = new ItemCompra();
        item.Id = 1;
        item.Descricao = "Produto 1";

        //// Defino a minha encomenda
        Encomenda encomenda = new Encomenda();
        encomenda.Id = 1;
        encomenda.Peso = 100;
        encomenda.Itens.Add(item);

        //// Crio uma instancia da minha factory
        IVeiculoFactory veiculoFactory = new VeiculoFactory();

        //// Pego um veiculo de acordo com o peso da minha encomnda
        IVeiculo veiculo = veiculoFactory.getVeiculoPorCapacidade(encomenda.Peso);

        ///realizo a entrega
        veiculo.RealizarEntrega();

    }
}
