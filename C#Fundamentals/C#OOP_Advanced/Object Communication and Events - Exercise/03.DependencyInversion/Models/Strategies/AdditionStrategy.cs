﻿namespace _03.DependencyInversion.Models.Strategies
{
    using E03_DependencyInversion.Interfaces;

    public class AdditionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
