# 🚗 Oficina do Civic G9 - Sistema de Manutenção em C#

Este projeto é um laboratório de estudos focado em fundamentos avançados de C# .NET Core, simulando o controle de manutenção de um Honda Civic G9.

## 🧠 Aprendizados e "Pulos do Gato"

### 1. Orientação a Objetos e Estado
- Implementei a classe `Veiculo` para encapsular regras de negócio (como o cálculo de troca de óleo).
- Aprendi a diferença entre a **Classe** (planta) e o **Objeto** (o carro vivo na memória).

### 2. O Mistério dos Construtores
- **Construtor com Parâmetros:** Utilizado para garantir que nenhum veículo nasça sem dados essenciais.
- **Construtor Vazio (`JsonConstructor`):** Essencial para o motor de serialização do .NET conseguir reconstruir o objeto a partir de um arquivo físico.

### 3. Persistência de Dados (JSON)
- Uso de `System.Text.Json` para salvar o estado completo da oficina (`DadosOficina`) em um arquivo `.json`.
- Implementação de lógica de carregamento automático ao iniciar o sistema.

### 4. Boas Práticas
- Uso de **Primary Constructors** e **Switch Expressions** (C# 12).
- Separação de responsabilidades em métodos estáticos.