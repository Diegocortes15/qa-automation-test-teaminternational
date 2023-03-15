namespace qa_automation_test_teaminternational
{
  class AppTriangleInterface
  {
    private Triangle triangle = new Triangle();
    private bool exit = false;

    public AppTriangleInterface()
    { }

    private void appTitle()
    {
      Console.Clear();
      Console.WriteLine("*** x=x=x=x=x=x=x=x=x=x=x=x=x=x=x=x ***");
      Console.WriteLine("*** Triangle Properties Application ***");
      Console.WriteLine("*** =x=x=x=x=x=x=x=x=x=x=x=x=x=x=x= ***");
      Console.WriteLine("\n");
    }

    private void verticesInput()
    {
      this.setCoordinate('x', 'A');
      this.setCoordinate('y', 'A');
      this.setCoordinate('x', 'B');
      this.setCoordinate('y', 'B');
      this.setCoordinate('x', 'C');
      this.setCoordinate('y', 'C');
    }

    private void setCoordinate(char coordinate, char dot)
    {
      Console.WriteLine($"Enter coordinate {coordinate} of dot {dot}:");
      string? strValue = Console.ReadLine();
      double parsedValue;
      if (!double.TryParse(strValue, out parsedValue) || strValue == null)
      {
        Console.WriteLine($"The value entered as coordinate '{strValue}' is NOT valid");
        setCoordinate(coordinate, dot);
      };
      if (coordinate.ToString().ToLower() == "x" && dot.ToString().ToLower() == "a") triangle.setXA(parsedValue);
      if (coordinate.ToString().ToLower() == "y" && dot.ToString().ToLower() == "a") triangle.setYA(parsedValue);
      if (coordinate.ToString().ToLower() == "x" && dot.ToString().ToLower() == "b") triangle.setXB(parsedValue);
      if (coordinate.ToString().ToLower() == "y" && dot.ToString().ToLower() == "b") triangle.setYB(parsedValue);
      if (coordinate.ToString().ToLower() == "x" && dot.ToString().ToLower() == "c") triangle.setXC(parsedValue);
      if (coordinate.ToString().ToLower() == "y" && dot.ToString().ToLower() == "c") triangle.setYC(parsedValue);
    }

    private void questionCoordinatesCorrect()
    {
      Console.WriteLine("Are the following coordinates correct?");
      Console.WriteLine(this.triangle.printCoordinates());
      Console.WriteLine("(y/n): ");
      string? input = Console.ReadLine();
      switch (input?.ToLower())
      {
        case "y":
          this.appTitle();
          this.triangle.output();
          this.questionSetNewCoordinates();
          break;
        case "n":
          this.appTitle();
          this.questionSetNewCoordinates();
          break;
        default:
          this.appTitle();
          Console.WriteLine("Invalid choice");
          this.questionCoordinatesCorrect();
          break;
      }
    }
    private void questionSetNewCoordinates()
    {
      Console.WriteLine("Would you like to set new coordinates? (y/n): ");
      string? input = Console.ReadLine();
      switch (input)
      {
        case "y":
          this.appInterface();
          break;
        case "n":
          this.exit = true;
          break;
        default:
          this.appTitle();
          Console.WriteLine("Invalid choice");
          this.questionSetNewCoordinates();
          break;
      }
    }

    public void appInterface()
    {
      do
      {
        this.appTitle();
        this.verticesInput();
        this.appTitle();
        if (!this.triangle.isTriangle())
        {
          this.triangle.output();
          this.questionSetNewCoordinates();
        }
        else
        {
          this.questionCoordinatesCorrect();
        }
      } while (!this.exit);
      return;
    }
  }
}
