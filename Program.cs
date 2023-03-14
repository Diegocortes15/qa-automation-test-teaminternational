// See https://aka.ms/new-console-template for more information

namespace qa_automation_test_teaminternational
{
  class Program
  {
    static void Main(string[] args)
    {
      double[,] triangleVertices = new double[,] { { 0, 0 }, { 2, 3.4641016151378 }, { 4, 0 } };
      Triangle triangle = new Triangle(triangleVertices);
      Console.WriteLine("isTriangle: ....." + triangle.isTriangle());
      Console.WriteLine("isEquilateral: .." + triangle.isEquilateral());
      Console.WriteLine("isIsosceles: ...." + triangle.isIsosceles());
      Console.WriteLine("isRight: ........" + triangle.isRight());
      Console.WriteLine("Perimeter: ........" + triangle.perimeter);
    }
  }
}
