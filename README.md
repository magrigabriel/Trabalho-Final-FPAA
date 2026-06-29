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
 ├── LcsProgramacaoDinamica.cs           → somente PD (tamanho da LCS)
 └── LcsProgramacaoDinamicaBacktracking.cs → PD + backtracking (todas as LCS)
```

---

## 📦 Arquivos de entrega (.zip)

Conforme o roteiro, o `.zip` deve conter **dois arquivos de solução distintos**:

| Item | Arquivo | O que faz |
| ---- | ------- | --------- |
| **1** | `LcsProgramacaoDinamica.cs` | Somente Programação Dinâmica — constrói a matriz e retorna o **tamanho** da LCS |
| **2** | `LcsProgramacaoDinamicaBacktracking.cs` | PD + Backtracking — reutiliza a matriz do Arquivo 1 e recupera **todas** as LCS |
| **3** | `README.md` | Descrição da solução e respostas às perguntas do roteiro |
| **4** | Apresentação (`.pdf` ou `.pptx`) | Slides da apresentação |

> Na interface gráfica, use os botões de rádio **"Somente PD"** ou **"PD + Backtracking"** para executar cada arquivo separadamente e demonstrar na apresentação.

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

> Entradas inválidas (vazio, mais de 80 letras ou caracteres fora de `a`-`z`) exibem mensagem de erro. Letras maiúsculas são convertidas para minúsculas.

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

O método `ConstruirMatrizLcs()` (em `LcsProgramacaoDinamica.cs`) constrói uma matriz `LCS[M+1, N+1]`, onde `M` e `N` são os comprimentos das duas sequências. A linha 0 e a coluna 0 são mantidas como zero (caso base: comparação com sequência vazia).

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

A Programação Dinâmica revela o _comprimento_ da LCS; o `FazerBacktracking()` (em `LcsProgramacaoDinamicaBacktracking.cs`) percorre a matriz de `LCS[M, N]` até a borda de zeros para recuperar as _sequências_ em si.

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
Validação centralizada em `ValidacaoEntrada.cs`: cenários de 1 a 10; sequências de 1 a 80 letras; apenas caracteres `a`-`z` (maiúsculas convertidas para minúsculas); rejeição de campos vazios e caracteres inválidos com mensagem de erro.

---

### 4. Complexidade

Analisaremos a complexidade de Tempo dos algoritmos, não fazendo análise de complexidade de Memória.

**a- Versão utilizando apenas Programação Dinâmica (PD)**

**Onde verificar no código:** Arquivo `LcsProgramacaoDinamica.cs`, método `ConstruirMatrizLcs`.
**Cálculo da complexidade de Tempo:**
**1- Atribuições iniciais:** Medir o tamanho das strings e instanciar variáveis leva tempo constante, ou seja, O(1).
**2- Estrutura de Repetição:** O algoritmo utiliza dois laços for. O laço mais externo percorre a string textoHelena, executando M vezes. O laço mais interno percorre a string textoMarcos, executando N vezes para cada iteração do laço externo. Multiplicando as execuções, temos um total de M x N iterações.
**3- Operações internas do laço:** Dentro do laço mais interno, o código realiza apenas avaliações de condições lógicas (if/else), acesso direto a posições de vetor e matriz, somas simples e a função Math.Max(). Todas essas operações levam tempo constante O(1).
**4- Equação final de Tempo:** O tempo total é ditado pelos laços de repetição: O(1) x (M x N) = O(M x N).
**Resumo da Complexidade - Apenas Programação Dinâmica:**
O(M x N)

**b- Versão que combina Programação Dinâmica com Backtracking**

**Onde verificar no código:** Arquivos `LcsProgramacaoDinamica.cs` (matriz) e `LcsProgramacaoDinamicaBacktracking.cs` (backtracking e ordenação).
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

## 🧪 Casos de Teste

A bateria de testes a seguir valida tanto a **interface** (estado inicial, contadores, botões) quanto o **algoritmo** (correção da LCS, múltiplas soluções, casos-limite e robustez).

| ID      | Cenário                            | Objetivo                                                                 | Entradas                                                                 | Resultado / Critério de aprovação                                                                                  |
| ------- | ---------------------------------- | ------------------------------------------------------------------------ | ------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------ |
| CT-001  | Inicialização da aplicação         | Verificar o estado inicial da tela ao abrir a aplicação.                 | Abrir a aplicação e observar a tela inicial.                             | Campos de quantidade, Helena e Marcos visíveis; botões **Executar LCS** e **Limpar** habilitados; resultados vazios; contador em **0/80**. |
| CT-002  | Alteração da quantidade de cenários| Verificar se a interface cria/remove campos conforme a quantidade.       | Alterar cenários: 1 → 5 → 2.                                             | Campos atualizados corretamente, sem campos "fantasmas", interface organizada.                                     |
| CT-003  | Botão Limpar                       | Confirmar que o botão limpa completamente a interface.                   | Preencher cenários, executar e clicar em **Limpar**.                     | Todos os campos vazios, área de resultados limpa, contadores em **0/80**.                                          |
| CT-004  | Contador de caracteres             | Verificar se o contador acompanha a digitação.                          | Digitar 10 caracteres e continuar até 80.                                | Contador exibe a quantidade correta; ao atingir o máximo mostra **80/80**.                                         |
| CT-005  | Campo vazio                        | Verificar se um campo vazio retorna mensagem de erro.                    | Helena: `abc` / Marcos: *(vazio)*                                         | Aprovado **somente** se a aplicação retornar erro pedindo o preenchimento das sequências.                          |
| CT-006  | Letras maiúsculas                  | Verificar o tratamento de letras maiúsculas.                            | Helena: `ABCDEF` / Marcos: `abcdef`                                      | Aprovado **somente** se retornar erro indicando uso apenas de minúsculas **ou** converter maiúsculas em minúsculas.|
| CT-007  | Caso oficial do enunciado ⭐        | Reproduzir exatamente a saída do enunciado. **(Obrigatório)**            | Helena: `ijkijkii` / Marcos: `ikjikji` (1 cenário)                       | Aprovado **somente** se as **7 sequências** aparecerem exatamente iguais ao PDF (LCS de tamanho 5).                |
| CT-008  | Sequências iguais                  | Verificar se, com entradas iguais, retorna a própria sequência.         | Helena: `abcdef` / Marcos: `abcdef`                                      | Aprovado **somente** se retornar a mesma sequência das entradas (`abcdef`).                                        |
| CT-009  | Apenas uma letra igual             | Verificar se, com só uma letra em comum, essa letra é retornada.        | Helena: `abc` / Marcos: `dbe`                                            | Aprovado **somente** se retornar a letra em comum (`b`).                                                           |
| CT-010  | Nenhuma letra em comum             | Verificar robustez quando não há subsequência válida.                   | Helena: `abc` / Marcos: `xyz`                                            | Aprovado **somente** se a aplicação tratar o caso sem travamentos (ex.: "Nenhuma subsequência comum encontrada"). |
| CT-011  | Múltiplas LCS                      | Retornar **todas** as maiores LCS, em ordem alfabética e sem repetição. | Helena: `abcbdab` / Marcos: `bdcaba`                                     | Aprovado **somente** se retornar todas as LCS esperadas (`bcab`, `bcba`, `bdab`).                                  |
| CT-012  | Limite de tamanho (80 caracteres)  | Verificar a matriz de PD no tamanho máximo permitido.                    | Helena e Marcos: duas strings idênticas de **80 caracteres** (alfabeto repetido). | Aprovado **somente** se retornar todas as maiores LCS, conforme esperado.                                          |
| CT-013  | Muitas letras repetidas            | Verificar se o backtracking percorre todos os caminhos.                  | Helena e Marcos: duas strings de **80 caracteres** no padrão `abab.../baba...`. | Aprovado **somente** se retornar todas as maiores LCS, sem travamentos e sem demora.                              |

> ⭐ **CT-007** é o caso obrigatório do enunciado e deve ser executado sempre antes de qualquer entrega.

---

## ✅ Checklist de requisitos (código)

| Requisito do roteiro | Status | Onde verificar |
| -------------------- | ------ | -------------- |
| Arquivo 1 — somente Programação Dinâmica | Atendido | `LcsProgramacaoDinamica.cs` |
| Arquivo 2 — PD + Backtracking | Atendido | `LcsProgramacaoDinamicaBacktracking.cs` |
| Cabeçalho com autores, versão e data | Atendido | Cabeçalho em todos os `.cs` |
| Comentários explicando cada parte | Atendido | `<summary>` e comentários inline |
| Validação das entradas (D ≤ 10, 1–80 letras, a–z) | Atendido | `ValidacaoEntrada.cs` + `MainForm.cs` |
| Legibilidade do código | Atendido | Nomes claros, métodos separados |
| Interface gráfica (bônus +3 pts) | Atendido | `MainForm.cs` / `MainForm.Designer.cs` |
| Saída: todas as LCS máximas, sem repetição, ordem alfabética | Atendido | `LcsProgramacaoDinamicaBacktracking.cs` |
| Linha em branco entre subsequências e entre cenários | Atendido | `FormatarSaidaCenario` + `MainForm.cs` |
| README com as 5 perguntas do roteiro | Atendido | Seções 1–5 deste arquivo |

---

## 📁 Estrutura do Projeto

```
/
├── Program.cs                              # Ponto de entrada da aplicação
├── LcsProgramacaoDinamica.cs               # ARQUIVO 1 — Somente PD (entrega)
├── LcsProgramacaoDinamicaBacktracking.cs   # ARQUIVO 2 — PD + Backtracking (entrega)
├── ValidacaoEntrada.cs                     # Validação de entradas (roteiro)
├── MainForm.cs                             # Lógica da interface gráfica
├── MainForm.Designer.cs                    # Layout visual da interface
├── CreditsForm.cs                          # Tela de créditos
└── README.md                               # Este arquivo (+ respostas do roteiro)
```

---

_Versão 1.0 — Junho de 2026_
