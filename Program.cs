// See https://aka.ms/new-console-template for more information

namespace qa_automation_test_teaminternational
{
  class Program
  {
    static void Main(string[] args)
    {
      double[,] triangleVertices = new double[,] { { 0, 0 }, { 0, 4 }, { 4, 0 } };
      //double[,] triangleVertices = new double[,] { { 0, 0 }, { 3, 4 }, { 3, 0 } };
      //double[,] triangleVertices = new double[,] { { 0, 0 }, { 2, 3.4641016151378 }, { 4, 0 } };
      //double[,] triangleVertices = new double[,] { { 1, 1 }, { 2, 2 }, { 3, 3 } };
      Triangle triangle = new Triangle(triangleVertices);
      triangle.output();
    }
  }
}
