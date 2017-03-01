using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealXamarinFormsDemo.Model
{
    public class Car: RealmObject
    {
        public string Brand { get; set; }
        public string Thumbnail { get; set; }
    }
}
