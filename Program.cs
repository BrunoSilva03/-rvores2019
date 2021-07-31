using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Árvores
{
    public class no
    {
        public int numero;
        public no esquerda;
        public no direita;
    }


    public class Arvore
    {
        public no raiz = null;


        public bool vazia()
        {
            if (raiz == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //Iterativo
        public bool existe(int num)
        {
            no auxiliar = raiz;

            while ((auxiliar != null) && (auxiliar.numero != num))
            {
                if (auxiliar.numero < num)
                {
                    auxiliar = auxiliar.direita;
                }
                else
                {
                    auxiliar = auxiliar.esquerda;
                }
            }

            if (auxiliar == null)
            {
                return false;
            }
            else
            {
                return true;
            }


        }




        //Recursivo
        public bool existe(int num, no auxiliar)
        {
            if (auxiliar == null)
            {
                return false;
            }
            else
            {
                if (auxiliar.numero == num)
                {
                    return true;
                }
                else
                {
                    if (auxiliar.numero < num)
                    {
                        return existe(num, auxiliar.direita);
                    }
                    else
                    {
                        return existe(num, auxiliar.esquerda);
                    }
                }
            }

        }


        public void Inserir(int num)
        {
            no novoNo;

            no pai = null;
            no auxiliar = raiz;

            if (existe(num) == true)
            {
                Console.WriteLine("Esse número já está presente na árvore!!!!!!");
            }
            else
            {
                while (auxiliar != null)
                {
                    pai = auxiliar;

                    if (auxiliar.numero < num)
                    {
                        auxiliar = auxiliar.direita;
                    }
                    else
                    {
                        auxiliar = auxiliar.esquerda;
                    }
                }

                novoNo = new no();
                novoNo.numero = num;
                novoNo.esquerda = null;
                novoNo.direita = null;

                if (pai == null)
                {
                    raiz = novoNo;
                }
                else
                {
                    if (pai.numero < num)
                    {
                        pai.direita = novoNo;
                    }
                    else
                    {
                        pai.esquerda = novoNo;
                    }
                }
            }

        }



        public void ExibirEmOrdem(no percorre)   //Percorre inicia sendo a raiz
        {
            if (percorre != null)
            {
                ExibirEmOrdem(percorre.esquerda);
                Console.WriteLine(percorre.numero);
                ExibirEmOrdem(percorre.direita);
            }
        }



        public void ExibirPreOrdem(no percorre)
        {
            if (percorre != null)
            {
                Console.WriteLine(percorre.numero);
                ExibirPreOrdem(percorre.esquerda);
                ExibirPreOrdem(percorre.direita);
            }
        }



        public void ExibirPosOrdem(no percorre)
        {
            if (percorre != null)
            {
                ExibirPosOrdem(percorre.esquerda);
                ExibirPosOrdem(percorre.direita);
                Console.WriteLine(percorre.numero);
            }
        }



        public void esvaziar()
        {
            raiz = null;
        }

        public int contagemElementos(no percorre)
        {
            if(percorre == null)
            {
                return 0;
            }
            else
            {
                return 1 + contagemElementos(percorre.esquerda) + contagemElementos(percorre.direita);
            }
        }


        /*
        public int contagemElementos(no percorre)
        {
            if(percorre == null)
            {
                return 0;
            }
            else
            {
                return 1 + contagemElementos(percorre.esquerda) + contagemElementos(percorre.direita);
            }
        }
        */


        public int contagemFolhas(no percorre)
        {
            if (percorre == null)
            {
                return 0;
            }
            else
            {
                if (percorre.esquerda == percorre.direita)
                {
                    return 1;
                }
                else
                {
                    return contagemFolhas(percorre.esquerda) + contagemFolhas(percorre.direita);
                }
            }
        }


        /*
        public int contagemFolhas(no percorre)
        {
            if(percorre == null)
            {
                return 0;
            }
            else
            {
                if(percorre.esquerda == percorre.direita)
                {
                    return 1;
                }
                else
                {
                    return contagemFolhas(percorre.esquerda) + contagemFolhas(percorre.direita);
                }
            }
        }
        */

        /*

    public int altura(no percorre)
    {
        int alturaEsquerda, alturaDireita;


        if (percorre == null)
        {
            return 0;
        }
        else
        {
            alturaEsquerda = 1 + altura(percorre.esquerda);
            alturaDireita = 1 + altura(percorre.direita);

            if (alturaEsquerda > alturaDireita)
            {
                return alturaEsquerda;
            }
            else
            {
                return alturaDireita;
            }
        }
    }


*/

        public int altura(no percorre)
        {
            int alturaEsquerda;
            int alturaDireita;

            if (percorre == null)
            {
                return 0;
            }
            else
            {
                alturaEsquerda = 1 + altura(percorre.esquerda);
                alturaDireita = 1 + altura(percorre.direita);

                if (alturaEsquerda > alturaDireita)
                {
                    return alturaEsquerda;
                }
                else
                {
                    return alturaDireita;
                }

            }
        }


        public int somaElementos(no percorre)
        {
            if (percorre == null)
            {
                return 0;
            }
            else
            {
                return percorre.numero + somaElementos(percorre.esquerda) + somaElementos(percorre.direita);
            }
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            int opc = 1;
            Arvore Ar = new Arvore();
            no nos = new no();

            do
            {
                Console.Clear();
                Console.WriteLine("*************ÁRVORES**************");
                Console.WriteLine("1. Verificar se a árvore está vazia");
                Console.WriteLine("2. Verificar se um número existe na árvore");
                Console.WriteLine("3. Inserir");
                Console.WriteLine("4. Exibir em ordem");
                Console.WriteLine("5. Exibir Pré Ordem");
                Console.WriteLine("6. Exibir Pós Ordem");
                Console.WriteLine("7. Esvaziar");
                Console.WriteLine("8. Contar nós");
                Console.WriteLine("9. Contar folhas");
                Console.WriteLine("10. Calcular altura da árvore");
                Console.WriteLine("11. Somar Nós da Árvore");
                opc = int.Parse(Console.ReadLine());



                switch (opc)
                {
                    case 1:
                        {
                            Console.Clear();
                            if (Ar.vazia() == true)
                            {
                                Console.WriteLine("Atualmente a Árvore está vazia.");
                            }
                            else
                            {
                                Console.WriteLine("Atualmente a Árvore NÃO está vazia.");
                            }
                            Console.ReadKey();
                        }
                        break;



                    case 2:
                        {
                            Console.Clear();
                            int num;
                            Console.Write("Digite o número que deseja pesquisar: ");
                            num = int.Parse(Console.ReadLine());

                            Console.Clear();

                            if (Ar.existe(num) == true)
                            {
                                Console.WriteLine("O número {0} ESTÁ presente na Árvore!", num);
                            }
                            else
                            {
                                Console.WriteLine("O número {0} NÃO ESTÁ presente na Árvore!", num);
                            }
                            Console.ReadKey();
                        }
                        break;



                    case 3:
                        {
                            Console.Clear();
                            int num;
                            Console.WriteLine("Digite o número que deseja inserir na Árvore: ");
                            num = int.Parse(Console.ReadLine());

                            Ar.Inserir(num);

                            Console.ReadKey();
                        }
                        break;








                    case 4:
                        {
                            Console.Clear();
                            if (Ar.vazia() == true)
                            {
                                Console.WriteLine("Ávore vazia atualmente");
                            }
                            else
                            {
                                Ar.ExibirEmOrdem(Ar.raiz);
                            }
                            Console.ReadKey();
                        }
                        break;






                    case 5:
                        {
                            Console.Clear();
                            if (Ar.vazia() == true)
                            {
                                Console.WriteLine("Árvore vazia atualmente");
                            }
                            else
                            {
                                Ar.ExibirPreOrdem(Ar.raiz);
                            }
                            Console.ReadKey();
                        }
                        break;



                    case 6:
                        {
                            Console.Clear();
                            if (Ar.vazia() == true)
                            {
                                Console.WriteLine("Árvore vazia atualmente");
                            }
                            else
                            {
                                Ar.ExibirPosOrdem(Ar.raiz);
                            }
                            Console.ReadKey();

                        }
                        break;






                    case 7:
                        {
                            Console.Clear();
                            Ar.esvaziar();

                            Console.WriteLine("Árvore esvaziada com suceso!!!!!!!!!!");
                            Console.ReadKey();
                        }
                        break;



                    case 8:
                        {
                            Console.Clear();
                            Console.WriteLine("Atualmente na árvore existem {0} nós!!!!!!!", Ar.contagemElementos(Ar.raiz));
                            Console.ReadKey();
                        }
                        break;



                    case 9:
                        {
                            Console.Clear();
                            Console.WriteLine("Atualmente na árvore existem {0} folhas!!!!!!!", Ar.contagemFolhas(Ar.raiz));
                            Console.ReadKey();
                        }
                        break;




                    case 10:
                        {
                            Console.Clear();
                            Console.WriteLine("Atualmente a altura da Árvore é {0} !!!!!!!!!!", Ar.altura(Ar.raiz));
                            Console.ReadKey();
                        }
                        break;



                    case 11:
                        {
                            Console.Clear();
                            Console.WriteLine("Resultado da soma dos nós da Árvore é {0} !!!!!!!", Ar.somaElementos(Ar.raiz));
                            Console.ReadKey();
                        }
                        break;




                }

            } while (opc != 0);
        }
    }
}
