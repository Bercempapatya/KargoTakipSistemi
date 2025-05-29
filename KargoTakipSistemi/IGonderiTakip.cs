using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakipSistemi
{
     public interface IGonderiTakip
    { 
        Durum GonderiDurumu { get; set; }//Burada kargonun son durumunu enumdan alıyoruz.
        void DurumGuncelle(Durum yeniDurum);// Bu metotlada yukarda aldığımız bilgiden yola çıkarak en son oluşacak durumunu yeniliyoruz.

    }
}
