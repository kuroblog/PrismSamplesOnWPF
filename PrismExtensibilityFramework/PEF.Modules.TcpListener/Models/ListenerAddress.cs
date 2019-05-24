
namespace PEF.Modules.TcpListener.Models
{
    using PEF.Common;
    using System.ComponentModel.DataAnnotations;

    public class ListenerAddress : ValidationBindableBase
    {
        private string ip = "127.0.0.1";

        [Required(ErrorMessage = "Value can not be empty.")]
        [RegularExpression(@"^((2[0-4]\d|25[0-5]|(1\d{2})|([1-9]?[0-9]))\.){3}(2[0-4]\d|25[0-4]|(1\d{2})|([1-9][0-9])|([1-9]))$", ErrorMessage = "Incorrect data format(0.0.0.0/255.255.255.255).")]
        public string Ip
        {
            get { return ip; }
            set { SetProperty(ref ip, value); }
        }

        private int port = 8081;

        [Required(ErrorMessage = "Value can not be empty.")]
        [Range(1, 65535, ErrorMessage = "Value needs to be between 1 and 65535.")]
        public int Port
        {
            get { return port; }
            set { SetProperty(ref port, value); }
        }
    }
}
