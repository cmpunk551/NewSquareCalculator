using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareCalculator
{
    public class SquareCalculator
    {
        public interface IShape
        {
            double GetSquare();
        }

        public class Circle : IShape
        {
            public double Radius;

            public Circle(double radius)
            {
                Radius = radius;
            }

            public double GetSquare()
            {
                double squareOfCircle = Math.PI * Math.Pow(Radius, 2);

                return squareOfCircle;
            }
        }

        public class Triangle : IShape
        {
            public double FirstSide;
            public double SecondSide;
            public double ThirdSide;

            public Triangle(double firstSide, double secondSide, double thirdSide)
            {
                if (!IsTriangleExists(firstSide, secondSide, thirdSide))
                {
                    throw new Exception("Данное соотношение сторон не формирует треугольник");
                }
                else
                {
                    FirstSide = firstSide;
                    SecondSide = secondSide;
                    ThirdSide = thirdSide;
                }
            }

            public double GetSquare()
            {
                double squareOfTriangle = 0;
                double longestSide = Math.Max(Math.Max(FirstSide, SecondSide), ThirdSide);

                // square здесь подразумевается как "квадрат"
                double sumOfSquaresOfOtherSides = (Math.Pow(FirstSide, 2) + Math.Pow(SecondSide, 2) + Math.Pow(ThirdSide, 2)) - Math.Pow(longestSide, 2);

                // в случае прямоугольного треугольника площадь вычислиятся по его формуле
                if (Math.Pow(longestSide, 2) == sumOfSquaresOfOtherSides)
                {
                    squareOfTriangle = (0.5 * FirstSide * SecondSide * ThirdSide) / longestSide;
                    return squareOfTriangle;
                }

                double halfOfPerimeter = 0.5 * (FirstSide + SecondSide + ThirdSide);

                squareOfTriangle = GetSquareWithHeronsFormula(halfOfPerimeter, FirstSide, SecondSide, ThirdSide);

                return squareOfTriangle;
            }

            public static double GetSquareWithHeronsFormula(double halfOfPerimeter, double firstSide, double secondSide, double thirdSide)
            {
                double square = Math.Sqrt(halfOfPerimeter * (halfOfPerimeter - firstSide) * (halfOfPerimeter - secondSide) * (halfOfPerimeter - thirdSide));

                return square;
            }

            public Boolean IsTriangleExists(double firstSide, double secondSide, double thirdSide)
            {
                double longestSide = Math.Max(Math.Max(firstSide, secondSide), thirdSide);
                double sumOfOtherSides = (firstSide + secondSide + thirdSide) - longestSide;

                // проверка условия существования треугольника 
                if (longestSide < sumOfOtherSides)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
