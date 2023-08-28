﻿namespace SpeakHub.Service.Common.Exceptions;
public class ModelErrorException : Exception
{
    public string Property { get; set; } = String.Empty;

    public ModelErrorException(string property, string message)
        : base(message)
    {
        this.Property = property;
    }
}
