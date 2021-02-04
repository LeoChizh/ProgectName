using System;
using System.Collections.Generic;
using System.Text;


namespace ProgectName
{
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string itemName, int code)
        {
            ItemName = itemName;
            Code = code;
        }

        public string ItemName { get; set; }
        public int Code { get; set; }
    }

}
