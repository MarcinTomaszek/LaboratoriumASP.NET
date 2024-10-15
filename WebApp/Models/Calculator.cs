

using WebApp.Controllers;

namespace WebApp.Models;

public class Calculator
{
    public CalculatorController.Operators? Operator { get; set; }
    public double? X { get; set; }
    public double? Y { get; set; }

    public String Op
    {
        get
        {
            switch (Operator)
            {
                case CalculatorController.Operators.Add:
                    return "+";
                case CalculatorController.Operators.Sub:
                    return "-";
                case CalculatorController.Operators.Mul:
                    return "*";
                case CalculatorController.Operators.Div:
                    return "/";
                case CalculatorController.Operators.Pow:
                    return "^";
                default:
                    return "";
            }
        }
    }

    public bool IsValid()
    {
        return Operator != null && X != null && Y != null;
    }

    public double Calculate() {
        switch (Operator)
        {
            case CalculatorController.Operators.Add:
                return (double) (X + Y);
            case CalculatorController.Operators.Sub:
                return (double) (X - Y);
            case CalculatorController.Operators.Div:
                return (double) (X / Y);
            case CalculatorController.Operators.Mul:
                return (double) (X * Y);
            case CalculatorController.Operators.Pow:
                return Math.Pow((double)X,(double)Y);
            
            default: return double.NaN;
        }
    }
}