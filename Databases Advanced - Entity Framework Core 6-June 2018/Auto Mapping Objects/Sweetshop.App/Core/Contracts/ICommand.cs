﻿namespace Sweetshop.App.Core.Contracts
{
   public interface ICommand
    {
        string Execute(string[] arguments);
    }
}
