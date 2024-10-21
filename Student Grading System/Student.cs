// Student.cs
public class Student
{
    public string Name { get; set; }
    public double Score { get; set; }
    public string Grade { get; set; }

    public void CalculateGrade()
    {
        if (Score >= 90)
            Grade = "A";
        else if (Score >= 80)
            Grade = "B";
        else if (Score >= 70)
            Grade = "C";
        else if (Score >= 60)
            Grade = "D";
        else
            Grade = "F";
    }
}
