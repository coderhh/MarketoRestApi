﻿namespace MarketoApiLibrary.Common.Model
{
    public interface IError
    {
        string Code { get; set; }
        string Message { get; set; }
    }
}