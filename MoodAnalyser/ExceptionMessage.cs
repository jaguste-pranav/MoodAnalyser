using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class ExceptionMessage : Exception
    {
        public enum TypeOfException
        {
            NULL_MESSAGE,
            EMPTY_MESSAGE
        }

        TypeOfException type;

        public ExceptionMessage(TypeOfException type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
