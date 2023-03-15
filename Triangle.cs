namespace qa_automation_test_teaminternational
{
  class Triangle
  {
    private double[] sides = new double[3];
    private double[] angles = new double[3];
    private double[,] vertices = new double[3, 2];
    private double perimeter;
    private double delta = 0.55;
    private List<double> evenNumbersFromPerimeter = new List<double>();
    public Triangle(double[,] vertices)
    {
      this.vertices = vertices;
      this.calculateSides();
      if (isTriangle())
      {
        this.calculatePerimeter();
        this.calculateEvenNumbersFromPerimeter();
        this.output();
      }
      else
      {
        this.output();
      }
    }

    public Triangle()
    { }

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
      this.calculateSides();
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
      return Math.Round(angle, 2);
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
      else
      {
        var triangleSides = (aSide: this.sides[0], bSide: this.sides[1], cSide: this.sides[2]);
        (double aSide, double bSide, double cSide) = triangleSides;
        if (aSide == bSide || bSide == cSide || cSide == aSide)
        {
          return true;
        }
        return false;
      }
    }

    private bool isRight()
    {
      this.calculateAngles();
      if (this.angles.Any(angle => (angle <= 90 + this.delta && angle >= 90 - this.delta)))
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
      this.evenNumbersFromPerimeter.Clear();
      double perimeter = this.perimeter;
      for (int i = 0; i <= perimeter; i += 2)
      {
        this.evenNumbersFromPerimeter.Add(i);
      }
    }

    public string printSides()
    {
      if (!isTriangle()) return "printSides: The triangle is invalid";
      return $"Length of AB is {this.sides[0]}\nLength of BC is {this.sides[1]}\nLength of CA is {this.sides[2]}";
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
      this.calculatePerimeter();
      return $"Perimeter: {this.perimeter}";
    }

    public string printEvenNumbersToPerimeter()
    {
      if (!isTriangle()) return "printEvenNumberToPerimeter: The triangle is invalid";
      this.calculateEvenNumbersFromPerimeter();
      string outputEvenNumbersToPerimeter = "Parity numbers in range from 0 to triangle perimeter:\n";
      foreach (var item in this.evenNumbersFromPerimeter)
      {
        outputEvenNumbersToPerimeter += $"{item}\n";
      }
      return outputEvenNumbersToPerimeter;
    }

    public string printCoordinates()
    {
      return $"Coordinates:\nA = ({this.vertices[0, 0]}, {this.vertices[0, 1]})\nB = ({this.vertices[1, 0]}, {this.vertices[1, 1]})\nC = ({this.vertices[2, 0]}, {this.vertices[2, 1]})";
    }

    public void output()
    {
      Console.WriteLine($"{this.printCoordinates()}\n");
      if (!isTriangle())
      {
        Console.WriteLine("output: The triangle is invalid");
        return;
      };
      string output = $"{this.printSides()}\n\n{this.printType()}\n\n{this.printPerimeter()}\n\n{this.printEvenNumbersToPerimeter()}";
      Console.WriteLine(output);
    }

    public void setXA(double x)
    {
      this.vertices[0, 0] = x;
    }
    public void setYA(double y)
    {
      this.vertices[0, 1] = y;
    }
    public void setXB(double x)
    {
      this.vertices[1, 0] = x;
    }
    public void setYB(double y)
    {
      this.vertices[1, 1] = y;
    }
    public void setXC(double x)
    {
      this.vertices[2, 0] = x;
    }
    public void setYC(double y)
    {
      this.vertices[2, 1] = y;
    }
  }
}
