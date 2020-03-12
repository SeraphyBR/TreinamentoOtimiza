using System;
using System.Collections.Generic;
using System.Text;

namespace P10_Vagas.Banco
{
    public interface ICaminho
    {
        string GetPath(string DBFilename);
    }
}
