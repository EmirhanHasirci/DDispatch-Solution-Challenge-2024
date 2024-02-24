using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.BaseDtos
{
    public class ErrorDto
    {
        public List<string> Errors { get; private set; }
        public bool IsShow { get; set; }
        public ErrorDto()
        {
            Errors = new();
        }
        public ErrorDto(string error, bool isShow)
        {
            Errors = new();
            Errors.Add(error);
            IsShow = isShow;
        }
        public ErrorDto(List<string> errors, bool isShow)
        {
            Errors = new();
            Errors = errors;
            IsShow = isShow;
        }
    }
}
