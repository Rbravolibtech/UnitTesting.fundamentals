﻿
using System;

namespace TestNinja.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        private Guid _errorId;

        public event EventHandler<Guid> ErrorLogged;

        public Guid errorId;


        public void Log(string error)
        {

            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();

            LastError = error;

            // Write the log to a storage
            // ...

            _errorId = Guid.NewGuid();
            OnErrorLogged(Guid.NewGuid());

        }

        protected virtual void OnErrorLogged(Guid errorId)
        {
            ErrorLogged?.Invoke(this, errorId);
        }


    }
}