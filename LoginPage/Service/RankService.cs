using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginPage.Models;

namespace LoginPage.Service
{
    public class RankService
    {
        public Darga[] Dargas { get; set; }

        public RankService()
        {
            Dargas = new Darga[3];
            Dargas[0] = new Darga() { DargaId = 1, DargaName = "Rookie" };
            Dargas[1] = new Darga() { DargaId = 2, DargaName = "Master" };
            Dargas[2] = new Darga() { DargaId = 3, DargaName = "Admin" };

        }

    }
}
