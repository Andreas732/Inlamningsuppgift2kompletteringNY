using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamningsuppgift2komplettering;
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool IsCheckedOut { get; set; }

    public override string ToString()
    {
        return $"{Title} by {Author}, ISBN: {ISBN}, Checked Out: {IsCheckedOut}";
    }
}
