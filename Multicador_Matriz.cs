using System;
using System.Threading;
using System.Diagnostics.Contracts;

public class Multicador_Matriz
{
    public static void AuxiliarImpressao(int[][] matrizA, int[][] matrizB, int[][] resultado_matrizc)
    {
        Console.WriteLine("Matriz A:");
        ImprimirMatriz(matrizA);

        Console.WriteLine("\nMatriz B:");
        ImprimirMatriz(matrizB);

        Console.WriteLine("\nResultado da multiplicação (MATRIZ C):");
        ImprimirMatriz(resultado_matrizc);
    }

    private static void ImprimirMatriz(int[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i][j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public static int[][] CalculoMatriz(int[][] matrizA, int[][] matrizB)
    {
        int linA = matrizA.Length;
        int colA = matrizA[0].Length;
        int linB = matrizB.Length;
        int colB = matrizB[0].Length;

        if (colA != linB)
        {
            throw new ArgumentException("As matrizes não podem ser multiplicadas. O número de colunas de A deve ser igual ao número de linhas de B.");
        }

        int[][] result = new int[linA][];

        Thread[] threads = new Thread[linA];

        for (int i = 0; i < linA; i++)
        {
            result[i] = new int[colB];
            threads[i] = new Thread(CalculoLinha);
            threads[i].Start(new MatrizDados(matrizA, matrizB, result, i));
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        return result;
    }

    private static void CalculoLinha(object data)
    {
        MatrizDados aux_linha = (MatrizDados)data;
        int[][] matrizA = aux_linha.MatrizA;
        int[][] matrizB = aux_linha.MatrizB;
        int[][] resultado_matrizc = aux_linha.Result_MatrizC;
        int linha = aux_linha.Linha;

        int colA = matrizA[0].Length;
        int colB = matrizB[0].Length;


        for (int j = 0; j < colB; j++)
        {
            int aux = 0;
            for (int k = 0; k < colA; k++)
            {
                Console.WriteLine("Calculo linha: {0} \nMultiplicando {1} por {2} \n\n",linha,
                matrizA[linha][k],
                matrizB[k][j]);
                
                aux += matrizA[linha][k] * matrizB[k][j];
            }
            resultado_matrizc[linha][j] = aux;
        }

        Console.WriteLine("Linha {0} calculada.",linha);
        Console.WriteLine("------------------------------------------------------------------------");
    }
}
