namespace MathServer
{
    /// <summary>
    /// Math service implemetning IMathService interface.
    /// </summary>
    class MathService : IMathService
    {
        public double Add(double firstValue, double secondValue)
        {
            return firstValue + secondValue;
        }

        public double Div(double firstValue, double secondValue)
        {
            return firstValue / secondValue;
        }

        public double Mult(double firstValue, double secondValue)
        {
            return firstValue * secondValue;
        }

        public double Sub(double firstValue, double secondValue)
        {
            return firstValue - secondValue;
        }

        /// <summary>
        /// Determing what operation to use
        /// </summary>
        /// <param name="protocol"></param>
        /// <returns></returns>
        public double Delegate(string protocol)
        {
            var substrings = protocol.Split(':');
            switch (substrings[0])
            {
                case "+":
                    return Add(double.Parse(substrings[1]), double.Parse(substrings[2]));
                case "-":
                    return Sub(double.Parse(substrings[1]), double.Parse(substrings[2]));
                case "/":
                    return Div(double.Parse(substrings[1]), double.Parse(substrings[2]));
                case "*":
                    return Mult(double.Parse(substrings[1]), double.Parse(substrings[2]));
            }
            return 0;
        }
    }
}
