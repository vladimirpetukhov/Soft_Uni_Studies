using System.Collections.Generic;
using System;
public class RegisterProviderCommand : Command
{
    public RegisterProviderCommand(IList<string> arguments, IRepository repository) 
        : base(arguments, repository)
    {
        this.Factory = new ProviderFactory();
    }

    public override string Execute()
    {
        string msg = string.Empty;
        try
        {
            var providerType =Arguments [0];
            var providerId = Arguments[1];
            IProvider provider =(IProvider) this.Factory.CreateUnit(Arguments);
            string m = this.Repository.AddProvider(providerId, provider);

            msg = String.Format(m,providerType,providerId);
        }
        catch (ArgumentException ex)
        {
            msg = ex.Message;
        }

        return msg;
    }
}

