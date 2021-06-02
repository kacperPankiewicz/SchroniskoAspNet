using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.ViewModels
{
    public class SortingModel
    {

        public List<zwierze> zwierzeList;
        public SelectList selectedWielkosc;
        public SelectList selectedGatunek;
        public SelectList selectedPlec;
        public SelectList selectedKastracja;




    }
}