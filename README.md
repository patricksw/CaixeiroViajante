# CaixeiroViajante
Inteligência Artificial - Algoritmo Genético Caixeiro Viajante (ASP.NET C#)

Para o algoritmo, solução do caixeiro viajante, foi implementado 4 classes:

- Capital. 
    Esta classe contém uma tabela de distância de cada capital para as demais.
    Um método que resolve a distância, este método exige dois parâmetros (origem e destino), retorna a distância entre as capitais informadas nos parâmetros. 
    Um método que exibe todas as capitais para a lista no formulário do software.
- Rota. 
    Esta classe possui um método para criar uma rota, este método exige três parâmetros (index de origem, numero máximo de capitais para gerar as rotas, numero randômico para gerar as rotas aleatórias).
    Este método gera uma rota aleatórioa de acordo com os parãmetros informados, esta rota é um array de inteiros onde cada ineiro é um index que representa uma capital. 
    Um método fitness, este método percorre a rota aletória criada, acumulando o valor de cada distância entre as capitais, para calcular a distância entre as capitais, para isso o algoritmo usa o método distância da classe capital. 
- Populacao.
    Esta classe possui em seu constutor parâmetros que serão usados para gerar uma população aleatória de rotas, os parâmetros são: Origem um index que representa uma capital de origem; um número total de população, numero máximo que compõe a população; Fator cruzamento, este parâmetro representa um um numero que indica onde cada cromossomo deve ser dividido, ex: cromossomo com 26 possições, indicando o fator de cruzamento 12, quer dizer que o cromossomo será divido em dois para gerar os filhos, um deles terar 12 posições e o outro 14; Porcentagem de mutação, este parâmetro permite aplicar uma porcentagem de mutação nos cromossomos, ex: mutação = 30%, quer dizer que em cada e ERA 30% dos cromossomos serão mutados. 
    Um método Crossover que consiste em cruzar os cromossos, este método separa 2 cromossomos de cada vez, divide o cromossomo em 2 partes (respeitando o fator de cruzamento), e mesclar eles, ou seja, o cromosomo pai_1(array de 26) como o cromossomo pai_2(array de 26) vai gerar 2 filhos: cromossomo filho_1(array de 26, com primeiras partes dos cromossos pai), cromossomo filho_2(array de 26, com segundas partes dos cromossos pai). 
    Um método ResolveRepetidos, este método garante que ao realizar cruzar 2 cromossomos os filhos não fiquem com genes repetidos. 
    Método mutação, este método escolhe alguns genes do cromossomo para modificar, é feito um sorteio e alterado alteatoriamente um gene do cromossomo, aplicando o principio de mutação. 
    O método TabelaSort, consiste em ordenar a população pelo resultado da menor distância entre capitais.
- TabelaResultado. 
    Esta classe é apenas para manter as rotas e o resultado total das distâncias entre capitais. Em seu constutor, ela sugere como parâmetro: total de distancia entre as capitais da rota e a rota.

Funcionamento do Programa:
 - Para que o programa funcione adequadamente, foi escrito uma classe "Caixeiro". Esta classe exige como parâmetro em seu construtor: origem, index de capital de origem; populacao, numero de populacao que deve ser gerada; Fator de Cruzamento, indica onde o cromossomo deve ser dividido; NumeroEra, indica o numero de vezes que o algorirmo vai aplicar o método crossover na população; CoefMutacao, porcentagem de mutação que será aplicado em cada crossover (era).
