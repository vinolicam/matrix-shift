using System;
using System.Threading;

namespace Matrix03
{
    class Program
    {

        static void TypeLikeMegaMan(string Text, int Step)
        {
            int TextSize = Text.Length;
            int Delaytime = Step * 100;
            for (int VarText = 0; VarText < TextSize; VarText++)
            {
                Console.Write("{0}", Text[VarText]);
                Thread.Sleep(Delaytime);
                            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {

            //      program interacting with user
            TypeLikeMegaMan("Type the matrix size \n", 1);
            string TamanhoMatriz = Console.ReadLine();         //receive the user's input 'matrix size'
            Console.WriteLine();
            //      end of interaction.


            //      program's first part: create a square random matrix information NxN
            int N = System.Convert.ToInt16(TamanhoMatriz); //int.Parse(TamanhoMatriz);               //convert to integer the user's input

            int [,] MatrizDeDados = new int[N,N];       //Data Matrix declaration

            for (int j = 0; j < N; j++)                 //loop for fill the matrix with the information, first for count lines
            {
                for (int i = 0; i < N; i++)             //second for count collumns
                {
                    Random Aleatorio = new Random();    //instantiate an object from random class
                    MatrizDeDados[j, i] = Aleatorio.Next(50);   //fill the matrix spot with a random number from 0 to 50
                    Console.Write("{0}\t",MatrizDeDados[j,i]);  //write the curent matrix line on the screen 
                }
                Console.WriteLine();    //jumps to next line to give the usual matrix look like
            }
            //      end of the program's first part

            while (true)
            {
                //      program's second part
                TypeLikeMegaMan("\n Type how many degrees do you want to shift this matrix:\nYour choices are:\n90\t180\t270\t360\n",1);               
                string EntradaAngulo = Console.ReadLine();     //get the input
                int AnguloRoda = System.Convert.ToInt16(EntradaAngulo); //converts to integer
                                                                        //      end of the program's second part

                //      program's third part: time to shift the matriz by 90 degrees conter clock wise
                Console.WriteLine("\n Behold the power to shift numbers position by {0} \n",AnguloRoda);  //put on the screen the anouncement of the matrix shifted by 90 degrees
          
                    int[,] MatrizGirada = new int[N, N];   //declare a new matriz whom will hold the new arrangment of the numbers
                    int QuantidadeGiro = AnguloRoda / 90;
                    for (int vari = 1; vari <= QuantidadeGiro; vari++)
                    {
                            for (int k = 0; k < N; k++)              //loop for count line and collumn
                            {
                                for (int g = N; g > 0; g--)           //inner loop for count line and collumn
                                {
                                    //the logics is simple: the first line become the first collumn up side down, and goes on...
                                    MatrizGirada[g - 1, k] = MatrizDeDados[k, N - g];
                                }
                            }

                            MatrizDeDados = MatrizGirada;
                       
                    
                            Console.WriteLine("\nMatrix shifted by {0}\n", vari * 90);

                            for (int t = 0; t < N; t++)              //loop to write the shifted matrix on the screen. first loop for lines
                            {
                                for (int r = 0; r < N; r++)           //second loop for collumns
                                {
                                    Console.Write("{0}\t", MatrizGirada[t, r]);
                                }
                                Console.WriteLine();
                            }
                    }
                

                string Condicao;
                TypeLikeMegaMan("Do you want to continue?\n y or n \n",1);
                Condicao = Console.ReadLine();
                if (Condicao == "n")
                { break; }
                else
                { }
            }
            //      end of the program's third part

            
            // the program's end
        }
    }
}
