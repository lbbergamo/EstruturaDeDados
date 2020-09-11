using System;
using System.Collections.Generic;
using System.Linq;

/**
 * Projeto esta em um repositorio no github 
 * https://github.com/lbbergamo/EstruturaDeDados
 * Leandro Bergamo 160548
 */
namespace Estrutura_de_Dados___ArvoreBinaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Arvore tree = new Arvore();
            int opc = 0;
            int[] vetor = new int[] { 50, 40, 35, 38, 37, 45, 42, 47, 43, 60, 52, 56, 54, 65, 61, 62, 80, 90 };
            for (int i = 0; i < vetor.Length; i++)
            {
                int n = vetor[i];
                tree.Inserir(n);
            }

            do
            {
                Console.WriteLine(" Menu \n");
                Console.WriteLine("1- Inserção de elementos");
                Console.WriteLine("2- Percurso em Pré-ordem");
                Console.WriteLine("3- Percurso em Ordem");
                Console.WriteLine("4- Percurso em Pós-Ordem");
                Console.WriteLine("5- Percurso em Nível");
                Console.WriteLine("6 - Excluir valor da árvore / Com ou sem Filho");
                opc = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Informe o valor a ser inserido:");
                        int val = Convert.ToInt32(Console.ReadLine());
                        tree.Inserir(val);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Exibindo os valores em pré ordem");
                        tree.PreOrdem(tree.Root);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Exibindo os valores em em ordem");
                        tree.EmOrdem(tree.Root);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("Exibindo os valores em pos ordem");
                        tree.PosOrdem(tree.Root);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                       
                        Console.WriteLine("Exibindo os valores em Nivel");
                        tree.EmNivel(tree.Root);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        Console.WriteLine("Informe o valor a ser excluído:");
                        val = Convert.ToInt32(Console.ReadLine());
                        tree.Excluir(tree.Root, val);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }

            } while (opc != 9);
        }
    }

    class Arvore
    {
        ArvoreBinaria root = new ArvoreBinaria();
        int quantidade = 0;

        public ArvoreBinaria Root
        {
            get { return root; }
        }
        public string Quantidade
        {
            get { return quantidade.ToString(); }
        }
        public void Inserir(int valor)
        {
            ArvoreBinaria newNo = new ArvoreBinaria();
            newNo.setValor(valor);
            if (Root.getAnterior == null && root.getValor == null)
            {
                root.setValor(valor);
                root.setDireita(null);
                root.setEsquerda(null);
            }
            else
            {
                ArvoreBinaria aux = BuscarInsercao(valor);
                if (aux == null)
                {
                    Console.WriteLine("Valor existente - " + valor);
                }
                else
                {
                    if (valor > aux.getValor)
                    {
                        aux.setDireita(newNo);
                        newNo.setAnterior(aux);
                    }
                    else
                    {
                        aux.setEsquerda(newNo);
                        newNo.setAnterior(aux);
                    }
                }
            }
            quantidade++;
        }

        public void Excluir(ArvoreBinaria no, int? valor)
        {
            if (no == null)
            {
                Console.WriteLine("Não há nada para buscar!");
            }
            else
            {
                if (valor > no.getValor)
                {
                    Excluir(no.getDireita, valor);
                }
                else if (valor < no.getValor)
                {
                    Excluir(no.getEsquerda, valor);
                }
                else
                {
                    if (no.getDireita != null && no.getEsquerda != null)// se o nó possuir dois filhos
                    {
                        ArvoreBinaria aux = new ArvoreBinaria();
                        aux = no.getDireita;
                        while (aux.getEsquerda != null)// percorre até chegar ao nó mais a esquerda do nó a direita
                        {
                            aux = aux.getEsquerda;
                        }
                        no.setValor(aux.getValor);// torna o valor obtido em pai
                        Excluir(aux, aux.getValor);//aplica para o filho do novo pai
                        Console.WriteLine("Valor removido com sucesso!");
                        quantidade--;
                    }
                    else if (no.getDireita != null)//se só possuir o filho direito
                    {
                        SubstituirPaiNo(no.getDireita);
                    }
                    else if (no.getEsquerda != null)// se só possuir o filho esquerdo
                    {

                        SubstituirPaiNo(no.getEsquerda);
                    }
                    else//se não possuir filhos :(
                    {
                        if (no.getValor > no.getAnterior.getValor)
                        {
                            no.getAnterior.setDireita(null);
                        }
                        else
                        {
                            no.getAnterior.setEsquerda(null);
                        }
                    }
                }
            }
        }

   

        public void SubstituirPaiNo(ArvoreBinaria no)
        {
            if (no == no.getAnterior.getEsquerda)// se for o nó esquerdo
            {
                no.setAnterior(no.getAnterior.getAnterior);
                no.getAnterior.setEsquerda(no);// o filho esquerdo do pai vira null
            }
            else if (no == no.getAnterior.getDireita)// se for o nó direito
            {
                no.setAnterior(no.getAnterior.getAnterior);// o filho direito do pai vira null
                no.getAnterior.setDireita(no);
            }
        }


        public ArvoreBinaria BuscarInsercao(int valor)
        {
            ArvoreBinaria no;
            no = Root;
            bool x = true;
            do
            {
                if (valor < no.getValor)
                {
                    if (no.getEsquerda == null)
                    {
                        x = false;
                        return no;
                    }
                    if (no.getEsquerda != null)
                    {
                        no = no.getEsquerda;
                    }
                }

                if (valor > no.getValor)
                {
                    if (no.getDireita == null)
                    {
                        x = false;
                        return no;
                    }
                    if (no.getDireita != null)
                    {
                        no = no.getDireita;
                    }
                }

                if (valor == no.getValor)
                {
                    return null;
                }
            } while (x);
            return null;
        }

        public int Maior(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        public int Altura(ArvoreBinaria no)
        {
            if ((no == null) || (no.getEsquerda == null && no.getDireita == null))
            {
                return 0;
            }
            else
            {
                return 1 + (Maior(Altura(no.getEsquerda), Altura(no.getDireita)));
            }
        }

        public void PreOrdem(ArvoreBinaria obj)
        {
            if (obj != null)
            {
                Console.Write(obj.getValor + "  ");
                PreOrdem(obj.getEsquerda);
                PreOrdem(obj.getDireita);
            }
        }

        public void EmOrdem(ArvoreBinaria obj)
        {
            if (obj != null)
            {
                EmOrdem(obj.getEsquerda);
                Console.Write(obj.getValor + "  ");
                EmOrdem(obj.getDireita);
            }
        }
        public void PosOrdem(ArvoreBinaria obj)
        {
            if (obj != null)
            {
                EmOrdem(obj.getEsquerda);
                EmOrdem(obj.getDireita);
                Console.Write(obj.getValor + "  ");
            }
        }
        public void EmNivel(ArvoreBinaria obj)
        {
            List<ArvoreBinaria> ArrayArvore = new List<ArvoreBinaria>() { obj };
            ArvoreBinaria temp;
            while (ArrayArvore.Count != 0)
            {
                temp = ArrayArvore.First();
                Console.Write("{0} ", temp.getValor);
                if (temp.getEsquerda != null) ArrayArvore.Add(temp.getEsquerda);
                if (temp.getDireita != null) ArrayArvore.Add(temp.getDireita);
                ArrayArvore.RemoveAt(0);
            }
        }
    }
    class ArvoreBinaria
    {
        int? valor;
        ArvoreBinaria anterior, esquerda, direita;

        public int? getValor
        {
            get { return valor; }
        }

        public ArvoreBinaria getAnterior
        {
            get { return anterior; }
        }

        public ArvoreBinaria getDireita
        {
            get { return direita; }
        }

        public ArvoreBinaria getEsquerda
        {
            get { return esquerda; }
        }

        public void setValor(int? val)
        {
            valor = val;
        }

        public void setAnterior(ArvoreBinaria no)
        {
            anterior = no;
        }

        public void setDireita(ArvoreBinaria no)
        {
            direita = no;
        }

        public void setEsquerda(ArvoreBinaria no)
        {
            esquerda = no;
        }
    }
}
