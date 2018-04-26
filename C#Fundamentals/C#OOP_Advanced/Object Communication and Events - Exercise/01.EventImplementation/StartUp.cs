﻿using System;

namespace _01.EventImplementation
{
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            while (true)
            {
                var name = Console.ReadLine();
                if (name == "End") break;

                dispatcher.Name = name;
            }
        }
    }
}
