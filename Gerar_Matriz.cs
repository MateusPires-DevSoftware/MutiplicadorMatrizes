
public class Gerar_Matriz
{
    public static int[][] InserirDados(string matriz)
    {

        Console.Write("Informe o número de linhas da {0}:",matriz);
        int linhas = int.Parse(Console.ReadLine());

        Console.Write("Informe o número de colunas da {0}:",matriz);
        int colunas = int.Parse(Console.ReadLine());

        int[][] aux_matrix = new int[linhas][];

        Console.WriteLine("Informe os elementos da {0}!",matriz);

        for (int i = 0; i < linhas; i++)
        {
            aux_matrix[i] = new int[colunas];
            for (int j = 0; j < colunas; j++)
            {
                Console.Write("Digite o elemento da linha {0}, coluna {1}: ", i+1
                ,j+1);
                aux_matrix[i][j] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine("------------------------------------------------------------------------");
        return aux_matrix;
    }
    public Gerar_Matriz()
    {
        int[][] matrizA = InserirDados("Matriz A");
        int[][] matrizB = InserirDados("Matriz B");

        int[][] resultado_matrizc = Multicador_Matriz.CalculoMatriz(matrizA, matrizB);
        Multicador_Matriz.AuxiliarImpressao(matrizA, matrizB, resultado_matrizc);
    }


}





