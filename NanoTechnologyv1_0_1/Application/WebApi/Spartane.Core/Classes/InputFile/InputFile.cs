using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.InputFile
{
   /// <summary>
    /// InputFile table
    /// </summary>
    public class InputFile : BaseEntity
    {
        public string FileName { get; set; }
        public byte[] FileArray { get; set; }
    }
}

