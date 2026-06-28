# 🔍 LCS — Longest Common Subsequence

Solução em **C# (.NET)** para o problema da Subsequência Comum Mais Longa (LCS), combinando **Programação Dinâmica** para calcular o comprimento máximo e **Backtracking** para recuperar todas as subsequências ótimas possíveis.

---

## 👥 Autores

| Nome                                | Membro |
| ----------------------------------- | ------ |
| Gabriel Henrique Machado Magri      | 1      |
| Caio Martins Bicalho da Costa       | 2      |
| Gabriel Amorim Gonçalves Silva      | 3      |
| Geovanna do Nascimento Miranda      | 4      |
| João Gabriel Soares da Silva Franco | 5      |
| Luiz Henrique Oliveira Coelho       | 6      |

---

## 📋 Descrição

O programa recebe de **1 a 10 cenários** de entrada. Em cada cenário, o usuário fornece duas sequências de caracteres minúsculos (máximo 80 cada). O sistema retorna, em **ordem lexicográfica**, todas as LCS distintas entre os dois textos.

### Fluxo de execução

```
Main()
 ├── RecebeDados()       → lê e valida as sequências de entrada
 └── MatrizParaLCS()     → constrói a matriz de PD
      └── FazerBacktracking() → recupera todas as LCS distintas
```

---

## ⚙️ Como executar

**Pré-requisito:** .NET 6 ou superior instalado.

```bash
# Clonar o repositório
git clone <url-do-repositorio>
cd <pasta-do-projeto>

# Compilar e executar
dotnet run
```

---

## 📥 Formato de entrada

```
Digite a quantidade de cenários de 1 a 10: 1

Digite a sequência 1 da Helena: abcbdab
Digite a sequência 1 do Marcos: bdcaba
```

> Entradas com mais de 80 caracteres são automaticamente truncadas. Letras maiúsculas são convertidas para minúsculas.

## 📤 Formato de saída

Todas as LCS de comprimento máximo, sem repetições, em ordem lexicográfica — uma por linha, separadas por linha em branco.

```
bcab

bcba

bdab
```

---

## 🧠 Fundamentos Técnicos

### 1. Programação Dinâmica

O método `MatrizParaLCS()` constrói uma matriz `LCS[M+1, N+1]`, onde `M` e `N` são os comprimentos das duas sequências. A linha 0 e a coluna 0 são mantidas como zero (caso base: comparação com sequência vazia).

**Regra de preenchimento:**

```csharp
if (textoHelena[i-1] == textoMarcos[j-1])
    LCS[i, j] = LCS[i-1, j-1] + 1;          // caracteres iguais → diagonal + 1
else
    LCS[i, j] = Math.Max(LCS[i-1, j], LCS[i, j-1]);  // diferentes → maior vizinho
```

Isso garante complexidade **O(M × N)** em tempo e espaço, contra uma abordagem recursiva ingênua que seria exponencial.

---

### 2. Backtracking

A Programação Dinâmica revela o _comprimento_ da LCS; o `FazerBacktracking()` percorre a matriz de `LCS[M, N]` até a borda de zeros para recuperar as _sequências_ em si.

**Três casos na recursão:**

| Situação                               | Ação                                                                                                                        |
| -------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| `i == 0` ou `j == 0`                   | Caso base — sequência encontrada, adiciona ao `HashSet`                                                                     |
| `textoHelena[i-1] == textoMarcos[j-1]` | Caractere faz parte da LCS → insere no início e vai para `(i-1, j-1)`                                                       |
| Caracteres diferentes                  | Segue o caminho de maior valor entre `LCS[i-1, j]` e `LCS[i, j-1]`; em caso de **empate, ambos os caminhos são explorados** |

O empate é o ponto onde surgem múltiplas LCS distintas. O `HashSet<string>` garante que sequências encontradas por caminhos diferentes não sejam duplicadas na saída.

---

### 3. Desafios e Soluções

**Reconstrução na ordem correta**
O backtracking percorre as sequências de trás para frente. Para evitar strings invertidas, cada caractere encontrado é inserido no _início_ da string acumulada: `textoHelena[i-1] + palavraAtual`.

**Duplicatas no resultado**
Caminhos diferentes na matriz podem levar à mesma subsequência. Resolvido com `HashSet<string>`, que descarta duplicatas automaticamente.

**Ordenação lexicográfica**
Após o backtracking, os resultados são transferidos para uma `List<string>` e ordenados com `.Sort()`.

**Limites de entrada**
Cada sequência é normalizada com `.ToLower()` e truncada com `.Substring(0, 80)` se ultrapassar o limite permitido.

---

### 4. Complexidade

Analisaremos a complexidade de Tempo dos algoritmos, não fazendo análise de complexidade de Memória.
O arquivo de referência para toda a análise é o **LcsAlgorithm.cs.**
**a- Versão utilizando apenas Programação Dinâmica (PD)**
**Onde verificar no código:** No arquivo LcsAlgorithm.cs, dentro do método MatrizParaLCS. A lógica está no trecho desde as linhas int M = textoHelena.Length; e int N = textoMarcos.Length;, a criação da matriz int[,] LCS, até o final dos dois laços de repetição for aninhados. Entre as linhas 8 e 29 do arquivo.
**Cálculo da complexidade de Tempo:**
**1- Atribuições iniciais:** Medir o tamanho das strings e instanciar variáveis leva tempo constante, ou seja, O(1).
**2- Estrutura de Repetição:** O algoritmo utiliza dois laços for. O laço mais externo percorre a string textoHelena, executando M vezes. O laço mais interno percorre a string textoMarcos, executando N vezes para cada iteração do laço externo. Multiplicando as execuções, temos um total de M x N iterações.
**3- Operações internas do laço:** Dentro do laço mais interno, o código realiza apenas avaliações de condições lógicas (if/else), acesso direto a posições de vetor e matriz, somas simples e a função Math.Max(). Todas essas operações levam tempo constante O(1).
**4- Equação final de Tempo:** O tempo total é ditado pelos laços de repetição: O(1) x (M x N) = O(M x N).
**Resumo da Complexidade - Apenas Programação Dinâmica:**
O(M x N)

**b- Versão que combina Programação Dinâmica com Backtracking**
**Onde verificar no código:** No arquivo LcsAlgorithm.cs, abrangendo a lógica das linhas 8 a 65. O código inicia com a construção da matriz pela Programação Dinâmica (linhas 8 a 29) e, em seguida, aplica a técnica de Backtracking e ordenação a partir da linha 31. Isso envolve a chamada do método recursivo FazerBacktracking(...) e toda a lógica de extração das strings contida nele, finalizando com o processo de conversão e ordenação: listaOrdenada.Sort().
**Cálculo passo a passo (Tempo):**
**1- Fase 1 (PD):** A construção da matriz inicial é obrigatória e, conforme calculado anteriormente, consome O(M x N).
**2- Fase 2 (Backtracking):** O método FazerBacktracking percorre a matriz recursivamente começando da posição [M, N] até [0, 0]. No pior caso, se a matriz tiver muitos caminhos válidos sobrepostos, a árvore de recursão se divide. Vamos chamar de K o número total de subsequências geradas e de L o tamanho máximo dessas subsequências (onde L <= min(M, N)). O custo para explorar a árvore e concatenar as strings válidas nos base cases é proporcional a O(K x L).
**3- Fase 3 (Ordenação):** As palavras são enviadas para uma List e o código chama .Sort(). Ordenar K palavras de tamanho L custa O(K log K x L).
**4- Equação final de Tempo:** Somando as fases, temos O(M x N) (referente à matriz) + O(K x L) (referente à recursão) + O(K log K x L) (referente à ordenação). O termo dominante após a matriz é a ordenação.
**Resumo da Complexidade - PD + Backtracking:**
O(M x N + K x L x log K)

---

### 5. Lições Aprendidas

O desenvolvimento deste trabalho proporcionou aprendizados valiosos tanto na teoria de algoritmos quanto na engenharia de software, divididos em três pontos principais: O custo-benefício entre desempenho e utilidade; Divisão de tarefas e integração; Abstração da complexidade para o usuário.
Primeiramente, compreendemos na prática o conceito de trade-off (custo-benefício) na escolha de algoritmos. Observamos que a Programação Dinâmica isolada é altamente eficiente e rápida (O(M x N)), sendo ideal para cenários onde apenas a métrica final (o tamanho da subsequência) é necessária.
A matriz da Programação Dinâmica sabe a quantidade de letras da subsequência comum. Mas ela não sabe responder diretamente quais são as letras. Ela não armazenou as strings, apenas contabilizou os "acertos" durante a leitura.
No entanto, para atender à regra de negócio de exibir os resultados exatos sem palavras repetidas e em ordem alfabética, aprendemos que é obrigatório assumir o custo computacional mais elevado do Backtracking e das funções de ordenação (O(M N + K x L x log K)).
Ao fim da Programação Dinâmica, o Backtracking passa a “voltar” na matriz, procurando exatamente em quais coordenadas as letras de Helena e Marcos combinaram. Se o caminho de volta fosse uma linha reta, seria rápido, mas quando existe empate um clone vai investigar o caminho pela esquerda, o outro clone vai investigar o caminho por cima (recursão). Se houver muitos empates, a árvore de busca se ramifica dezenas ou centenas de vezes para encontrar todas as palavras possíveis, gerando o custo de O(K x L).
Ou seja, o gasto extra de processamento se justifica pela utilidade da informação gerada.
Além disso, o projeto evidenciou a importância da organização no fluxo de trabalho da equipe. Como a lógica foi construída em camadas (Matriz -> Extração Recursiva -> Interface Gráfica), aprendemos a importância de definir contratos claros de código e gerenciar o fluxo de entregas para que os membros não ficassem ociosos. Por fim, a criação da interface gráfica nos ensinou o valor de abstrair algoritmos complexos, aplicando conceitos de usabilidade para transformar linhas de código matematicamente densas em um produto acessível e intuitivo para o usuário final.

---

## 📁 Estrutura do Projeto

```
/
├── Program.cs            # Código-fonte principal
├── LcsAlgorithm.cs       # Algoritmos
├── CreditsForm.cs
├── MainForm.cs
├── MainForm.Designer.cs
└── README.md             # Este arquivo
```

---

_Versão 1.0 — Junho de 2026_
