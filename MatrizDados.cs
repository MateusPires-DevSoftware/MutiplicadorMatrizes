
public class MatrizDados
{
    public int[][] MatrizA { get; set; }
    public int[][] MatrizB { get; set; }
    public int[][] Result_MatrizC { get;    set; }
    public int Linha { get; set; }

    public MatrizDados(int[][] matrixA, int[][] matrixB, int[][] resultado_matrizc, int linha)
    {
        MatrizA = matrixA;
        MatrizB = matrixB;
        Result_MatrizC = resultado_matrizc;
        Linha = linha;
    }
}