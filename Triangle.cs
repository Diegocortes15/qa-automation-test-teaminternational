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
      return Math.Round(Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)), 1);
    }

    private void calculateSides()
    {

      this.sides[0] = calculateSide(vertices[0, 0], vertices[0, 1], vertices[1, 0], vertices[1, 1]);
      this.sides[1] = calculateSide(vertices[1, 0], vertices[1, 1], vertices[2, 0], vertices[2, 1]);
      this.sides[2] = calculateSide(vertices[2, 0], vertices[2, 1], vertices[0, 0], vertices[0, 1]);
      Console.WriteLine("Side 1: ........" + this.sides[0]);
      Console.WriteLine("Side 2: ........" + this.sides[1]);
      Console.WriteLine("Side 3: ........" + this.sides[2]);
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
      return Math.Round((Math.Acos((Math.Pow(bSide, 2) + Math.Pow(cSide, 2) - Math.Pow(aSide, 2)) / (2 * bSide * cSide))) * 180 / Math.PI, 1);
    }

    private void calculateAngles()
    {
      this.angles[0] = calculateAngle(this.sides[0], this.sides[1], this.sides[2]);
      this.angles[1] = calculateAngle(this.sides[1], this.sides[0], this.sides[2]);
      this.angles[2] = calculateAngle(this.sides[2], this.sides[0], this.sides[1]);
    }

    public bool isEquilateral()
    {
      if (!isTriangle()) return false;
      if (this.sides[0] == this.sides[1] && this.sides[1] == this.sides[2])
      {
        return true;
      }
      return false;
    }

    public bool isIsosceles()
    {
      if (isTriangle() && isEquilateral()) return false;
      else if (this.sides[0] == this.sides[1] || this.sides[1] == this.sides[2] || this.sides[2] == this.sides[0])
      {
        return true;
      }
      return false;
    }

    public bool isRight()
    {
      if (!isTriangle()) return false;
      Console.WriteLine("Angle 1: ........" + this.angles[0]);
      Console.WriteLine("Angle 2: ........" + this.angles[1]);
      Console.WriteLine("Angle 3: ........" + this.angles[2]);
      if (this.angles.Any(angle => angle == 90))
      {
        return true;
      }
      return false;
    }

    public void calculatePerimeter()
    {
      var triangleSides = (aSide: this.sides[0], bSide: this.sides[1], cSide: this.sides[2]);
      (double aSide, double bSide, double cSide) = triangleSides;
      this.perimeter = aSide + bSide + cSide;
    }

    public void calculateEvenNumbersFromPerimeter()
    {
      double perimeter = this.perimeter;
      for (int i = 0; i <= perimeter; i += 2)
      {
        this.evenNumbersFromPerimeter.Add(i);
      }
      foreach (var item in this.evenNumbersFromPerimeter)
      {
        Console.WriteLine(item);
      }
    }
  }
}
