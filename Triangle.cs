namespace qa_automation_test_teaminternational
{
  class Triangle
  {
    private double[] sides = new double[3];
    private double[,] vertices;
    private double[] angles = new double[3];
    public double perimeter;
    List<double> evenNumbersFromPerimeter = new List<double>();
    public Triangle(double[,] vertices)
    {
      this.vertices = vertices;
      this.calculateSides();
      if (isTriangle())
      {
        this.calculateAngles();
        this.calculatePerimeter();
        this.calculateEvenNumbersFromPerimeter();
      }
    }

    private double calculateSide(double x1, double y1, double x2, double y2)
    {
      double dx = Math.Abs(x1 - x2);
      double dy = Math.Abs(y1 - y2);
      return Math.Round(Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)), 2);
    }

    private void calculateSides()
    {
      this.sides[0] = calculateSide(vertices[0, 0], vertices[0, 1], vertices[1, 0], vertices[1, 1]);
      this.sides[1] = calculateSide(vertices[1, 0], vertices[1, 1], vertices[2, 0], vertices[2, 1]);
      this.sides[2] = calculateSide(vertices[2, 0], vertices[2, 1], vertices[0, 0], vertices[0, 1]);
    }

    public bool isTriangle()
    {
      var triangleSides = (aSide: this.sides[0], bSide: this.sides[1], cSide: this.sides[2]);
      (double aSide, double bSide, double cSide) = triangleSides;

      if (aSide + bSide > cSide && bSide + cSide > aSide && cSide + aSide > bSide)
      {
        return true;
      }
      return false;
    }

    private double calculateAngle(double aSide, double bSide, double cSide)
    {
      double cos = (bSide * bSide + cSide * cSide - aSide * aSide) / (2 * bSide * cSide);
      double angle = Math.Acos(cos) * 180 / Math.PI;
      return Math.Round(angle);
    }

    private void calculateAngles()
    {
      this.angles[0] = calculateAngle(this.sides[0], this.sides[1], this.sides[2]);
      this.angles[1] = calculateAngle(this.sides[1], this.sides[0], this.sides[2]);
      this.angles[2] = calculateAngle(this.sides[2], this.sides[0], this.sides[1]);
    }

    private bool isEquilateral()
    {
      if (this.sides[0] == this.sides[1] && this.sides[1] == this.sides[2])
      {
        return true;
      }
      return false;
    }

    private bool isIsosceles()
    {
      if (isEquilateral()) return false;
      else if (this.sides[0] == this.sides[1] || this.sides[1] == this.sides[2] || this.sides[2] == this.sides[0])
      {
        return true;
      }
      return false;
    }

    private bool isRight()
    {
      if (this.angles.Any(angle => angle == 90))
      {
        return true;
      }
      return false;
    }

    private void calculatePerimeter()
    {
      var triangleSides = (aSide: this.sides[0], bSide: this.sides[1], cSide: this.sides[2]);
      (double aSide, double bSide, double cSide) = triangleSides;
      this.perimeter = aSide + bSide + cSide;
    }

    private void calculateEvenNumbersFromPerimeter()
    {
      double perimeter = this.perimeter;
      for (int i = 0; i <= perimeter; i += 2)
      {
        this.evenNumbersFromPerimeter.Add(i);
      }
    }

    public string printSides()
    {
      if (!isTriangle()) return "printSides: The triangle is invalid";
      return $"Length of AB is {this.sides[0]}\nLength of BC is {this.sides[1]}\nLength of AB is {this.sides[0]}";
    }

    public string printType()
    {
      if (!isTriangle()) return "printType: The triangle is invalid";
      string isTriangleEquilateral = this.isEquilateral() ? "Triangle is 'Equilateral'" : "Triangle is NOT 'Equilateral'";
      string isTriangleIsosceles = this.isIsosceles() ? "Triangle is 'Isosceles'" : "Triangle is NOT 'Isosceles'";
      string isTriangleRight = this.isRight() ? "Triangle is 'Right'" : "Triangle is NOT 'Right'";
      return $"{isTriangleEquilateral}\n{isTriangleIsosceles}\n{isTriangleRight}";
    }

    public string printPerimeter()
    {
      if (!isTriangle()) return "printPerimeter: The triangle is invalid";
      return $"Perimeter: {this.perimeter}";
    }

    public string printEvenNumbersToPerimeter()
    {
      if (!isTriangle()) return "printEvenNumberToPerimeter: The triangle is invalid";
      string outputEvenNumbersToPerimeter = "Parity numbers in range from 0 to triangle perimeter:\n";
      foreach (var item in this.evenNumbersFromPerimeter)
      {
        outputEvenNumbersToPerimeter += $"{item}\n";
      }
      return outputEvenNumbersToPerimeter;
    }

    public void output()
    {
      if (!isTriangle())
      {
        Console.WriteLine("output: The triangle is invalid");
        return;
      };
      string output = $"{this.printSides()}\n\n{this.printType()}\n\n{this.printPerimeter()}\n\n{this.printEvenNumbersToPerimeter()}";
      Console.WriteLine(output);
    }
  }
}
