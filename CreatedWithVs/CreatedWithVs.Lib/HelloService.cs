﻿namespace CreatedWithVs.Lib
{
    public class HelloService : IHelloService
    {
        string IHelloService.GetHelloMessage(string userName)
        {
            return $"Hello {userName}";
        }
    }
}
