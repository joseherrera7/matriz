namespace Bantrab.Models
{
    public class Matrix
    {
        private List<List<decimal>> matriz = new List<List<decimal>> { new List<decimal> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new List<decimal> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } };
        private decimal TotalColumna3;
        private decimal TotalFila1y2Columna2;

        public List<List<decimal>> Matriz { get => matriz; set => matriz = value; }
        public decimal TotalColumna31 { get => TotalColumna3; set => TotalColumna3 = value; }
        public decimal TotalFila1y2Columna21 { get => TotalFila1y2Columna2; set => TotalFila1y2Columna2 = value; }
    }
}
