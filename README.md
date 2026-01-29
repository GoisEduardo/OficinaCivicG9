# 🚗 Oficina Multi-Veículos - Gestão de Manutenção com C#

Este projeto evoluiu de um laboratório de estudos focado no meu Honda Civic G9 para um sistema robusto de gerenciamento de garagem, explorando padrões arquiteturais, resiliência de software e persistência polimórfica.

## 🧠 Aprendizados e "Pulos do Gato"

### 1. Interfaces e Polimorfismo (`IVeiculo`)
- **Abstração:** Saí de uma classe única para um contrato de interface, permitindo que o sistema gerencie tanto **Carros** quanto **Motos** de forma padronizada.
- **Regras de Negócio Dinâmicas:** Implementação de lógicas distintas (Troca de óleo a cada 10k km para carros e 3k km para motos) que são executadas automaticamente via polimorfismo, sem necessidade de `if/else` complexos no menu principal.



### 2. Persistência Polimórfica com JSON
- **`JsonDerivedType`:** Uso de discriminadores de tipo para que o motor de serialização do .NET identifique se o dado no arquivo `oficina.json` deve instanciar um `Carro` ou uma `Moto`.
- **Injeção de Dados:** Uso de construtores específicos para reconstruir objetos complexos mantendo a integridade do estado anterior.

### 3. Resiliência e Tratamento de Exceções
- **Custom Exceptions:** Criação da `KmInvalidaException`, uma exceção de negócio personalizada para impedir a entrada de quilometragem inconsistente (retroativa).
- **Programação Defensiva:** Implementação de blocos `try-catch` para garantir que o sistema se recupere caso o arquivo de dados esteja corrompido, carregando um estado inicial seguro via método auxiliar.



### 4. Consultas Inteligentes com LINQ
- **Métricas Financeiras:** Utilização de métodos de agregação (`Sum`, `Max`, `Count`) para gerar relatórios de gastos em tempo real.
- **Filtros Dinâmicos:** Uso de `Where` para buscar peças e marcas específicas dentro de coleções de objetos.

### 5. Boas Práticas e C# Moderno
- **Parâmetros `out`:** Utilizados para gerenciar a troca de estado (veículo focado) entre métodos de forma elegante.
- **Primary Constructors & Switch Expressions:** Código mais limpo e legível utilizando as últimas novidades do C# 12/13.



## 🛠️ Tecnologias e Conceitos
- **Linguagem:** C# (.NET 9)
- **Serialização:** System.Text.Json (Polymorphic Serialization)
- **Paradigma:** Orientação a Objetos Avançada
- **Versionamento:** Git/GitHub

---
*Projeto desenvolvido como parte de um roadmap de evolução técnica focado em desenvolvimento backend .NET.*