namespace ProjectDataStructure.Models
{
    public class Project1Service
    {
        private long combinationFunction(long a, long b)
        {
            if (a == b || b == 0)
                return 1;
            else
                return combinationFunction(a - 1, b) + combinationFunction(a - 1, b - 1);
        }
        public string GetCombinationFunction(long a, long b)
        {
            if (a < b)
            {
                return "First number must be bigger than Second number";
            }
            var combination = combinationFunction(a, b);
            return combination.ToString();
        }

        private long exponent(long number, int expont, long result = 1)
        {
            if (expont == 0)
                return result;
            result = number * result;
            expont = expont - 1;
            return exponent(number, expont, result); ;
        }
        public string GetExponent(long number, int expont)
        {
            if (number == null || expont == null)
            {
                return "The number or exponent is null!";
            }
            if (number == null || expont == null)
            {
                return "The number or power must be a number!";
            }
            var result = exponent(number, expont);
            return result.ToString();
        }

        private List<string> res = new List<string>();

        private void MoveTower(int n, int from, int to, int other)
        {
            
            if (n > 0)
            {
                MoveTower(n - 1, from, other, to);
                res.Add("Move disk " + n +" from tower " + from + " to tower " + to);
                MoveTower(n - 1, other, to, from);
            }
        }
        public List<string> GetTower(int n)
        {
            if (n == 0)
            {
                res.Add("The Tower Of Hanoi is null!");
                return res;
            }
            MoveTower(n, 1, 3, 2);
            return res;
        }
    }
}
