using System;
using System.Collections.Generic;
using System.Text;

namespace ProgectName
{
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

}
