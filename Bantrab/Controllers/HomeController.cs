using Bantrab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bantrab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public Matrix greatMatrix = new Matrix();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private List<List<decimal>> sumarMatriz(Matrix matrix)
        {
            var matriz = greatMatrix.Matriz;
            var newColumn = new List<decimal>();
            var total = (decimal)0;


            for (int j = 0; j < matriz[0].Count; j++)
            {
                var num = (decimal)0;
                num += matriz[0][j];
                num += matriz[1][j];
                total += num;
                newColumn.Add(num);
            }

            matrix.TotalColumna31 = total;
            matriz.Add(newColumn);
            return matriz;
        }

        public IActionResult Index(Matrix matrix)
        {
            greatMatrix.Matriz = matrix.Matriz;
            
            matrix.Matriz = sumarMatriz(matrix);

            return View(matrix);
        }


        public IActionResult AgregarFilasyColumna(Matrix matrix)
        {
            greatMatrix.Matriz = matrix.Matriz;

            matrix.Matriz = sumarMatriz(matrix);
            matrix.Matriz.Add(new List<decimal> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            foreach (var item in matrix.Matriz)
            {
                item.Add(0);
                item.Add(0);
            }

            matrix.Matriz = trasladarMatriz(matrix);
            
            return View(matrix);
        }

        private List<List<decimal>> trasladarMatriz(Matrix matrix)
        {
            var matriz = matrix.Matriz;
            // TRasladar
                matriz[0][10] = matriz[0][0];
                matriz[0][11] = matriz[0][1];

       
            // sumar total fila 1 y 2 columna 2
            decimal sum = matriz[1][0] + matriz [1][1];
            matrix.TotalFila1y2Columna21 = sum;

            // eliminar valores de filas 1 y 2 columna 2
            matriz[1][0] = 0;
            matriz[1][1] = 0;

  
            // dividir total del inciso anterior y colocar partes iguales en columna 4 filas 3 a 7

            decimal division =  matrix.TotalFila1y2Columna21 / 5;

            for (int i = 2; i < 7; i++)
            {
                matriz[3][i] = division;
            }

            //Llenar columna 3 con la suma de las columnas 1, 2 y 4
            for (int i = 0; i < matriz[2].Count; i++)
            {
                matriz[2][i] = matriz[0][i] + matriz[1][i] + matriz[3][i];
            }

            decimal total = 0;
            foreach (var item in matriz[2])
            {
                total += item;
            }

            matrix.TotalColumna31 = total;

            return matriz;
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}